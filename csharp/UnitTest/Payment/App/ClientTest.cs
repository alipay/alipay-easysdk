using NUnit.Framework;
using Alipay.EasySDK.Factory;

namespace UnitTest.Payment.App
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
            Alipay.EasySDK.Payment.App.Models.AlipayTradeAppPayResponse response = Factory.Payment.App().Pay("iPhone6 16G",
                "f4833085-0c46-4bb0-8e5f-622a02a4cffc", "0.10");

            Assert.IsTrue(response.Body.Contains("app_id=2019022663440152&biz_content=%7b%22subject%22%3a%22iPhone6+16G%22%2c%22" +
                "out_trade_no%22%3a%22f4833085-0c46-4bb0-8e5f-622a02a4cffc%22%2c%22total_amount%22%3a%220.10%22%7d&charset=UTF-8&" +
                "format=json&method=alipay.trade.app.pay&notify_url=https%3a%2f%2fwww.test.com%2fcallback&sign="));
        }
    }
}
