using NUnit.Framework;
using Alipay.EasySDK.Factory;
using Alipay.EasySDK.Payment.FaceToFace.Models;
using System;

namespace UnitTest.Payment.FaceToFace
{
    public class ClientTest
    {
        [SetUp]
        public void SetUp()
        {
            Factory.SetOptions(TestAccount.Mini.CONFIG);
        }

        [Test]
        public void TestPay()
        {
            AlipayTradePayResponse response = Factory.Payment.FaceToFace().Pay("Iphone6 16G", CreateNewAndReturnOutTradeNo(), "0.01", "1234567890");

            Assert.AreEqual(response.Code, "40004");
            Assert.AreEqual(response.Msg, "Business Failed");
            Assert.AreEqual(response.SubCode, "ACQ.PAYMENT_AUTH_CODE_INVALID");
            Assert.AreEqual(response.SubMsg, "支付失败，获取顾客账户信息失败，请顾客刷新付款码后重新收款，如再次收款失败，请联系管理员处理。[SOUNDWAVE_PARSER_FAIL]");
            Assert.NotNull(response.HttpBody);
        }

        private string CreateNewAndReturnOutTradeNo()
        {
            return Factory.Payment.Common().Create("Iphone6 16G", Guid.NewGuid().ToString(),
                    "88.88", "2088002656718920").OutTradeNo;
        }
    }
}
