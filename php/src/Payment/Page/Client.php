<?php

// This file is auto-generated, don't edit it. Thanks.
namespace Alipay\EasySDK\Payment\Page;

use AlibabaCloud\Tea\Tea;
use AlibabaCloud\Tea\Model;
use AlibabaCloud\Tea\Request;
use AlibabaCloud\Tea\Exception\TeaError;
use AlibabaCloud\Tea\Exception\TeaUnableRetryError;
use Alipay\EasySDK\Kernel\BaseClient;

use Alipay\EasySDK\Payment\Page\Models\AlipayTradePagePayResponse;

class Client extends BaseClient{
    private $_getConfig;
    private $_isCertMode;
    private $_getTimestamp;
    private $_sign;
    private $_getMerchantCertSN;
    private $_getAlipayRootCertSN;
    private $_toUrlEncodedRequestBody;
    private $_readAsJson;
    private $_getAlipayCertSN;
    private $_extractAlipayPublicKey;
    private $_verify;
    private $_toRespModel;
    private $_generatePage;
    private $_getSdkVersion;

    /**
     * @param string $subject
     * @param string $outTradeNo
     * @param string $totalAmount
     * @return AlipayTradePagePayResponse
     * @throws \Exception
     */
    public function pay($subject, $outTradeNo, $totalAmount, $returnUrl){
        $systemParams = [
            "method" => "alipay.trade.page.pay",
            "app_id" => $this->_getConfig("appId"),
            "timestamp" => $this->_getTimestamp(),
            "format" => "json",
            "version" => "1.0",
            "alipay_sdk" => $this->_getSdkVersion(),
            "charset" => "UTF-8",
            "sign_type" => $this->_getConfig("signType"),
            "app_cert_sn" => $this->_getMerchantCertSN(),
            "alipay_root_cert_sn" => $this->_getAlipayRootCertSN()
            ];
        $bizParams = [
            "subject" => $subject,
            "out_trade_no" => $outTradeNo,
            "total_amount" => $totalAmount,
            "product_code" => "FAST_INSTANT_TRADE_PAY"
            ];
        $textParams = [
            "return_url" => $returnUrl
        ];
        $sign = $this->_sign($systemParams, $bizParams, $textParams, $this->_getConfig("merchantPrivateKey"));
        $response = [
            "body" => $this->_generatePage("POST", $systemParams, $bizParams, $textParams, $sign)
            ];
        return Model::toModel($response, new AlipayTradePagePayResponse());
    }
}
