<?php

// This file is auto-generated, don't edit it. Thanks.
namespace Alipay\EasySDK\Payment\Common;

use Alipay\EasySDK\Kernel\EasySDKKernel;
use AlibabaCloud\Tea\Tea;
use AlibabaCloud\Tea\Request;
use AlibabaCloud\Tea\Exception\TeaError;
use \Exception;
use AlibabaCloud\Tea\Exception\TeaUnableRetryError;

use Alipay\EasySDK\Payment\Common\Models\AlipayTradeCreateResponse;
use AlibabaCloud\Tea\Response;
use Alipay\EasySDK\Payment\Common\Models\AlipayTradeQueryResponse;
use Alipay\EasySDK\Payment\Common\Models\AlipayTradeRefundResponse;
use Alipay\EasySDK\Payment\Common\Models\AlipayTradeCloseResponse;
use Alipay\EasySDK\Payment\Common\Models\AlipayTradeCancelResponse;
use Alipay\EasySDK\Payment\Common\Models\AlipayTradeFastpayRefundQueryResponse;
use Alipay\EasySDK\Payment\Common\Models\AlipayDataDataserviceBillDownloadurlQueryResponse;

class Client {
    protected $_kernel;

    public function __construct($kernel){
        $this->_kernel = $kernel;
    }

