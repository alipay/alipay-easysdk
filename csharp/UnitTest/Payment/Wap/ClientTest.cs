using NUnit.Framework;
using Alipay.EasySDK.Factory;

namespace UnitTest.Payment.Wap
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
            Alipay.EasySDK.Payment.Wap.Models.AlipayTradeWapPayResponse response = Factory.Payment.Wap().Pay("iPhone6 16G",
                "b7f4bc7d-ea4b-4efd-9072-d8ea913c8946", "0.10",
                "https://www.taobao.com", "https://www.taobao.com");

            Assert.IsTrue(response.Body.Contains("<form name=\"punchout_form\" method=\"post\" action=\"https://openapi.alipay.com/gateway.do?"));
            Assert.IsTrue(response.Body.Contains("notify_url"));
            Assert.IsTrue(response.Body.Contains("return_url"));
            Assert.IsTrue(response.Body.Contains("<input type=\"hidden\" name=\"biz_content\" value=\"{&quot;subject&quot;:&quot;iPhone6 16G&quot;,&quot;"
                + "out_trade_no&quot;:&quot;b7f4bc7d-ea4b-4efd-9072-d8ea913c8946&quot;,&quot;"
                + "total_amount&quot;:&quot;0.10&quot;,&quot;quit_url&quot;:&quot;https://www.taobao.com&quot;,&quot;"
                + "product_code&quot;:&quot;QUICK_WAP_WAY&quot;}\">"));
            Assert.IsTrue(response.Body.Contains("<input type=\"submit\" value=\"立即支付\" style=\"display:none\" >"));
            Assert.IsTrue(response.Body.Contains("<script>document.forms[0].submit();</script>"));
        }
    }
}
