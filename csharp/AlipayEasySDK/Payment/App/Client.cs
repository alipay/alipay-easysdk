// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Tea;

using Alipay.EasySDK.Kernel;
using Alipay.EasySDK.Payment.App.Models;

namespace Alipay.EasySDK.Payment.App
{
    public class Client : BaseClient
    {

        public Client(Config config): base(config.ToMap())
        { }


        public AlipayTradeAppPayResponse Pay(string subject, string outTradeNo, string totalAmount)
        {
            Dictionary<string, string> systemParams = new Dictionary<string, string>()
            {
                {"method", "alipay.trade.app.pay"},
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
                {"subject", subject},
                {"out_trade_no", outTradeNo},
                {"total_amount", totalAmount},
            };
            Dictionary<string, string> textParams = new Dictionary<string, string>(){};
            string sign = _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"));
            Dictionary<string, string> response = new Dictionary<string, string>()
            {
                {"body", _generateOrderString(systemParams, bizParams, textParams, sign)},
            };
            return TeaModel.ToObject<AlipayTradeAppPayResponse>(response);
        }

    }
}