    /**
     * @param string $subject
     * @param string $outTradeNo
     * @param string $totalAmount
     * @param string $buyerId
     * @return AlipayTradeCreateResponse
     * @throws TeaError
     * @throws Exception
     * @throws TeaUnableRetryError
     */
    public function create($subject, $outTradeNo, $totalAmount, $buyerId, $productCode = null){
        $_runtime = [
            "ignoreSSL" => $this->_kernel->getConfig("ignoreSSL"),
            "httpProxy" => $this->_kernel->getConfig("httpProxy"),
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
        while (Tea::allowRetry(@$_runtime["retry"], $_retryTimes, $_now)) {
            if ($_retryTimes > 0) {
                $_backoffTime = Tea::getBackoffTime(@$_runtime["backoff"], $_retryTimes);
                if ($_backoffTime > 0) {
                    Tea::sleep($_backoffTime);
                }
            }
            $_retryTimes = $_retryTimes + 1;
            try {
                $_request = new Request();
                $systemParams = [
                    "method" => "alipay.trade.create",
                    "app_id" => $this->_kernel->getConfig("appId"),
                    "timestamp" => $this->_kernel->getTimestamp(),
                    "format" => "json",
                    "version" => "1.0",
                    "alipay_sdk" => $this->_kernel->getSdkVersion(),
                    "charset" => "UTF-8",
                    "sign_type" => $this->_kernel->getConfig("signType"),
                    "app_cert_sn" => $this->_kernel->getMerchantCertSN(),
                    "alipay_root_cert_sn" => $this->_kernel->getAlipayRootCertSN()
                ];
                $bizParams = [
                    "subject" => $subject,
                    "out_trade_no" => $outTradeNo,
                    "total_amount" => $totalAmount,
                    "buyer_id" => $buyerId
		];
		if ($productCode) {
                    $bizParams['product_code'] = $productCode;
                }

                $textParams = [];
                $_request->protocol = $this->_kernel->getConfig("protocol");
                $_request->method = "POST";
                $_request->pathname = "/gateway.do";
                $_request->headers = [
                    "host" => $this->_kernel->getConfig("gatewayHost"),
                    "content-type" => "application/x-www-form-urlencoded;charset=utf-8"
                ];
                $_request->query = $this->_kernel->sortMap(Tea::merge([
                    "sign" => $this->_kernel->sign($systemParams, $bizParams, $textParams, $this->_kernel->getConfig("merchantPrivateKey"))
                ], $systemParams, $textParams));
                $_request->body = $this->_kernel->toUrlEncodedRequestBody($bizParams);
                $_lastRequest = $_request;
                $_response= Tea::send($_request, $_runtime);
                $respMap = $this->_kernel->readAsJson($_response, "alipay.trade.create");
                if ($this->_kernel->isCertMode()) {
                    if ($this->_kernel->verify($respMap, $this->_kernel->extractAlipayPublicKey($this->_kernel->getAlipayCertSN($respMap)))) {
                        return AlipayTradeCreateResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                else {
                    if ($this->_kernel->verify($respMap, $this->_kernel->getConfig("alipayPublicKey"))) {
                        return AlipayTradeCreateResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                throw new TeaError([
                    "message" => "验签失败，请检查支付宝公钥设置是否正确。"
                ]);
            }
            catch (Exception $e) {
                if (!($e instanceof TeaError)) {
                    $e = new TeaError([], $e->getMessage(), $e->getCode(), $e);
                }
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
     * @param string $outTradeNo
     * @return AlipayTradeQueryResponse
     * @throws TeaError
     * @throws Exception
     * @throws TeaUnableRetryError
     */
    public function query($outTradeNo){
        $_runtime = [
            "ignoreSSL" => $this->_kernel->getConfig("ignoreSSL"),
            "httpProxy" => $this->_kernel->getConfig("httpProxy"),
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
        while (Tea::allowRetry(@$_runtime["retry"], $_retryTimes, $_now)) {
            if ($_retryTimes > 0) {
                $_backoffTime = Tea::getBackoffTime(@$_runtime["backoff"], $_retryTimes);
                if ($_backoffTime > 0) {
                    Tea::sleep($_backoffTime);
                }
            }
            $_retryTimes = $_retryTimes + 1;
            try {
                $_request = new Request();
                $systemParams = [
                    "method" => "alipay.trade.query",
                    "app_id" => $this->_kernel->getConfig("appId"),
                    "timestamp" => $this->_kernel->getTimestamp(),
                    "format" => "json",
                    "version" => "1.0",
                    "alipay_sdk" => $this->_kernel->getSdkVersion(),
                    "charset" => "UTF-8",
                    "sign_type" => $this->_kernel->getConfig("signType"),
                    "app_cert_sn" => $this->_kernel->getMerchantCertSN(),
                    "alipay_root_cert_sn" => $this->_kernel->getAlipayRootCertSN()
                ];
                $bizParams = [
                    "out_trade_no" => $outTradeNo
                ];
                $textParams = [];
                $_request->protocol = $this->_kernel->getConfig("protocol");
                $_request->method = "POST";
                $_request->pathname = "/gateway.do";
                $_request->headers = [
                    "host" => $this->_kernel->getConfig("gatewayHost"),
                    "content-type" => "application/x-www-form-urlencoded;charset=utf-8"
                ];
                $_request->query = $this->_kernel->sortMap(Tea::merge([
                    "sign" => $this->_kernel->sign($systemParams, $bizParams, $textParams, $this->_kernel->getConfig("merchantPrivateKey"))
                ], $systemParams, $textParams));
                $_request->body = $this->_kernel->toUrlEncodedRequestBody($bizParams);
                $_lastRequest = $_request;
                $_response= Tea::send($_request, $_runtime);
                $respMap = $this->_kernel->readAsJson($_response, "alipay.trade.query");
                if ($this->_kernel->isCertMode()) {
                    if ($this->_kernel->verify($respMap, $this->_kernel->extractAlipayPublicKey($this->_kernel->getAlipayCertSN($respMap)))) {
                        return AlipayTradeQueryResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                else {
                    if ($this->_kernel->verify($respMap, $this->_kernel->getConfig("alipayPublicKey"))) {
                        return AlipayTradeQueryResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                throw new TeaError([
                    "message" => "验签失败，请检查支付宝公钥设置是否正确。"
                ]);
            }
            catch (Exception $e) {
                if (!($e instanceof TeaError)) {
                    $e = new TeaError([], $e->getMessage(), $e->getCode(), $e);
                }
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
     * @param string $outTradeNo
     * @param string $refundAmount
     * @return AlipayTradeRefundResponse
     * @throws TeaError
     * @throws Exception
     * @throws TeaUnableRetryError
     */
    public function refund($outTradeNo, $refundAmount){
        $_runtime = [
            "ignoreSSL" => $this->_kernel->getConfig("ignoreSSL"),
            "httpProxy" => $this->_kernel->getConfig("httpProxy"),
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
        while (Tea::allowRetry(@$_runtime["retry"], $_retryTimes, $_now)) {
            if ($_retryTimes > 0) {
                $_backoffTime = Tea::getBackoffTime(@$_runtime["backoff"], $_retryTimes);
                if ($_backoffTime > 0) {
                    Tea::sleep($_backoffTime);
                }
            }
            $_retryTimes = $_retryTimes + 1;
            try {
                $_request = new Request();
                $systemParams = [
                    "method" => "alipay.trade.refund",
                    "app_id" => $this->_kernel->getConfig("appId"),
                    "timestamp" => $this->_kernel->getTimestamp(),
                    "format" => "json",
                    "version" => "1.0",
                    "alipay_sdk" => $this->_kernel->getSdkVersion(),
                    "charset" => "UTF-8",
                    "sign_type" => $this->_kernel->getConfig("signType"),
                    "app_cert_sn" => $this->_kernel->getMerchantCertSN(),
                    "alipay_root_cert_sn" => $this->_kernel->getAlipayRootCertSN()
                ];
                $bizParams = [
                    "out_trade_no" => $outTradeNo,
                    "refund_amount" => $refundAmount
                ];
                $textParams = [];
                $_request->protocol = $this->_kernel->getConfig("protocol");
                $_request->method = "POST";
                $_request->pathname = "/gateway.do";
                $_request->headers = [
                    "host" => $this->_kernel->getConfig("gatewayHost"),
                    "content-type" => "application/x-www-form-urlencoded;charset=utf-8"
                ];
                $_request->query = $this->_kernel->sortMap(Tea::merge([
                    "sign" => $this->_kernel->sign($systemParams, $bizParams, $textParams, $this->_kernel->getConfig("merchantPrivateKey"))
                ], $systemParams, $textParams));
                $_request->body = $this->_kernel->toUrlEncodedRequestBody($bizParams);
                $_lastRequest = $_request;
                $_response= Tea::send($_request, $_runtime);
                $respMap = $this->_kernel->readAsJson($_response, "alipay.trade.refund");
                if ($this->_kernel->isCertMode()) {
                    if ($this->_kernel->verify($respMap, $this->_kernel->extractAlipayPublicKey($this->_kernel->getAlipayCertSN($respMap)))) {
                        return AlipayTradeRefundResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                else {
                    if ($this->_kernel->verify($respMap, $this->_kernel->getConfig("alipayPublicKey"))) {
                        return AlipayTradeRefundResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                throw new TeaError([
                    "message" => "验签失败，请检查支付宝公钥设置是否正确。"
                ]);
            }
            catch (Exception $e) {
                if (!($e instanceof TeaError)) {
                    $e = new TeaError([], $e->getMessage(), $e->getCode(), $e);
                }
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
     * @param string $outTradeNo
     * @return AlipayTradeCloseResponse
     * @throws TeaError
     * @throws Exception
     * @throws TeaUnableRetryError
     */
    public function close($outTradeNo){
        $_runtime = [
            "ignoreSSL" => $this->_kernel->getConfig("ignoreSSL"),
            "httpProxy" => $this->_kernel->getConfig("httpProxy"),
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
        while (Tea::allowRetry(@$_runtime["retry"], $_retryTimes, $_now)) {
            if ($_retryTimes > 0) {
                $_backoffTime = Tea::getBackoffTime(@$_runtime["backoff"], $_retryTimes);
                if ($_backoffTime > 0) {
                    Tea::sleep($_backoffTime);
                }
            }
            $_retryTimes = $_retryTimes + 1;
            try {
                $_request = new Request();
                $systemParams = [
                    "method" => "alipay.trade.close",
                    "app_id" => $this->_kernel->getConfig("appId"),
                    "timestamp" => $this->_kernel->getTimestamp(),
                    "format" => "json",
                    "version" => "1.0",
                    "alipay_sdk" => $this->_kernel->getSdkVersion(),
                    "charset" => "UTF-8",
                    "sign_type" => $this->_kernel->getConfig("signType"),
                    "app_cert_sn" => $this->_kernel->getMerchantCertSN(),
                    "alipay_root_cert_sn" => $this->_kernel->getAlipayRootCertSN()
                ];
                $bizParams = [
                    "out_trade_no" => $outTradeNo
                ];
                $textParams = [];
                $_request->protocol = $this->_kernel->getConfig("protocol");
                $_request->method = "POST";
                $_request->pathname = "/gateway.do";
                $_request->headers = [
                    "host" => $this->_kernel->getConfig("gatewayHost"),
                    "content-type" => "application/x-www-form-urlencoded;charset=utf-8"
                ];
                $_request->query = $this->_kernel->sortMap(Tea::merge([
                    "sign" => $this->_kernel->sign($systemParams, $bizParams, $textParams, $this->_kernel->getConfig("merchantPrivateKey"))
                ], $systemParams, $textParams));
                $_request->body = $this->_kernel->toUrlEncodedRequestBody($bizParams);
                $_lastRequest = $_request;
                $_response= Tea::send($_request, $_runtime);
                $respMap = $this->_kernel->readAsJson($_response, "alipay.trade.close");
                if ($this->_kernel->isCertMode()) {
                    if ($this->_kernel->verify($respMap, $this->_kernel->extractAlipayPublicKey($this->_kernel->getAlipayCertSN($respMap)))) {
                        return AlipayTradeCloseResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                else {
                    if ($this->_kernel->verify($respMap, $this->_kernel->getConfig("alipayPublicKey"))) {
                        return AlipayTradeCloseResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                throw new TeaError([
                    "message" => "验签失败，请检查支付宝公钥设置是否正确。"
                ]);
            }
            catch (Exception $e) {
                if (!($e instanceof TeaError)) {
                    $e = new TeaError([], $e->getMessage(), $e->getCode(), $e);
                }
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
     * @param string $outTradeNo
     * @return AlipayTradeCancelResponse
     * @throws TeaError
     * @throws Exception
     * @throws TeaUnableRetryError
     */
    public function cancel($outTradeNo){
        $_runtime = [
            "ignoreSSL" => $this->_kernel->getConfig("ignoreSSL"),
            "httpProxy" => $this->_kernel->getConfig("httpProxy"),
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
        while (Tea::allowRetry(@$_runtime["retry"], $_retryTimes, $_now)) {
            if ($_retryTimes > 0) {
                $_backoffTime = Tea::getBackoffTime(@$_runtime["backoff"], $_retryTimes);
                if ($_backoffTime > 0) {
                    Tea::sleep($_backoffTime);
                }
            }
            $_retryTimes = $_retryTimes + 1;
            try {
                $_request = new Request();
                $systemParams = [
                    "method" => "alipay.trade.cancel",
                    "app_id" => $this->_kernel->getConfig("appId"),
                    "timestamp" => $this->_kernel->getTimestamp(),
                    "format" => "json",
                    "version" => "1.0",
                    "alipay_sdk" => $this->_kernel->getSdkVersion(),
                    "charset" => "UTF-8",
                    "sign_type" => $this->_kernel->getConfig("signType"),
                    "app_cert_sn" => $this->_kernel->getMerchantCertSN(),
                    "alipay_root_cert_sn" => $this->_kernel->getAlipayRootCertSN()
                ];
                $bizParams = [
                    "out_trade_no" => $outTradeNo
                ];
                $textParams = [];
                $_request->protocol = $this->_kernel->getConfig("protocol");
                $_request->method = "POST";
                $_request->pathname = "/gateway.do";
                $_request->headers = [
                    "host" => $this->_kernel->getConfig("gatewayHost"),
                    "content-type" => "application/x-www-form-urlencoded;charset=utf-8"
                ];
                $_request->query = $this->_kernel->sortMap(Tea::merge([
                    "sign" => $this->_kernel->sign($systemParams, $bizParams, $textParams, $this->_kernel->getConfig("merchantPrivateKey"))
                ], $systemParams, $textParams));
                $_request->body = $this->_kernel->toUrlEncodedRequestBody($bizParams);
                $_lastRequest = $_request;
                $_response= Tea::send($_request, $_runtime);
                $respMap = $this->_kernel->readAsJson($_response, "alipay.trade.cancel");
                if ($this->_kernel->isCertMode()) {
                    if ($this->_kernel->verify($respMap, $this->_kernel->extractAlipayPublicKey($this->_kernel->getAlipayCertSN($respMap)))) {
                        return AlipayTradeCancelResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                else {
                    if ($this->_kernel->verify($respMap, $this->_kernel->getConfig("alipayPublicKey"))) {
                        return AlipayTradeCancelResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                throw new TeaError([
                    "message" => "验签失败，请检查支付宝公钥设置是否正确。"
                ]);
            }
            catch (Exception $e) {
                if (!($e instanceof TeaError)) {
                    $e = new TeaError([], $e->getMessage(), $e->getCode(), $e);
                }
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
     * @param string $outTradeNo
     * @param string $outRequestNo
     * @return AlipayTradeFastpayRefundQueryResponse
     * @throws TeaError
     * @throws Exception
     * @throws TeaUnableRetryError
     */
    public function queryRefund($outTradeNo, $outRequestNo){
        $_runtime = [
            "ignoreSSL" => $this->_kernel->getConfig("ignoreSSL"),
            "httpProxy" => $this->_kernel->getConfig("httpProxy"),
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
        while (Tea::allowRetry(@$_runtime["retry"], $_retryTimes, $_now)) {
            if ($_retryTimes > 0) {
                $_backoffTime = Tea::getBackoffTime(@$_runtime["backoff"], $_retryTimes);
                if ($_backoffTime > 0) {
                    Tea::sleep($_backoffTime);
                }
            }
            $_retryTimes = $_retryTimes + 1;
            try {
                $_request = new Request();
                $systemParams = [
                    "method" => "alipay.trade.fastpay.refund.query",
                    "app_id" => $this->_kernel->getConfig("appId"),
                    "timestamp" => $this->_kernel->getTimestamp(),
                    "format" => "json",
                    "version" => "1.0",
                    "alipay_sdk" => $this->_kernel->getSdkVersion(),
                    "charset" => "UTF-8",
                    "sign_type" => $this->_kernel->getConfig("signType"),
                    "app_cert_sn" => $this->_kernel->getMerchantCertSN(),
                    "alipay_root_cert_sn" => $this->_kernel->getAlipayRootCertSN()
                ];
                $bizParams = [
                    "out_trade_no" => $outTradeNo,
                    "out_request_no" => $outRequestNo
                ];
                $textParams = [];
                $_request->protocol = $this->_kernel->getConfig("protocol");
                $_request->method = "POST";
                $_request->pathname = "/gateway.do";
                $_request->headers = [
                    "host" => $this->_kernel->getConfig("gatewayHost"),
                    "content-type" => "application/x-www-form-urlencoded;charset=utf-8"
                ];
                $_request->query = $this->_kernel->sortMap(Tea::merge([
                    "sign" => $this->_kernel->sign($systemParams, $bizParams, $textParams, $this->_kernel->getConfig("merchantPrivateKey"))
                ], $systemParams, $textParams));
                $_request->body = $this->_kernel->toUrlEncodedRequestBody($bizParams);
                $_lastRequest = $_request;
                $_response= Tea::send($_request, $_runtime);
                $respMap = $this->_kernel->readAsJson($_response, "alipay.trade.fastpay.refund.query");
                if ($this->_kernel->isCertMode()) {
                    if ($this->_kernel->verify($respMap, $this->_kernel->extractAlipayPublicKey($this->_kernel->getAlipayCertSN($respMap)))) {
                        return AlipayTradeFastpayRefundQueryResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                else {
                    if ($this->_kernel->verify($respMap, $this->_kernel->getConfig("alipayPublicKey"))) {
                        return AlipayTradeFastpayRefundQueryResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                throw new TeaError([
                    "message" => "验签失败，请检查支付宝公钥设置是否正确。"
                ]);
            }
            catch (Exception $e) {
                if (!($e instanceof TeaError)) {
                    $e = new TeaError([], $e->getMessage(), $e->getCode(), $e);
                }
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
     * @param string $billType
     * @param string $billDate
     * @return AlipayDataDataserviceBillDownloadurlQueryResponse
     * @throws TeaError
     * @throws Exception
     * @throws TeaUnableRetryError
     */
    public function downloadBill($billType, $billDate){
        $_runtime = [
            "ignoreSSL" => $this->_kernel->getConfig("ignoreSSL"),
            "httpProxy" => $this->_kernel->getConfig("httpProxy"),
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
        while (Tea::allowRetry(@$_runtime["retry"], $_retryTimes, $_now)) {
            if ($_retryTimes > 0) {
                $_backoffTime = Tea::getBackoffTime(@$_runtime["backoff"], $_retryTimes);
                if ($_backoffTime > 0) {
                    Tea::sleep($_backoffTime);
                }
            }
            $_retryTimes = $_retryTimes + 1;
            try {
                $_request = new Request();
                $systemParams = [
                    "method" => "alipay.data.dataservice.bill.downloadurl.query",
                    "app_id" => $this->_kernel->getConfig("appId"),
                    "timestamp" => $this->_kernel->getTimestamp(),
                    "format" => "json",
                    "version" => "1.0",
                    "alipay_sdk" => $this->_kernel->getSdkVersion(),
                    "charset" => "UTF-8",
                    "sign_type" => $this->_kernel->getConfig("signType"),
                    "app_cert_sn" => $this->_kernel->getMerchantCertSN(),
                    "alipay_root_cert_sn" => $this->_kernel->getAlipayRootCertSN()
                ];
                $bizParams = [
                    "bill_type" => $billType,
                    "bill_date" => $billDate
                ];
                $textParams = [];
                $_request->protocol = $this->_kernel->getConfig("protocol");
                $_request->method = "POST";
                $_request->pathname = "/gateway.do";
                $_request->headers = [
                    "host" => $this->_kernel->getConfig("gatewayHost"),
                    "content-type" => "application/x-www-form-urlencoded;charset=utf-8"
                ];
                $_request->query = $this->_kernel->sortMap(Tea::merge([
                    "sign" => $this->_kernel->sign($systemParams, $bizParams, $textParams, $this->_kernel->getConfig("merchantPrivateKey"))
                ], $systemParams, $textParams));
                $_request->body = $this->_kernel->toUrlEncodedRequestBody($bizParams);
                $_lastRequest = $_request;
                $_response= Tea::send($_request, $_runtime);
                $respMap = $this->_kernel->readAsJson($_response, "alipay.data.dataservice.bill.downloadurl.query");
                if ($this->_kernel->isCertMode()) {
                    if ($this->_kernel->verify($respMap, $this->_kernel->extractAlipayPublicKey($this->_kernel->getAlipayCertSN($respMap)))) {
                        return AlipayDataDataserviceBillDownloadurlQueryResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                else {
                    if ($this->_kernel->verify($respMap, $this->_kernel->getConfig("alipayPublicKey"))) {
                        return AlipayDataDataserviceBillDownloadurlQueryResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                throw new TeaError([
                    "message" => "验签失败，请检查支付宝公钥设置是否正确。"
                ]);
            }
            catch (Exception $e) {
                if (!($e instanceof TeaError)) {
                    $e = new TeaError([], $e->getMessage(), $e->getCode(), $e);
                }
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
     * @param string[] $parameters
     * @return bool
     */
    public function verifyNotify($parameters){
        if ($this->_kernel->isCertMode()) {
            return $this->_kernel->verifyParams($parameters, $this->_kernel->extractAlipayPublicKey(""));
        }
        else {
            return $this->_kernel->verifyParams($parameters, $this->_kernel->getConfig("alipayPublicKey"));
        }
    }

    /**
     * ISV代商户代用，指定appAuthToken
     *
     * @param $appAuthToken String 代调用token
     * @return $this 本客户端，便于链式调用
     */
    public function agent($appAuthToken)
    {
        $this->_kernel->injectTextParam("app_auth_token", $appAuthToken);
        return $this;
    }

    /**
    * 用户授权调用，指定authToken
    *
    * @param $authToken String 用户授权token
    * @return $this
    */
    public function auth($authToken)
    {
        $this->_kernel->injectTextParam("auth_token", $authToken);
        return $this;
    }

    /**
    * 设置异步通知回调地址，此处设置将在本调用中覆盖Config中的全局配置
    *
    * @param $url String 异步通知回调地址，例如：https://www.test.com/callback
    * @return $this
    */
    public function asyncNotify($url)
    {
        $this->_kernel->injectTextParam("notify_url", $url);
        return $this;
    }

    /**
    * 将本次调用强制路由到后端系统的测试地址上，常用于线下环境内外联调，沙箱与线上环境设置无效
    *
    * @param $testUrl String 后端系统测试地址
    * @return $this
    */
    public function route($testUrl)
    {
        $this->_kernel->injectTextParam("ws_service_url", $testUrl);
        return $this;
    }

    /**
    * 设置API入参中没有的其他可选业务请求参数(biz_content下的字段)
    *
    * @param $key   String 业务请求参数名称（biz_content下的字段名，比如timeout_express）
    * @param $value object 业务请求参数的值，一个可以序列化成JSON的对象
    *               如果该字段是一个字符串类型（String、Price、Date在SDK中都是字符串），请使用String储存
    *               如果该字段是一个数值型类型（比如：Number），请使用Long储存
    *               如果该字段是一个复杂类型，请使用嵌套的array指定各下级字段的值
    *               如果该字段是一个数组，请使用array储存各个值
    * @return $this
    */
    public function optional($key, $value)
    {
        $this->_kernel->injectBizParam($key, $value);
        return $this;
    }

    /**
    * 批量设置API入参中没有的其他可选业务请求参数(biz_content下的字段)
    * optional方法的批量版本
    *
    * @param $optionalArgs array 可选参数集合，每个参数由key和value组成，key和value的格式请参见optional方法的注释
    * @return $this
    */
    public function batchOptional($optionalArgs)
    {
        foreach ($optionalArgs as $key => $value) {
            $this->_kernel->injectBizParam($key, $value);
        }
        return $this;
    }

}
