/**
 * Alipay.com Inc.
 * Copyright (c) 2004-2020 All Rights Reserved.
 */
package com.alipay.easysdk.factory;

import com.alipay.easysdk.kernel.AlipayConstants;
import com.alipay.easysdk.kernel.Client;
import com.alipay.easysdk.kernel.Config;
import com.alipay.easysdk.kernel.Context;
import com.alipay.easysdk.kms.aliyun.AliyunKMSClient;
import com.alipay.easysdk.kms.aliyun.AliyunKMSSigner;
import com.aliyun.tea.TeaModel;

/**
 * @author junying
 * @version : MultipleFactory.java, v 0.1 2020年12月23日 2:14 下午 junying Exp $
 */
public class MultipleFactory {

    public final String SDK_VERSION = "alipay-easysdk-java-2.2.3";

    /**
     * 将一些初始化耗时较多的信息缓存在上下文中
     */
    public Context context;

    /**
     * 设置客户端参数，只需设置一次，即可反复使用各种场景下的API Client
     *
     * @param options 客户端参数对象
     */
    public void setOptions(Config options) {
        try {
            context = new Context(options, SDK_VERSION);

            if (AlipayConstants.AliyunKMS.equals(context.getConfig(AlipayConstants.SIGN_PROVIDER_CONFIG_KEY))) {
                context.setSigner(new AliyunKMSSigner(new AliyunKMSClient(TeaModel.buildMap(options))));
            }

        } catch (Exception e) {
            throw new RuntimeException(e.getMessage(), e);
        }
    }

    /**
     * 获取支付通用API Client
     *
     * @return 支付通用API Client
     */
    public com.alipay.easysdk.payment.common.Client Common() throws Exception {
        return new com.alipay.easysdk.payment.common.Client(new Client(context));
    }

    /**
     * 获取花呗相关API Client
     *
     * @return 花呗相关API Client
     */
    public com.alipay.easysdk.payment.huabei.Client Huabei() throws Exception {
        return new com.alipay.easysdk.payment.huabei.Client(new Client(context));
    }

    /**
     * 获取当面付相关API Client
     *
     * @return 当面付相关API Client
     */
    public com.alipay.easysdk.payment.facetoface.Client FaceToFace() throws Exception {
        return new com.alipay.easysdk.payment.facetoface.Client(new Client(context));
    }

    /**
     * 获取电脑网站支付相关API Client
     *
     * @return 电脑网站支付相关API Client
     */
    public com.alipay.easysdk.payment.page.Client Page() throws Exception {
        return new com.alipay.easysdk.payment.page.Client(new Client(context));
    }

    /**
     * 获取手机网站支付相关API Client
     *
     * @return 手机网站支付相关API Client
     */
    public com.alipay.easysdk.payment.wap.Client Wap() throws Exception {
        return new com.alipay.easysdk.payment.wap.Client(new Client(context));
    }

    /**
     * 获取手机APP支付相关API Client
     *
     * @return 手机APP支付相关API Client
     */
    public com.alipay.easysdk.payment.app.Client App() throws Exception {
        return new com.alipay.easysdk.payment.app.Client(new Client(context));
    }


    /**
     * 获取图片相关API Client
     *
     * @return 图片相关API Client
     */
    public com.alipay.easysdk.base.image.Client Image() throws Exception {
        return new com.alipay.easysdk.base.image.Client(new Client(context));
    }

    /**
     * 获取视频相关API Client
     *
     * @return 视频相关API Client
     */
    public com.alipay.easysdk.base.video.Client Video() throws Exception {
        return new com.alipay.easysdk.base.video.Client(new Client(context));
    }

    /**
     * 获取OAuth认证相关API Client
     *
     * @return OAuth认证相关API Client
     */
    public com.alipay.easysdk.base.oauth.Client OAuth() throws Exception {
        return new com.alipay.easysdk.base.oauth.Client(new Client(context));
    }

    /**
     * 获取小程序二维码相关API Client
     *
     * @return 小程序二维码相关API Client
     */
    public com.alipay.easysdk.base.qrcode.Client Qrcode() throws Exception {
        return new com.alipay.easysdk.base.qrcode.Client(new Client(context));
    }


    /**
     * 获取生活号相关API Client
     *
     * @return 生活号相关API Client
     */
    public com.alipay.easysdk.marketing.openlife.Client OpenLife() throws Exception {
        return new com.alipay.easysdk.marketing.openlife.Client(new Client(context));
    }

    /**
     * 获取支付宝卡包相关API Client
     *
     * @return 支付宝卡包相关API Client
     */
    public com.alipay.easysdk.marketing.pass.Client Pass() throws Exception {
        return new com.alipay.easysdk.marketing.pass.Client(new Client(context));
    }

    /**
     * 获取小程序模板消息相关API Client
     *
     * @return 小程序模板消息相关API Client
     */
    public com.alipay.easysdk.marketing.templatemessage.Client TemplateMessage() throws Exception {
        return new com.alipay.easysdk.marketing.templatemessage.Client(new Client(context));
    }


    /**
     * 获取支付宝身份认证相关API Client
     *
     * @return 支付宝身份认证相关API Client
     */
    public com.alipay.easysdk.member.identification.Client Identification() throws Exception {
        return new com.alipay.easysdk.member.identification.Client(new Client(context));
    }

    /**
     * 获取文本风险识别相关API Client
     *
     * @return 文本风险识别相关API Client
     */
    public com.alipay.easysdk.security.textrisk.Client TextRisk() throws Exception {
        return new com.alipay.easysdk.security.textrisk.Client(new Client(context));
    }

    /**
     * 获取OpenAPI通用接口，可通过自行拼装参数，调用几乎所有OpenAPI
     *
     * @return OpenAPI通用接口
     */
    public com.alipay.easysdk.util.generic.Client Generic() throws Exception {
        return new com.alipay.easysdk.util.generic.Client(new Client(context));
    }

    /**
     * 获取AES128加解密相关API Client，常用于会员手机号的解密
     *
     * @return AES128加解密相关API Client
     */
    public com.alipay.easysdk.util.aes.Client AES() throws Exception {
        return new com.alipay.easysdk.util.aes.Client(new Client(context));
    }
}