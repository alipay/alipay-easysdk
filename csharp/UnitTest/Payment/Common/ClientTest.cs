using NUnit.Framework;
using Alipay.EasySDK.Kernel;
using Alipay.EasySDK.Factory;
using Alipay.EasySDK.Payment.Common.Models;
using System;
using System.Collections.Generic;

namespace UnitTest.Payment.Common
{
    public class ClientTest
    {
        [SetUp]
        public void SetUp()
        {
            Factory.SetOptions(TestAccount.Mini.CONFIG);
        }

        [Test]
        public void TestCreate()
        {
            string outTradeNo = Guid.NewGuid().ToString();
            AlipayTradeCreateResponse response = Factory.Payment.Common().Create("iPhone6 16G",
                    outTradeNo, "88.88", "2088002656718920");

            Assert.AreEqual(response.Code, "10000");
            Assert.AreEqual(response.Msg, "Success");
            Assert.Null(response.SubCode);
            Assert.Null(response.SubMsg);
            Assert.NotNull(response.HttpBody);
            Assert.AreEqual(response.OutTradeNo, outTradeNo);
            Assert.True(response.TradeNo.StartsWith("202"));
        }

        [Test]
        public void TestQuery()
        {
            AlipayTradeQueryResponse response = Factory.Payment.Common().Query("6f149ddb-ab8c-4546-81fb-5880b4aaa318");

            Assert.AreEqual(response.Code, "10000");
            Assert.AreEqual(response.Msg, "Success");
            Assert.Null(response.SubCode);
            Assert.Null(response.SubMsg);
            Assert.NotNull(response.HttpBody);
            Assert.AreEqual(response.OutTradeNo, "6f149ddb-ab8c-4546-81fb-5880b4aaa318");
        }

        [Test]
        public void TestCancel()
        {
            AlipayTradeCancelResponse response = Factory.Payment.Common().Cancel(CreateNewAndReturnOutTradeNo());

            Assert.AreEqual(response.Code, "10000");
            Assert.AreEqual(response.Msg, "Success");
            Assert.Null(response.SubCode);
            Assert.Null(response.SubMsg);
            Assert.NotNull(response.HttpBody);
            Assert.AreEqual(response.Action, "close");
        }

        [Test]
        public void TestClose()
        {
            AlipayTradeCloseResponse response = Factory.Payment.Common().Close(CreateNewAndReturnOutTradeNo());

            Assert.AreEqual(response.Code, "10000");
            Assert.AreEqual(response.Msg, "Success");
            Assert.Null(response.SubCode);
            Assert.Null(response.SubMsg);
            Assert.NotNull(response.HttpBody);
        }

        [Test]
        public void TestRefund()
        {
            AlipayTradeRefundResponse response = Factory.Payment.Common().Refund(CreateNewAndReturnOutTradeNo(), "0.01");

            Assert.AreEqual(response.Code, "40004");
            Assert.AreEqual(response.Msg, "Business Failed");
            Assert.AreEqual(response.SubCode, "ACQ.TRADE_STATUS_ERROR");
            Assert.AreEqual(response.SubMsg, "交易状态不合法");
            Assert.NotNull(response.HttpBody);
        }

        [Test]
        public void TestQueryRefund()
        {
            AlipayTradeFastpayRefundQueryResponse response = Factory.Payment.Common().QueryRefund(
                "64628156-f784-4572-9540-485b7c91b850", "64628156-f784-4572-9540-485b7c91b850");

            Assert.AreEqual(response.Code, "10000");
            Assert.AreEqual(response.Msg, "Success");
            Assert.IsNull(response.SubCode);
            Assert.IsNull(response.SubMsg);
            Assert.NotNull(response.HttpBody);
            Assert.AreEqual(response.RefundAmount, "0.01");
            Assert.AreEqual(response.TotalAmount, "0.01");
        }

