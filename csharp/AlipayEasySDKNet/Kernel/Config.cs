using Tea;

namespace Alipay.EasySDK.Kernel
{
    /// <summary>
    /// 客户端配置参数模型
    /// </summary>
    public class Config : TeaModel
    {
        [NameInMap("protocol")]
        [Validation(Required = true)]
        public string Protocol { get; set; }

        [NameInMap("gatewayHost")]
        [Validation(Required = true)]
        public string GatewayHost { get; set; }

        [NameInMap("appId")]
        [Validation(Required = true)]
        public string AppId { get; set; }

        [NameInMap("signType")]
        [Validation(Required = true)]
        public string SignType { get; set; }

        [NameInMap("alipayPublicKey")]
        [Validation(Required = true)]
        public string AlipayPublicKey { get; set; }

        [NameInMap("merchantPrivateKey")]
        [Validation(Required = true)]
        public string MerchantPrivateKey { get; set; }

        [NameInMap("merchantCertPath")]
        [Validation(Required = true)]
        public string MerchantCertPath { get; set; }

        [NameInMap("alipayCertPath")]
        [Validation(Required = true)]
        public string AlipayCertPath { get; set; }

        [NameInMap("alipayRootCertPath")]
        [Validation(Required = true)]
        public string AlipayRootCertPath { get; set; }
    }
}
