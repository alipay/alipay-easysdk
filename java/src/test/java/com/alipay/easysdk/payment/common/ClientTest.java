package com.alipay.easysdk.payment.common;

import com.alipay.easysdk.TestAccount.Mini;
import com.alipay.easysdk.factory.Factory;
import com.alipay.easysdk.kernel.BaseClient.Config;
import com.alipay.easysdk.payment.common.models.AlipayDataDataserviceBillDownloadurlQueryResponse;
import com.alipay.easysdk.payment.common.models.AlipayTradeCancelResponse;
import com.alipay.easysdk.payment.common.models.AlipayTradeCloseResponse;
import com.alipay.easysdk.payment.common.models.AlipayTradeCreateResponse;
import com.alipay.easysdk.payment.common.models.AlipayTradeFastpayRefundQueryResponse;
import com.alipay.easysdk.payment.common.models.AlipayTradeQueryResponse;
import com.alipay.easysdk.payment.common.models.AlipayTradeRefundResponse;
import org.junit.Before;
import org.junit.Test;

import java.util.HashMap;
import java.util.Map;
import java.util.UUID;

import static org.hamcrest.CoreMatchers.is;
import static org.hamcrest.CoreMatchers.not;
import static org.hamcrest.CoreMatchers.nullValue;
import static org.hamcrest.CoreMatchers.startsWith;
import static org.hamcrest.MatcherAssert.assertThat;

public class ClientTest {
    @Before
    public void setUp() {
        Factory.setOptions(Mini.CONFIG);
    }

    @Test
    public void testCreate() throws Exception {
        String outTradeNo = UUID.randomUUID().toString();
        AlipayTradeCreateResponse response = Factory.Payment.Common().create("iPhone6 16G",
                outTradeNo, "0.01", "2088002656718920");

        assertThat(response.code, is("10000"));
        assertThat(response.msg, is("Success"));
        assertThat(response.subCode, is(nullValue()));
        assertThat(response.subMsg, is(nullValue()));
        assertThat(response.httpBody, not(nullValue()));
        assertThat(response.outTradeNo, is(outTradeNo));
        assertThat(response.tradeNo, startsWith("202"));
    }

    @Test
    public void testQuery() throws Exception {
        AlipayTradeQueryResponse response = Factory.Payment.Common().query("6f149ddb-ab8c-4546-81fb-5880b4aaa318");

        assertThat(response.code, is("10000"));
        assertThat(response.msg, is("Success"));
        assertThat(response.subCode, is(nullValue()));
        assertThat(response.subMsg, is(nullValue()));
        assertThat(response.httpBody, not(nullValue()));
        assertThat(response.outTradeNo, is("6f149ddb-ab8c-4546-81fb-5880b4aaa318"));
    }

    @Test
    public void testCancel() throws Exception {
        AlipayTradeCancelResponse response = Factory.Payment.Common().cancel(createNewAndReturnOutTradeNo());

        assertThat(response.code, is("10000"));
        assertThat(response.msg, is("Success"));
        assertThat(response.subCode, is(nullValue()));
        assertThat(response.subMsg, is(nullValue()));
        assertThat(response.httpBody, not(nullValue()));
        assertThat(response.action, is("close"));
    }

    @Test
    public void testClose() throws Exception {
        AlipayTradeCloseResponse response = Factory.Payment.Common().close(createNewAndReturnOutTradeNo());

        assertThat(response.code, is("10000"));
        assertThat(response.msg, is("Success"));
        assertThat(response.subCode, is(nullValue()));
        assertThat(response.subMsg, is(nullValue()));
        assertThat(response.httpBody, not(nullValue()));
    }

    @Test
    public void testRefund() throws Exception {
        AlipayTradeRefundResponse response = Factory.Payment.Common().refund(
                "64628156-f784-4572-9540-485b7c91b850", "0.01");

        assertThat(response.code, is("10000"));
        assertThat(response.msg, is("Success"));
        assertThat(response.subCode, is(nullValue()));
        assertThat(response.subMsg, is(nullValue()));
        assertThat(response.httpBody, not(nullValue()));
        assertThat(response.refundFee, is("0.01"));
    }