        [Test]
        public void TestDownloadBill()
        {
            AlipayDataDataserviceBillDownloadurlQueryResponse response = Factory.Payment.Common().DownloadBill("trade", "2020-01");

            Assert.AreEqual(response.Code, "10000");
            Assert.AreEqual(response.Msg, "Success");
            Assert.IsNull(response.SubCode);
            Assert.IsNull(response.SubMsg);
            Assert.NotNull(response.HttpBody);
            Assert.IsTrue(response.BillDownloadUrl.StartsWith("http://dwbillcenter.alipay.com/"));
        }

        [Test]
        public void TestVerifyNotify()
        {
            Factory.SetOptions(GetConfig());
            bool? response = Factory.Payment.Common().VerifyNotify(GetParameters());

            Assert.IsTrue(response);
        }

        private Config GetConfig()
        {
            Config config = TestAccount.Mini.GetConfig();
            config.AlipayPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAkKHoQ7HAruVVIr5qoEWY4PkNbvtiLXAGiWiT"
                    + "JbuoGIebQr0QCKsN7ujU02kftNQIVAHkr4RoPhWo0thEavoH/QUvxVbW+6wizot5k0XEKEbZm7icFtM70Hi1uL1tF6P/V2h"
                    + "+nqVdX4im8gHcmz1K8VWiuiucDn20eFratwM0CfWaZhxZewgtOaePUBqr1ByusvPJ7vl6AfwViQmvrIUUlmXRCqu9igLjJs"
                    + "fJt0WNJu/ThkBmrdAXttvAHemsEoQiarobUEwErPrDKSEmlrupW3hVPuqQf253Z5TKMi0EJduO6Orn4AtEFtJlzBrBfxx9x"
                    + "Y6JP2JtV91M/3MEwLYyiQIDAQAB";
            return config;
        }

        private Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "charset", "UTF-8" },
                { "notify_time", "2020-03-25 16:27:08" },
                { "commodity_order_id", "202003250000000005945192" },
                { "total_price", "0.01" },
                { "method", "alipay.open.servicemarket.order.notify" },
                { "miniapp_release_bundle", "1032" },
                {
                    "sign",
                    "GM0CbuqaEivqgb6aRdWK1yvg3QoOIdBLIEB/wfeXHXlsYLvA2ChYO1VEDtLmnULrqfeSw2+BnwAxf04"
                    + "+DZHMtFgbUwNOES9BUyx2tZ5lQCettBHkobTwZIPk5qoq4ld6DMcPBoSbDKmuxPbaqti2"
                    + "+5M4BdVngKnc2ich6TfYSB4oLPqUAQHLpPoq3d1iaJwTN7jeLDBzbhqCv/aFIrnwk0W5hDcMGFGD32xbuFr2tHW"
                    + "/+tDFliapsVrH86PykVPn1OCtrbKBrC6v/+w+uUOnRB2mD7PYMoodntwOLvRP9am0N08fYciyBts3fLV8zmApMHWV7oHFsX4dbngcHEkTRg=="
                },
                { "order_time", "2020-03-25 16:27:00" },
                { "title", "社区新零售" },
                { "version", "1.0" },
                { "notify_id", "2020032500222162707030491455661685" },
                { "merchant_pid", "2088112276053036" },
                { "notify_type", "servicemarket_order_notify" },
                { "phone", "15936350926" },
                { "name", "赵华杰" },
                { "order_item_num", "1" },
                { "consumer_miniAppId", "2021001146661669" },
                { "contactor", "赵华杰" },
                { "app_id", "2018091261392200" },
                { "sign_type", "RSA2" },
                { "isv_ticket", "" },
                { "timestamp", "2020-03-25 16:27:08" }
            };
            return parameters;
        }

        private string CreateNewAndReturnOutTradeNo()
        {
            return Factory.Payment.Common().Create("iPhone6 16G", Guid.NewGuid().ToString(),
                    "88.88", "2088002656718920").OutTradeNo;
        }
    }
}
