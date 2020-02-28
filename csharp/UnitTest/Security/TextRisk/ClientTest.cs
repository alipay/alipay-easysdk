using NUnit.Framework;
using Alipay.EasySDK.Factory;
using Alipay.EasySDK.Security.TextRisk.Models;

namespace UnitTest.Security.TextRisk
{
    public class ClientTest
    {
        [SetUp]
        public void SetUp()
        {
            Factory.SetOptions(TestAccount.Mini.CONFIG);
        }

        [Test]
        public void TestDetect()
        {
            AlipaySecurityRiskContentDetectResponse response = Factory.Security.TextRisk().Detect("test");

            Assert.AreEqual(response.Code, "10000");
            Assert.AreEqual(response.Msg, "Success");
            Assert.Null(response.SubCode);
            Assert.Null(response.SubMsg);
            Assert.NotNull(response.HttpBody);
            Assert.AreEqual(response.Action, "PASSED");
            Assert.NotNull(response.UniqueId);
        }
    }
}
