/**
 * Alipay.com Inc.
 * Copyright (c) 2004-2020 All Rights Reserved.
 */
package com.alipay.easysdk.payment.app;

import com.alipay.easysdk.TestAccount;
import com.alipay.easysdk.factory.Factory;
import com.alipay.easysdk.payment.app.models.AlipayTradeAppPayResponse;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import static org.hamcrest.CoreMatchers.containsString;

public class ClientTest {

    @Before
    public void setUp() {
        Factory.setOptions(TestAccount.Mini.CONFIG);
    }

    @Test
    public void testPay() throws Exception {
        AlipayTradeAppPayResponse response = Factory.Payment.App().pay("iPhone6 16G",
                "f4833085-0c46-4bb0-8e5f-622a02a4cffc", "0.10");

        Assert.assertThat(response.body, containsString("app_id=2019022663440152&biz_content=%7B%22"
                + "out_trade_no%22%3A%22f4833085-0c46-4bb0-8e5f-622a02a4cffc%22%2C%22"
                + "total_amount%22%3A%220.10%22%2C%22subject%22%3A%22iPhone6+16G%22%7D&"
                + "charset=UTF-8&format=json&method=alipay.trade.app.pay"
                + "&notify_url=https%3A%2F%2Fwww.test.com%2Fcallback&sign="));
    }
}