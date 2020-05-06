using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using Newtonsoft.Json;

using Alipay.EasySDK.Kernel.Util;

using Tea;

namespace Alipay.EasySDK.Kernel
{
    /// <summary>
    /// Tea DSL所需的BaseClient，实现了DSL中定义的虚拟函数
    /// 注：以_开头的函数即实现的虚拟函数
    /// </summary>
    public class BaseClient
    {

        /// <summary>
        /// SHA256WithRSA签名器
        /// </summary>
        private readonly Signer Signer = new Signer();

        /// <summary>
        /// 签名原文提取器
        /// </summary>
        private readonly SignContentExtractor SignContentExtractor = new SignContentExtractor();

        /// <summary>
        /// 客户端配置参数
        /// </summary>
        private readonly Dictionary<string, object> Config;

        /// <summary>
        /// 证书模式运行时环境
        /// </summary>
        private readonly CertEnvironment CertEnvironment;

        /// <summary>
        /// 通过参数配置初始化客户端
        /// 如果参数中配置了证书相关参数，需在此时初始化证书运行时环境对象，缓存证书相关上下文
        /// </summary>
        /// <param name="config">参数集合</param>
        public BaseClient(Dictionary<string, object> config)
        {
            this.Config = config;
            ArgumentValidator.CheckArgument(AlipayConstants.RSA2.Equals(GetConfig(AlipayConstants.SIGN_TYPE_CONFIG_KEY)),
               "Alipay Easy SDK只允许使用RSA2签名方式，RSA签名方式由于安全性相比RSA2弱已不再推荐。");

            if (!string.IsNullOrEmpty(GetConfig(AlipayConstants.ALIPAY_CERT_PATH_CONFIG_KEY)))
            {
                CertEnvironment = new CertEnvironment(
                        GetConfig(AlipayConstants.MERCHANT_CERT_PATH_CONFIG_KEY),
                        GetConfig(AlipayConstants.ALIPAY_CERT_PATH_CONFIG_KEY),
                        GetConfig(AlipayConstants.ALIPAY_ROOT_CERT_PATH_CONFIG_KEY));
            }
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="key">配置的Key值</param>
        /// <returns>配置的Value值</returns>
        protected string _getConfig(string key)
        {
            return GetConfig(key);
        }

        private string GetConfig(string key)
        {
            return (string)Config[key];
        }

        /// <summary>
        /// 是否是证书模式
        /// </summary>
        /// <returns>true：是；false：不是</returns>
        protected bool _isCertMode()
        {
            return CertEnvironment != null;
        }

        /// <summary>
        /// 获取时间戳，格式yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <returns>当前时间戳</returns>
        protected string _getTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 计算签名，注意要去除key或value为null的键值对
        /// </summary>
        /// <param name="systemParams">系统参数集合</param>
        /// <param name="bizParams">业务参数集合</param>
        /// <param name="textParams">其他额外文本参数集合</param>
        /// <param name="privateKey">私钥</param>
        /// <returns>签名值的Base64串</returns>
        protected string _sign(Dictionary<string, string> systemParams, Dictionary<string, object> bizParams,
            Dictionary<string, string> textParams, string privateKey)
        {
            IDictionary<string, string> sortedMap = GetSortedMap(systemParams, bizParams, textParams);

            StringBuilder content = new StringBuilder();
            foreach (var pair in sortedMap)
            {
                if (!string.IsNullOrEmpty(pair.Key) && !string.IsNullOrEmpty(pair.Value))
                {
                    content.Append(pair.Key).Append("=").Append(pair.Value).Append("&");
                }
            }
            if (content.Length > 0)
            {
                //去除尾巴上的&
                content.Remove(content.Length - 1, 1);
            }

            return Signer.Sign(content.ToString(), privateKey);
        }

        private IDictionary<string, string> GetSortedMap(Dictionary<string, string> systemParams,
            Dictionary<string, object> bizParams, Dictionary<string, string> textParams)
        {
            IDictionary<string, string> sortedMap = new SortedDictionary<string, string>(systemParams, StringComparer.Ordinal);
            if (bizParams != null && bizParams.Count != 0)
            {
                sortedMap.Add(AlipayConstants.BIZ_CONTENT_FIELD, JsonUtil.ToJsonString(bizParams));
            }

            if (textParams != null)
            {
                foreach (var pair in textParams)
                {
                    sortedMap.Add(pair.Key, pair.Value);
                }
            }

            SetNotifyUrl(sortedMap);

            return sortedMap;
        }

        private void SetNotifyUrl(IDictionary<string, string> paramters)
        {
            if (GetConfig(AlipayConstants.NOTIFY_URL_CONFIG_KEY) != null && !paramters.ContainsKey(AlipayConstants.NOTIFY_URL_FIELD))
            {
                paramters.Add(AlipayConstants.NOTIFY_URL_FIELD, GetConfig(AlipayConstants.NOTIFY_URL_CONFIG_KEY));
            }
        }

        /// <summary>
        /// 获取商户应用公钥证书序列号，从证书模式运行时环境对象中直接读取
        /// </summary>
        /// <returns>商户应用公钥证书序列号</returns>
        protected string _getMerchantCertSN()
        {
            if (CertEnvironment == null)
            {
                return null;
            }

            return CertEnvironment.MerchantCertSN;
        }

        /// <summary>
        /// 获取支付宝根证书序列号，从证书模式运行时环境对象中直接读取
        /// </summary>
        /// <returns>支付宝根证书序列号</returns>
        protected string _getAlipayRootCertSN()
        {
            if (CertEnvironment == null)
            {
                return null;
            }
            return CertEnvironment.RootCertSN;
        }

        /// <summary>
        /// 将业务参数和其他额外文本参数按www-form-urlencoded格式转换成HTTP Body中的字节数组，注意要做URL Encode
        /// </summary>
        /// <param name="bizParams">业务参数</param>
        /// <returns>HTTP Body中的字节数组</returns>
        protected byte[] _toUrlEncodedRequestBody(Dictionary<string, object> bizParams)
        {

            IDictionary<string, string> sortedMap = GetSortedMap(new Dictionary<string, string>(), bizParams, null);
            return AlipayConstants.DEFAULT_CHARSET.GetBytes(BuildQueryString(sortedMap));
        }

        private string BuildQueryString(IDictionary<string, string> sortedMap)
        {
            StringBuilder content = new StringBuilder();
            int index = 0;
            foreach (var pair in sortedMap)
            {
                if (!string.IsNullOrEmpty(pair.Key) && !string.IsNullOrEmpty(pair.Value))
                {
                    content.Append(index == 0 ? "" : "&")
                            .Append(pair.Key)
                            .Append("=")
                            .Append(HttpUtility.UrlEncode(pair.Value, AlipayConstants.DEFAULT_CHARSET));
                    index++;
                }
            }
            return content.ToString();
        }

        /// <summary>
        /// 生成随机分界符，用于multipart格式的HTTP请求Body的多个字段间的分隔
        /// </summary>
        /// <returns>随机分界符</returns>
        protected string _getRandomBoundary()
        {
            return DateTime.Now.Ticks.ToString("X");
        }

        /// <summary>
        /// 字符串拼接
        /// </summary>
        /// <param name="a">字符串a</param>
        /// <param name="b">字符串b</param>
        /// <returns>字符串a和b拼接后的字符串</returns>
        protected string _concatStr(string a, string b)
        {
            return a + b;
        }

        /// <summary>
        /// 将其他额外文本参数和文件参数按multipart/form-data格式转换成HTTP Body中的字节数组流
        /// </summary>
        /// <param name="textParams">其他额外文本参数</param>
        /// <param name="fileParams">业务文件参数</param>
        /// <param name="boundary">HTTP Body中multipart格式的分隔符</param>
        /// <returns></returns>
        protected Stream _toMultipartRequestBody(Dictionary<string, string> textParams, Dictionary<string, string> fileParams, string boundary)
        {
            MemoryStream stream = new MemoryStream();

            //组装其他额外文本参数
            SetNotifyUrl(textParams);
            foreach (var pair in textParams)
            {
                if (!string.IsNullOrEmpty(pair.Key) && !string.IsNullOrEmpty(pair.Value))
                {
                    MultipartUtil.WriteToStream(stream, MultipartUtil.GetEntryBoundary(boundary));
                    MultipartUtil.WriteToStream(stream, MultipartUtil.GetTextEntry(pair.Key, pair.Value));
                }
            }

            //组装文件参数
            foreach (var pair in fileParams)
            {
                if (!string.IsNullOrEmpty(pair.Key) && pair.Value != null)
                {
                    MultipartUtil.WriteToStream(stream, MultipartUtil.GetEntryBoundary(boundary));
                    MultipartUtil.WriteToStream(stream, MultipartUtil.GetFileEntry(pair.Key, pair.Value));
                    MultipartUtil.WriteToStream(stream, File.ReadAllBytes(pair.Value));
                }
            }

            //添加结束标记
            MultipartUtil.WriteToStream(stream, MultipartUtil.GetEndBoundary(boundary));

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        /// <summary>
        /// 将网关响应发序列化成Map，同时将API的接口名称和响应原文插入到响应Map的method和body字段中
        /// </summary>
        /// <param name="response">HTTP响应</param>
        /// <param name="method">调用的OpenAPI的接口名称</param>
        /// <returns>响应反序列化的Map</returns>
        protected Dictionary<string, object> _readAsJson(TeaResponse response, string method)
        {
            string responseBody = TeaCore.GetResponseBody(response);
            Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);
            dictionary.Add(AlipayConstants.BODY_FIELD, responseBody);
            dictionary.Add(AlipayConstants.METHOD_FIELD, method);
            return DictionaryUtil.ObjToDictionary(dictionary);
        }

        /// <summary>
        /// 从响应Map中提取支付宝公钥证书序列号
        /// </summary>
        /// <param name="respMap">响应Map</param>
        /// <returns>支付宝公钥证书序列号</returns>
        protected string _getAlipayCertSN(Dictionary<string, object> respMap)
        {
            return (string)respMap[AlipayConstants.ALIPAY_CERT_SN_FIELD];
        }

        /// <summary>
        /// 获取支付宝公钥，从证书运行时环境对象中直接读取
        /// 如果缓存的用户指定的支付宝公钥证书的序列号与网关响应中携带的支付宝公钥证书序列号不一致，需要报错给出提示或自动更新支付宝公钥证书
        /// </summary>
        /// <param name="alipayCertSN">网关响应中携带的支付宝公钥证书序列号</param>
        /// <returns>支付宝公钥</returns>
        protected string _extractAlipayPublicKey(string alipayCertSN)
        {
            if (CertEnvironment == null)
            {
                return null;
            }
            return CertEnvironment.GetAlipayPublicKey(alipayCertSN);
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="respMap">响应Map，可以从中提取出sign和body</param>
        /// <param name="alipayPublicKey">支付宝公钥</param>
        /// <returns>true：验签通过；false：验签不通过</returns>
        protected bool _verify(Dictionary<string, object> respMap, string alipayPublicKey)
        {
            string sign = (string)respMap[AlipayConstants.SIGN_FIELD];
            string content = SignContentExtractor.GetSignSourceData((string)respMap[AlipayConstants.BODY_FIELD],
                    (string)respMap[AlipayConstants.METHOD_FIELD]);
            return Signer.Verify(content, sign, alipayPublicKey);
        }

        /// <summary>
        /// 从响应Map中提取返回值对象的Map，并将响应原文插入到body字段中
        /// </summary>
        /// <param name="respMap">响应Map</param>
        /// <returns>返回值对象Map</returns>
        protected Dictionary<string, object> _toRespModel(Dictionary<string, object> respMap)
        {
            string methodName = (string)respMap[AlipayConstants.METHOD_FIELD];
            string responseNodeName = methodName.Replace('.', '_') + AlipayConstants.RESPONSE_SUFFIX;
            string errorNodeName = AlipayConstants.ERROR_RESPONSE;

            //先找正常响应节点
            foreach (var pair in respMap)
            {
                if (responseNodeName.Equals(pair.Key))
                {
                    Dictionary<string, object> model = (Dictionary<string, object>)pair.Value;
                    model.Add(AlipayConstants.BODY_FIELD, respMap[AlipayConstants.BODY_FIELD]);
                    return model;
                }
            }

            //再找异常响应节点
            foreach (var pair in respMap)
            {
                if (errorNodeName.Equals(pair.Key))
                {
                    Dictionary<string, object> model = (Dictionary<string, object>)pair.Value;
                    model.Add(AlipayConstants.BODY_FIELD, respMap[AlipayConstants.BODY_FIELD]);
                    return model;
                }
            }

            throw new Exception("响应格式不符合预期，找不到" + responseNodeName + "节点");
        }

        /// <summary>
        /// 生成页面类请求所需URL或Form表单
        /// </summary>
        /// <param name="method">GET或POST，决定是生成URL还是Form表单</param>
        /// <param name="systemParams">系统参数集合</param>
        /// <param name="bizParams">业务参数集合</param>
        /// <param name="textParams">其他额外文本参数集合</param>
        /// <param name="sign">所有参数的签名值</param>
        /// <returns>生成的URL字符串或表单</returns>
        protected string _generatePage(string method, Dictionary<string, string> systemParams, Dictionary<string, object> bizParams,
            Dictionary<string, string> textParams, string sign)
        {
            if (AlipayConstants.GET.Equals(method))
            {
                //采集并排序所有参数
                IDictionary<string, string> sortedMap = GetSortedMap(systemParams, bizParams, textParams);
                sortedMap.Add(AlipayConstants.SIGN_FIELD, sign);

                //将所有参数置于URL中
                return GetGatewayServerUrl() + "?" + BuildQueryString(sortedMap);
            }
            else if (AlipayConstants.POST.Equals(method))
            {
                //将系统参数、额外文本参数排序后置于URL中
                IDictionary<string, string> urlParams = GetSortedMap(systemParams, null, textParams);
                urlParams.Add(AlipayConstants.SIGN_FIELD, sign);
                string actionUrl = GetGatewayServerUrl() + "?" + BuildQueryString(urlParams);

                //将业务参数排序后置于form表单中
                IDictionary<string, string> formParams = new SortedDictionary<string, string>()
                {
                    { AlipayConstants.BIZ_CONTENT_FIELD, JsonUtil.ToJsonString(bizParams)}
                };
                return PageUtil.BuildForm(actionUrl, formParams);
            }
            else
            {
                throw new Exception("_generatePage中method只支持传入GET或POST");
            }
        }

        /// <summary>
        /// 生成订单串
        /// </summary>
        /// <param name="systemParams">系统参数集合</param>
        /// <param name="bizParams">业务参数集合</param>
        /// <param name="textParams">其他文本参数集合</param>
        /// <param name="sign">所有参数的签名值</param>
        /// <returns>订单串</returns>
        protected string _generateOrderString(Dictionary<string, string> systemParams, Dictionary<string, object> bizParams,
            Dictionary<string, string> textParams, string sign)
        {
            //采集并排序所有参数
            IDictionary<string, string> sortedMap = GetSortedMap(systemParams, bizParams, textParams);
            sortedMap.Add(AlipayConstants.SIGN_FIELD, sign);

            //将所有参数置于URL中
            return BuildQueryString(sortedMap);
        }

        private string GetGatewayServerUrl()
        {
            return GetConfig(AlipayConstants.PROTOCOL_CONFIG_KEY) + "://" + GetConfig(AlipayConstants.HOST_CONFIG_KEY) + "/gateway.do";
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainText">明文</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        protected string _aesEncrypt(string plainText, string key)
        {
            return AES.Encrypt(plainText, key);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="chiperText">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        protected string _aesDecrypt(string chiperText, string key)
        {
            return AES.Decrypt(chiperText, key);
        }

        /// <summary>
        /// 对支付类请求的异步通知的参数集合进行验签
        /// </summary>
        /// <param name="parameters">参数集合</param>
        /// <param name="alipayPublicKey">支付宝公钥</param>
        /// <returns>true：验证成功；false：验证失败</returns>
        protected bool _verifyParams(Dictionary<string, string> parameters, string alipayPublicKey)
        {
            return Signer.VerifyParams(parameters, alipayPublicKey);
        }

        /// <summary>
        /// 获取SDK版本信息
        /// </summary>
        /// <returns>SDK版本信息</returns>
        protected string _getSdkVersion()
        {
            return AlipayConstants.SDK_VERSION;
        }
    }
}
