using NUnit.Framework;
using Alipay.EasySDK.Factory;
using Alipay.EasySDK.Member.Identification.Models;
using System;

namespace UnitTest.Member.Identification
{
    public class ClientTest
    {
        [SetUp]
        public void SetUp()
        {
            Factory.SetOptions(TestAccount.Mini.CONFIG);
        }

        [Test]
        public void TestInit()
        {
            IdentityParam identityParam = new IdentityParam()
            {
                IdentityType = "CERT_INFO",
                CertType = "IDENTITY_CARD",
                CertName = "张三",
                CertNo = "513901198008089876"
            };

            MerchantConfig merchantConfig = new MerchantConfig()
            {
                ReturnUrl = "www.taobao.com"
            };


            AlipayUserCertifyOpenInitializeResponse response = Factory.Member.Identification().Init(
                Guid.NewGuid().ToString(), "FACE", identityParam, merchantConfig);

            Assert.AreEqual(response.Code, "10000");
            Assert.AreEqual(response.Msg, "Success");
            Assert.IsNull(response.SubCode);
            Assert.IsNull(response.SubMsg);
            Assert.NotNull(response.HttpBody);
            Assert.NotNull(response.CertifyId);
        }

        [Test]
        public void TestCertify()
        {
            AlipayUserCertifyOpenCertifyResponse response = Factory.Member.Identification().Certify("bbdb57e87211279e2c22de5846d85161");

            Assert.IsTrue(response.Body.Contains("https://openapi.alipay.com/gateway.do?alipay_sdk=alipay-easysdk-net"));
            Assert.IsTrue(response.Body.Contains("sign"));
        }

        [Test]
        public void TestQuery()
        {
            AlipayUserCertifyOpenQueryResponse response = Factory.Member.Identification().Query("89ad1f1b8171d9741c3e5620fd77f9de");

            Assert.AreEqual(response.Code, "10000");
            Assert.AreEqual(response.Msg, "Success");
            Assert.IsNull(response.SubCode);
            Assert.IsNull(response.SubMsg);
            Assert.NotNull(response.HttpBody);
            Assert.AreEqual(response.Passed, "F");
            Assert.IsNull(response.IdentityInfo);
            Assert.AreEqual(response.MaterialInfo, "{}");
        }
    }
}
