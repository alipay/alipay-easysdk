<?php

// This file is auto-generated, don't edit it. Thanks.
namespace Alipay\EasySDK\Payment\App;

use AlibabaCloud\Tea\Tea;
use AlibabaCloud\Tea\Model;
use AlibabaCloud\Tea\Request;
use AlibabaCloud\Tea\Exception\TeaError;
use AlibabaCloud\Tea\Exception\TeaUnableRetryError;
use Alipay\EasySDK\Kernel\BaseClient;

use Alipay\EasySDK\Payment\App\Models\AlipayTradeAppPayResponse;

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
    private $_generateOrderString;
    private $_getSdkVersion;

    /**
     * @param string $subject
     * @param string $outTradeNo
     * @param string $totalAmount
     * @return AlipayTradeAppPayResponse
     * @throws \Exception
     */
    public function pay($subject, $outTradeNo, $totalAmount){
        $systemParams = [
            "method" => "alipay.trade.app.pay",
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
            "total_amount" => $totalAmount
            ];
        $textParams = [];
        $sign = $this->_sign($systemParams, $bizParams, $textParams, $this->_getConfig("merchantPrivateKey"));
        $response = [
            "body" => $this->_generateOrderString($systemParams, $bizParams, $textParams, $sign)
            ];
        return Model::toModel($response, new AlipayTradeAppPayResponse());
    }
}
