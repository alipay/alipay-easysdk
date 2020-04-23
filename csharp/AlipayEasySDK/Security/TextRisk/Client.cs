// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Tea;

using Alipay.EasySDK.Kernel;
using Alipay.EasySDK.Security.TextRisk.Models;

namespace Alipay.EasySDK.Security.TextRisk
{
    public class Client : BaseClient
    {

        public Client(Config config): base(config.ToMap())
        { }

        public AlipaySecurityRiskContentDetectResponse Detect(string content)
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.security.risk.content.detect"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"content", content},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.security.risk.content.detect");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipaySecurityRiskContentDetectResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipaySecurityRiskContentDetectResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<AlipaySecurityRiskContentDetectResponse> DetectAsync(string content)
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.security.risk.content.detect"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"content", content},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.security.risk.content.detect");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipaySecurityRiskContentDetectResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipaySecurityRiskContentDetectResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

    }
}
