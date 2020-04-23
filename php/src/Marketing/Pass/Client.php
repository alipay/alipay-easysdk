<?php

// This file is auto-generated, don't edit it. Thanks.
namespace Alipay\EasySDK\Marketing\Pass;

use AlibabaCloud\Tea\Tea;
use AlibabaCloud\Tea\Model;
use AlibabaCloud\Tea\Request;
use AlibabaCloud\Tea\Exception\TeaError;
use AlibabaCloud\Tea\Exception\TeaUnableRetryError;
use Alipay\EasySDK\Kernel\BaseClient;

use Alipay\EasySDK\Marketing\Pass\Models\AlipayPassTemplateAddResponse;
use Alipay\EasySDK\Marketing\Pass\Models\AlipayPassTemplateUpdateResponse;
use Alipay\EasySDK\Marketing\Pass\Models\AlipayPassInstanceAddResponse;
use Alipay\EasySDK\Marketing\Pass\Models\AlipayPassInstanceUpdateResponse;

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
    private $_getSdkVersion;

    /**
     * @param string $uniqueId
     * @param string $tplContent
     * @return AlipayPassTemplateAddResponse
     * @throws \Exception
     */
    public function createTemplate($uniqueId, $tplContent){
        $_runtime = [
            "connectTimeout" => 15000,
            "readTimeout" => 15000,
            "retry" => [
                "maxAttempts" => 0
                ]
            ];
        $_lastRequest = null;
        $_lastException = null;
        $_now = time();
        $_retryTimes = 0;
        while (Tea::allowRetry($_runtime["retry"], $_retryTimes, $_now)) {
            if ($_retryTimes > 0) {
                $_backoffTime = Tea::getBackoffTime($_runtime["backoff"], $_retryTimes);
                if ($_backoffTime > 0) {
                    Tea::sleep($_backoffTime);
                }
            }
            $_retryTimes = $_retryTimes + 1;
            try {
                $_request = new Request();
                $systemParams = [
                    "method" => "alipay.pass.template.add",
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
                    "unique_id" => $uniqueId,
                    "tpl_content" => $tplContent
                    ];
                $textParams = [];
                $_request->protocol = $this->_getConfig("protocol");
                $_request->method = "POST";
                $_request->pathname = "/gateway.do";
                $_request->headers = [
                    "host" => $this->_getConfig("gatewayHost"),
                    "content-type" => "application/x-www-form-urlencoded;charset=utf-8"
                    ];
                $_request->query = Tea::merge([
                    "sign" => $this->_sign($systemParams, $bizParams, $textParams, $this->_getConfig("merchantPrivateKey"))
                    ], $systemParams,
                    $textParams);
                $_request->body = $this->_toUrlEncodedRequestBody($bizParams);
                $_lastRequest = $_request;
                $_response= Tea::send($_request, $_runtime);
                $respMap = $this->_readAsJson($_response, "alipay.pass.template.add");
                if ($this->_isCertMode()) {
                    if ($this->_verify($respMap, $this->_extractAlipayPublicKey($this->_getAlipayCertSN($respMap)))) {
                        return Model::toModel($this->_toRespModel($respMap), new AlipayPassTemplateAddResponse());
                    }
                }
                else {
                    if ($this->_verify($respMap, $this->_getConfig("alipayPublicKey"))) {
                        return Model::toModel($this->_toRespModel($respMap), new AlipayPassTemplateAddResponse());
                    }
                }
                throw new TeaError([
                    "message" => "验签失败，请检查支付宝公钥设置是否正确。"
                    ]);
            }
            catch (\Exception $e) {
                if (Tea::isRetryable($e)) {
                    $_lastException = $e;
                    continue;
                }
                throw $e;
            }
        }
        throw new TeaUnableRetryError($_lastRequest, $_lastException);
    }

    /**
     * @param string $tplId
     * @param string $tplContent
     * @return AlipayPassTemplateUpdateResponse
     * @throws \Exception
     */
    public function updateTemplate($tplId, $tplContent){
        $_runtime = [
            "connectTimeout" => 15000,
            "readTimeout" => 15000,
            "retry" => [
                "maxAttempts" => 0
                ]
            ];
        $_lastRequest = null;
        $_lastException = null;
        $_now = time();
        $_retryTimes = 0;
        while (Tea::allowRetry($_runtime["retry"], $_retryTimes, $_now)) {
            if ($_retryTimes > 0) {
                $_backoffTime = Tea::getBackoffTime($_runtime["backoff"], $_retryTimes);
                if ($_backoffTime > 0) {
                    Tea::sleep($_backoffTime);
                }
            }
            $_retryTimes = $_retryTimes + 1;
            try {
                $_request = new Request();
                $systemParams = [
                    "method" => "alipay.pass.template.update",
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
                    "tpl_id" => $tplId,
                    "tpl_content" => $tplContent
                    ];
                $textParams = [];
                $_request->protocol = $this->_getConfig("protocol");
                $_request->method = "POST";
                $_request->pathname = "/gateway.do";
                $_request->headers = [
                    "host" => $this->_getConfig("gatewayHost"),
                    "content-type" => "application/x-www-form-urlencoded;charset=utf-8"
                    ];
                $_request->query = Tea::merge([
                    "sign" => $this->_sign($systemParams, $bizParams, $textParams, $this->_getConfig("merchantPrivateKey"))
                    ], $systemParams,
                    $textParams);
                $_request->body = $this->_toUrlEncodedRequestBody($bizParams);
                $_lastRequest = $_request;
                $_response= Tea::send($_request, $_runtime);
                $respMap = $this->_readAsJson($_response, "alipay.pass.template.update");
                if ($this->_isCertMode()) {
                    if ($this->_verify($respMap, $this->_extractAlipayPublicKey($this->_getAlipayCertSN($respMap)))) {
                        return Model::toModel($this->_toRespModel($respMap), new AlipayPassTemplateUpdateResponse());
                    }
                }
                else {
                    if ($this->_verify($respMap, $this->_getConfig("alipayPublicKey"))) {
                        return Model::toModel($this->_toRespModel($respMap), new AlipayPassTemplateUpdateResponse());
                    }
                }
                throw new TeaError([
                    "message" => "验签失败，请检查支付宝公钥设置是否正确。"
                    ]);
            }
            catch (\Exception $e) {
                if (Tea::isRetryable($e)) {
                    $_lastException = $e;
                    continue;
                }
                throw $e;
            }
        }
        throw new TeaUnableRetryError($_lastRequest, $_lastException);
    }

    /**
     * @param string $tplId
     * @param string $tplParams
     * @param string $recognitionType
     * @param string $recognitionInfo
     * @return AlipayPassInstanceAddResponse
     * @throws \Exception
     */
    public function addInstance($tplId, $tplParams, $recognitionType, $recognitionInfo){
        $_runtime = [
            "connectTimeout" => 15000,
            "readTimeout" => 15000,
            "retry" => [
                "maxAttempts" => 0
                ]
            ];
        $_lastRequest = null;
        $_lastException = null;
        $_now = time();
        $_retryTimes = 0;
        while (Tea::allowRetry($_runtime["retry"], $_retryTimes, $_now)) {
            if ($_retryTimes > 0) {
                $_backoffTime = Tea::getBackoffTime($_runtime["backoff"], $_retryTimes);
                if ($_backoffTime > 0) {
                    Tea::sleep($_backoffTime);
                }
            }
            $_retryTimes = $_retryTimes + 1;
            try {
                $_request = new Request();
                $systemParams = [
                    "method" => "alipay.pass.instance.add",
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
                    "tpl_id" => $tplId,
                    "tpl_params" => $tplParams,
                    "recognition_type" => $recognitionType,
                    "recognition_info" => $recognitionInfo
                    ];
                $textParams = [];
                $_request->protocol = $this->_getConfig("protocol");
                $_request->method = "POST";
                $_request->pathname = "/gateway.do";
                $_request->headers = [
                    "host" => $this->_getConfig("gatewayHost"),
                    "content-type" => "application/x-www-form-urlencoded;charset=utf-8"
                    ];
                $_request->query = Tea::merge([
                    "sign" => $this->_sign($systemParams, $bizParams, $textParams, $this->_getConfig("merchantPrivateKey"))
                    ], $systemParams,
                    $textParams);
                $_request->body = $this->_toUrlEncodedRequestBody($bizParams);
                $_lastRequest = $_request;
                $_response= Tea::send($_request, $_runtime);
                $respMap = $this->_readAsJson($_response, "alipay.pass.instance.add");
                if ($this->_isCertMode()) {
                    if ($this->_verify($respMap, $this->_extractAlipayPublicKey($this->_getAlipayCertSN($respMap)))) {
                        return Model::toModel($this->_toRespModel($respMap), new AlipayPassInstanceAddResponse());
                    }
                }
                else {
                    if ($this->_verify($respMap, $this->_getConfig("alipayPublicKey"))) {
                        return Model::toModel($this->_toRespModel($respMap), new AlipayPassInstanceAddResponse());
                    }
                }
                throw new TeaError([
                    "message" => "验签失败，请检查支付宝公钥设置是否正确。"
                    ]);
            }
            catch (\Exception $e) {
                if (Tea::isRetryable($e)) {
                    $_lastException = $e;
                    continue;
                }
                throw $e;
            }
        }
        throw new TeaUnableRetryError($_lastRequest, $_lastException);
    }

    /**
     * @param string $serialNumber
     * @param string $channelId
     * @param string $tplParams
     * @param string $status
     * @param string $verifyCode
     * @param string $verifyType
     * @return AlipayPassInstanceUpdateResponse
     * @throws \Exception
     */
    public function updateInstance($serialNumber, $channelId, $tplParams, $status, $verifyCode, $verifyType){
        $_runtime = [
            "connectTimeout" => 15000,
            "readTimeout" => 15000,
            "retry" => [
                "maxAttempts" => 0
                ]
            ];
        $_lastRequest = null;
        $_lastException = null;
        $_now = time();
        $_retryTimes = 0;
        while (Tea::allowRetry($_runtime["retry"], $_retryTimes, $_now)) {
            if ($_retryTimes > 0) {
                $_backoffTime = Tea::getBackoffTime($_runtime["backoff"], $_retryTimes);
                if ($_backoffTime > 0) {
                    Tea::sleep($_backoffTime);
                }
            }
            $_retryTimes = $_retryTimes + 1;
            try {
                $_request = new Request();
                $systemParams = [
                    "method" => "alipay.pass.instance.update",
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
                    "serial_number" => $serialNumber,
                    "channel_id" => $channelId,
                    "tpl_params" => $tplParams,
                    "status" => $status,
                    "verify_code" => $verifyCode,
                    "verify_type" => $verifyType
                    ];
                $textParams = [];
                $_request->protocol = $this->_getConfig("protocol");
                $_request->method = "POST";
                $_request->pathname = "/gateway.do";
                $_request->headers = [
                    "host" => $this->_getConfig("gatewayHost"),
                    "content-type" => "application/x-www-form-urlencoded;charset=utf-8"
                    ];
                $_request->query = Tea::merge([
                    "sign" => $this->_sign($systemParams, $bizParams, $textParams, $this->_getConfig("merchantPrivateKey"))
                    ], $systemParams,
                    $textParams);
                $_request->body = $this->_toUrlEncodedRequestBody($bizParams);
                $_lastRequest = $_request;
                $_response= Tea::send($_request, $_runtime);
                $respMap = $this->_readAsJson($_response, "alipay.pass.instance.update");
                if ($this->_isCertMode()) {
                    if ($this->_verify($respMap, $this->_extractAlipayPublicKey($this->_getAlipayCertSN($respMap)))) {
                        return Model::toModel($this->_toRespModel($respMap), new AlipayPassInstanceUpdateResponse());
                    }
                }
                else {
                    if ($this->_verify($respMap, $this->_getConfig("alipayPublicKey"))) {
                        return Model::toModel($this->_toRespModel($respMap), new AlipayPassInstanceUpdateResponse());
                    }
                }
                throw new TeaError([
                    "message" => "验签失败，请检查支付宝公钥设置是否正确。"
                    ]);
            }
            catch (\Exception $e) {
                if (Tea::isRetryable($e)) {
                    $_lastException = $e;
                    continue;
                }
                throw $e;
            }
        }
        throw new TeaUnableRetryError($_lastRequest, $_lastException);
    }
}
