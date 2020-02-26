package com.alipay.easysdk.payment.common;

import com.alipay.easysdk.TestAccount;
import com.alipay.easysdk.factory.Factory;
import com.alipay.easysdk.payment.common.models.AlipayTradeCancelResponse;
import com.alipay.easysdk.payment.common.models.AlipayTradeCloseResponse;
import com.alipay.easysdk.payment.common.models.AlipayTradeCreateResponse;
import com.alipay.easysdk.payment.common.models.AlipayTradeQueryResponse;
import com.alipay.easysdk.payment.common.models.AlipayTradeRefundResponse;
import org.junit.Before;
import org.junit.Test;

import java.util.UUID;

import static org.hamcrest.CoreMatchers.is;
import static org.hamcrest.CoreMatchers.not;
import static org.hamcrest.CoreMatchers.nullValue;
import static org.hamcrest.CoreMatchers.startsWith;
import static org.hamcrest.MatcherAssert.assertThat;

public class ClientTest {
    @Before
    public void setUp() {
        Factory.setOptions(TestAccount.Mini.CONFIG);
    }

    @Test
    public void testCrate() throws Exception {
        String outTradeNo = UUID.randomUUID().toString();
        AlipayTradeCreateResponse response = Factory.Payment.Common().create("Iphone6 16G",
                outTradeNo, "88.88", "2088002656718920");

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
        AlipayTradeQueryResponse response = Factory.Payment.Common().query("1234567890");

        assertThat(response.code, is("10000"));
        assertThat(response.msg, is("Success"));
        assertThat(response.subCode, is(nullValue()));
        assertThat(response.subMsg, is(nullValue()));
        assertThat(response.httpBody, not(nullValue()));
        assertThat(response.outTradeNo, is("1234567890"));
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
        AlipayTradeRefundResponse response = Factory.Payment.Common().refund(createNewAndReturnOutTradeNo(), "0.01");

        assertThat(response.code, is("40004"));
        assertThat(response.msg, is("Business Failed"));
        assertThat(response.subCode, is("ACQ.TRADE_STATUS_ERROR"));
        assertThat(response.subMsg, is("交易状态不合法"));
        assertThat(response.httpBody, not(nullValue()));
    }

    private String createNewAndReturnOutTradeNo() throws Exception {
        return Factory.Payment.Common().create("Iphone6 16G", UUID.randomUUID().toString(),
                "88.88", "2088002656718920").outTradeNo;
    }
}