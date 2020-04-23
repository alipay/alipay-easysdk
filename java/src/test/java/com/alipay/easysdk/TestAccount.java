/**
 * Alipay.com Inc. Copyright (c) 2004-2020 All Rights Reserved.
 */
package com.alipay.easysdk;

import com.alipay.easysdk.kernel.BaseClient;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.Map;

/**
 * @author zhongyu
 * @version $Id: TestAccount.java, v 0.1 2020年01月19日 4:42 PM zhongyu Exp $
 */
public class TestAccount {
    /**
     * 从文件中读取私钥
     * <p>
     * 注意：实际开发过程中，请务必注意不要将私钥信息配置在源码中（比如配置为常量或储存在配置文件的某个字段中等），因为私钥的保密等级往往比源码高得多，将会增加私钥泄露的风险。推荐将私钥信息储存在专用的私钥文件中，
     * 将私钥文件通过安全的流程分发到服务器的安全储存区域上，仅供自己的应用运行时读取。
     * <p>
     * 此处为了单元测试执行的环境普适性，私钥文件配置在resources资源下，实际过程中请不要这样做。
     *
     * @param appId 私钥对应的APP_ID
     * @return 私钥字符串
     */
    private static String getPrivateKey(String appId) {
        InputStream stream = TestAccount.class.getResourceAsStream("/fixture/privateKey.json");
        Map<String, String> result = new Gson().fromJson(new InputStreamReader(stream), new TypeToken<Map<String, String>>() {}.getType());
        return result.get(appId);
    }

    /**
     * 线上小程序测试账号
     */
    public static class Mini {
        public static final BaseClient.Config CONFIG = getConfig();

        public static BaseClient.Config getConfig() {
            BaseClient.Config config = new BaseClient.Config();
            config.protocol = "https";
            config.gatewayHost = "openapi.alipay.com";
            config.appId = "<-- 请填写您的AppId，例如：2019022663440152 -->";
            config.signType = "RSA2";

            config.alipayPublicKey = "<-- 请填写您的支付宝公钥，例如：MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAumX1EaLM4ddn1Pia4SxTRb62aVYxU8I2mHMqrc"
                    + "pQU6F01mIO/DjY7R4xUWcLi0I2oH/BK/WhckEDCFsGrT7mO+JX8K4sfaWZx1aDGs0m25wOCNjp+DCVBXotXSCurqgGI/9UrY+"
                    + "QydYDnsl4jB65M3p8VilF93MfS01omEDjUW+1MM4o3FP0khmcKsoHnYGs21btEeh0LK1gnnTDlou6Jwv3Ew36CbCNY2cYkuyP"
                    + "AW0j47XqzhWJ7awAx60fwgNBq6ZOEPJnODqH20TAdTLNxPSl4qGxamjBO+RuInBy+Bc2hFHq3pNv6hTAfktggRKkKzDlDEUwg"
                    + "SLE7d2eL7P6rwIDAQAB --->";
            config.merchantPrivateKey = getPrivateKey(config.appId);
            config.notifyUrl = "<-- 请填写您的异步通知接收服务器地址，例如：https://www.test.com/callback -->";
            return config;
        }
    }

    /**
     * 线上生活号测试账号
     */
    public static class OpenLife {
        public static final BaseClient.Config CONFIG = getConfig();

        private static BaseClient.Config getConfig() {
            BaseClient.Config config = new BaseClient.Config();
            config.protocol = "https";
            config.gatewayHost = "openapi.alipay.com";
            config.appId = "<-- 请填写您的AppId，例如：2019051064521003 -->";
            config.signType = "RSA2";

            config.alipayCertPath = "<-- 请填写您的支付宝公钥证书文件路径，例如：/src/test/resources/fixture/alipayCertPublicKey_RSA2.crt -->";
            config.alipayRootCertPath = "<-- 请填写您的支付宝根证书文件路径，例如：/src/test/resources/fixture/alipayRootCert.crt -->";
            config.merchantCertPath = "<-- 请填写您的应用公钥证书文件路径，例如：/src/test/resources/fixture/appCertPublicKey_2019051064521003.crt -->";
            config.merchantPrivateKey = getPrivateKey(config.appId);
            return config;
        }
    }
}