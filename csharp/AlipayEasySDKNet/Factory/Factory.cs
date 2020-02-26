using System;
using Alipay.EasySDK.Kernel;
using System.Collections.Generic;

namespace Alipay.EasySDK.Factory
{
    /// <summary>
    /// 客户端工厂，用于快速配置和访问各种场景下的API Client
    /// </summary>
    public static class Factory
    {
        private static readonly Dictionary<String, BaseClient> Clients = new Dictionary<string, BaseClient>();

        /// <summary>
        /// 设置客户端参数，只需设置一次，即可反复使用各种场景下的API Client
        /// </summary>
        /// <param name="options">客户端参数对象</param>
        public static void SetOptions(Config options)
        {
            RegisterClient(new EasySDK.Base.Image.Client(options));
            RegisterClient(new EasySDK.Base.Video.Client(options));
            RegisterClient(new EasySDK.Base.OAuth.Client(options));
            RegisterClient(new EasySDK.Base.Qrcode.Client(options));
            RegisterClient(new EasySDK.Marketing.OpenLife.Client(options));
            RegisterClient(new EasySDK.Marketing.Pass.Client(options));
            RegisterClient(new EasySDK.Marketing.TemplateMessage.Client(options));
            RegisterClient(new EasySDK.Member.Identification.Client(options));
            RegisterClient(new EasySDK.Payment.Common.Client(options));
            RegisterClient(new EasySDK.Payment.FaceToFace.Client(options));
            RegisterClient(new EasySDK.Payment.HuaBei.Client(options));
            RegisterClient(new EasySDK.Security.TextRisk.Client(options));
        }

        private static void RegisterClient(BaseClient client)
        {
            Clients[client.GetType().FullName] = client;
        }

        /// <summary>
        /// 基础能力相关
        /// </summary>
        public static class Base
        {
            /// <summary>
            /// 获取图片相关API Client
            /// </summary>
            /// <returns>图片相关API Client</returns>
            public static EasySDK.Base.Image.Client Image()
            {
                return GetClient<EasySDK.Base.Image.Client>(typeof(EasySDK.Base.Image.Client));
            }

            /// <summary>
            /// 获取视频相关API Client
            /// </summary>
            /// <returns>视频相关API Client</returns>
            public static EasySDK.Base.Video.Client Video()
            {
                return GetClient<EasySDK.Base.Video.Client>(typeof(EasySDK.Base.Video.Client));
            }

            /// <summary>
            /// 获取OAuth认证相关API Client
            /// </summary>
            /// <returns>OAuth认证相关API Client</returns>
            public static EasySDK.Base.OAuth.Client OAuth()
            {
                return GetClient<EasySDK.Base.OAuth.Client>(typeof(EasySDK.Base.OAuth.Client));
            }

            /// <summary>
            /// 获取小程序二维码相关API Client
            /// </summary>
            /// <returns>小程序二维码相关API Client</returns>
            public static EasySDK.Base.Qrcode.Client Qrcode()
            {
                return GetClient<EasySDK.Base.Qrcode.Client>(typeof(EasySDK.Base.Qrcode.Client));
            }
        }

        private static T GetClient<T>(Type type) where T : BaseClient
        {
            if (Clients.ContainsKey(type.FullName))
            {
                return (T)Clients[type.FullName];
            }
            else
            {
                throw new Exception("尚未注册" + type.FullName + "，请先调用Factory.setOptions方法。");
            }
        }

        /// <summary>
        /// 营销能力相关
        /// </summary>
        public static class Marketing
        {
            /// <summary>
            /// 获取生活号相关API Client
            /// </summary>
            /// <returns>生活号相关API Client</returns>
            public static EasySDK.Marketing.OpenLife.Client OpenLife()
            {
                return GetClient<EasySDK.Marketing.OpenLife.Client>(typeof(EasySDK.Marketing.OpenLife.Client));
            }

            /// <summary>
            /// 获取支付宝卡包相关API Client
            /// </summary>
            /// <returns>支付宝卡包相关API Client</returns>
            public static EasySDK.Marketing.Pass.Client Pass()
            {
                return GetClient<EasySDK.Marketing.Pass.Client>(typeof(EasySDK.Marketing.Pass.Client));
            }

            /// <summary>
            /// 获取小程序模板消息相关API Client
            /// </summary>
            /// <returns>小程序模板消息相关API Client</returns>
            public static EasySDK.Marketing.TemplateMessage.Client TemplateMessage()
            {
                return GetClient<EasySDK.Marketing.TemplateMessage.Client>(typeof(EasySDK.Marketing.TemplateMessage.Client));
            }
        }

        /// <summary>
        /// 会员能力相关
        /// </summary>
        public static class Member
        {
            /// <summary>
            /// 获取支付宝身份认证相关API Client
            /// </summary>
            /// <returns>支付宝身份认证相关API Client</returns>
            public static EasySDK.Member.Identification.Client Identification()
            {
                return GetClient<EasySDK.Member.Identification.Client>(typeof(EasySDK.Member.Identification.Client));
            }
        }

        /// <summary>
        /// 支付能力相关
        /// </summary>
        public static class Payment
        {
            /// <summary>
            /// 获取支付通用API Client
            /// </summary>
            /// <returns></returns>
            public static EasySDK.Payment.Common.Client Common()
            {
                return GetClient<EasySDK.Payment.Common.Client>(typeof(EasySDK.Payment.Common.Client));
            }

            /// <summary>
            /// 获取当面付API Client
            /// </summary>
            /// <returns></returns>
            public static EasySDK.Payment.FaceToFace.Client FaceToFace()
            {
                return GetClient<EasySDK.Payment.FaceToFace.Client>(typeof(EasySDK.Payment.FaceToFace.Client));
            }

            /// <summary>
            /// 获取花呗API Client
            /// </summary>
            /// <returns></returns>
            public static EasySDK.Payment.HuaBei.Client HuaBei()
            {
                return GetClient<EasySDK.Payment.HuaBei.Client>(typeof(EasySDK.Payment.HuaBei.Client));
            }
        }

        /// <summary>
        /// 安全能力相关
        /// </summary>
        public static class Security
        {
            /// <summary>
            /// 获取文本风险识别相关API Client
            /// </summary>
            /// <returns>文本风险识别相关API Client</returns>
            public static EasySDK.Security.TextRisk.Client TextRisk()
            {
                return GetClient<EasySDK.Security.TextRisk.Client>(typeof(EasySDK.Security.TextRisk.Client));
            }
        }
    }
}