    @Test
    public void testQueryRefund() throws Exception {
        AlipayTradeFastpayRefundQueryResponse response = Factory.Payment.Common().queryRefund(
                "64628156-f784-4572-9540-485b7c91b850", "64628156-f784-4572-9540-485b7c91b850");

        assertThat(response.code, is("10000"));
        assertThat(response.msg, is("Success"));
        assertThat(response.subCode, is(nullValue()));
        assertThat(response.subMsg, is(nullValue()));
        assertThat(response.httpBody, not(nullValue()));
        assertThat(response.refundAmount, is("0.01"));
        assertThat(response.totalAmount, is("0.01"));
    }

    @Test
    public void testDownloadBill() throws Exception {
        AlipayDataDataserviceBillDownloadurlQueryResponse response = Factory.Payment.Common().downloadBill("trade", "2020-01");

        assertThat(response.code, is("10000"));
        assertThat(response.msg, is("Success"));
        assertThat(response.subCode, is(nullValue()));
        assertThat(response.subMsg, is(nullValue()));
        assertThat(response.httpBody, not(nullValue()));
        assertThat(response.billDownloadUrl.startsWith("http://dwbillcenter.alipay.com/"), is(true));
    }

    @Test
    public void testVerifyNotify() throws Exception {
        Factory.setOptions(getConfig());
        boolean response = Factory.Payment.Common().verifyNotify(getParameters());

        assertThat(response, is(true));
    }

    private Config getConfig() {
        Config config = Mini.getConfig();
        config.alipayPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAkKHoQ7HAruVVIr5qoEWY4PkNbvtiLXAGiWiT"
                + "JbuoGIebQr0QCKsN7ujU02kftNQIVAHkr4RoPhWo0thEavoH/QUvxVbW+6wizot5k0XEKEbZm7icFtM70Hi1uL1tF6P/V2h"
                + "+nqVdX4im8gHcmz1K8VWiuiucDn20eFratwM0CfWaZhxZewgtOaePUBqr1ByusvPJ7vl6AfwViQmvrIUUlmXRCqu9igLjJs"
                + "fJt0WNJu/ThkBmrdAXttvAHemsEoQiarobUEwErPrDKSEmlrupW3hVPuqQf253Z5TKMi0EJduO6Orn4AtEFtJlzBrBfxx9x"
                + "Y6JP2JtV91M/3MEwLYyiQIDAQAB";
        return config;
    }

    private Map<String, String> getParameters() {
        Map<String, String> parameters = new HashMap<>();
        parameters.put("charset", "UTF-8");
        parameters.put("notify_time", "2020-03-25 16:27:08");
        parameters.put("commodity_order_id", "202003250000000005945192");
        parameters.put("total_price", "0.01");
        parameters.put("method", "alipay.open.servicemarket.order.notify");
        parameters.put("miniapp_release_bundle", "1032");
        parameters.put("sign", "GM0CbuqaEivqgb6aRdWK1yvg3QoOIdBLIEB/wfeXHXlsYLvA2ChYO1VEDtLmnULrqfeSw2+BnwAxf04"
                + "+DZHMtFgbUwNOES9BUyx2tZ5lQCettBHkobTwZIPk5qoq4ld6DMcPBoSbDKmuxPbaqti2"
                + "+5M4BdVngKnc2ich6TfYSB4oLPqUAQHLpPoq3d1iaJwTN7jeLDBzbhqCv/aFIrnwk0W5hDcMGFGD32xbuFr2tHW"
                + "/+tDFliapsVrH86PykVPn1OCtrbKBrC6v/+w+uUOnRB2mD7PYMoodntwOLvRP9am0N08fYciyBts3fLV8zmApMHWV7oHFsX4dbngcHEkTRg==");
        parameters.put("order_time", "2020-03-25 16:27:00");
        parameters.put("title", "社区新零售");
        parameters.put("version", "1.0");
        parameters.put("notify_id", "2020032500222162707030491455661685");
        parameters.put("merchant_pid", "2088112276053036");
        parameters.put("notify_type", "servicemarket_order_notify");
        parameters.put("phone", "15936350926");
        parameters.put("name", "赵华杰");
        parameters.put("order_item_num", "1");
        parameters.put("consumer_miniAppId", "2021001146661669");
        parameters.put("contactor", "赵华杰");
        parameters.put("app_id", "2018091261392200");
        parameters.put("sign_type", "RSA2");
        parameters.put("isv_ticket", "");
        parameters.put("timestamp", "2020-03-25 16:27:08");
        return parameters;
    }

    private String createNewAndReturnOutTradeNo() throws Exception {
        return Factory.Payment.Common().create("iPhone6 16G", UUID.randomUUID().toString(),
                "88.88", "2088002656718920").outTradeNo;
    }
}