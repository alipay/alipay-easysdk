package com.alipay.easysdk.payment.facetoface;

import com.alipay.easysdk.TestAccount;
import com.alipay.easysdk.factory.Factory;
import com.alipay.easysdk.payment.facetoface.models.AlipayTradePayResponse;
import org.junit.Before;
import org.junit.Test;

import java.util.UUID;

import static org.hamcrest.CoreMatchers.is;
import static org.hamcrest.CoreMatchers.not;
import static org.hamcrest.CoreMatchers.nullValue;
import static org.junit.Assert.assertThat;

public class ClientTest {

    @Before
    public void setUp() {
        Factory.setOptions(TestAccount.Mini.CONFIG);
    }

    @Test
    public void testPay() throws Exception {
        AlipayTradePayResponse response = Factory.Payment.FaceToFace().pay("Iphone6 16G", createNewAndReturnOutTradeNo(), "0.10",
                "1234567890");

        assertThat(response.code, is("40004"));
        assertThat(response.msg, is("Business Failed"));
        assertThat(response.subCode, is("ACQ.PAYMENT_AUTH_CODE_INVALID"));
        assertThat(response.subMsg, is("支付失败，获取顾客账户信息失败，请顾客刷新付款码后重新收款，如再次收款失败，请联系管理员处理。[SOUNDWAVE_PARSER_FAIL]"));
        assertThat(response.httpBody, not(nullValue()));
    }

    private String createNewAndReturnOutTradeNo() throws Exception {
        return Factory.Payment.Common().create("Iphone6 16G", UUID.randomUUID().toString(),
                "88.88", "2088002656718920").outTradeNo;
    }
}