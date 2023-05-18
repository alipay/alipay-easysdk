<?php

// This file is auto-generated, don't edit it. Thanks.
namespace Alipay\EasySDK\Util\Generic;

use Alipay\EasySDK\Kernel\EasySDKKernel;
use AlibabaCloud\Tea\Tea;
use AlibabaCloud\Tea\Request;
use AlibabaCloud\Tea\Exception\TeaError;
use \Exception;
use AlibabaCloud\Tea\Exception\TeaUnableRetryError;

use Alipay\EasySDK\Util\Generic\Models\AlipayOpenApiGenericResponse;
use AlibabaCloud\Tea\Response;
use Alipay\EasySDK\Util\Generic\Models\AlipayOpenApiGenericSDKResponse;

class Client {
    protected $_kernel;

    public function __construct($kernel){
        $this->_kernel = $kernel;
    }

    /**
     * @param string $method
     * @param string[] $textParams
     * @param mixed[] $bizParams
     * @return AlipayOpenApiGenericResponse
     * @throws TeaError
     * @throws Exception
     * @throws TeaUnableRetryError
     */
    public function execute($method, $textParams, $bizParams){
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
                    "method" => $method,
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
                $respMap = $this->_kernel->readAsJson($_response, $method);
                if ($this->_kernel->isCertMode()) {
                    if ($this->_kernel->verify($respMap, $this->_kernel->extractAlipayPublicKey($this->_kernel->getAlipayCertSN($respMap)))) {
                        return AlipayOpenApiGenericResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                else {
                    if ($this->_kernel->verify($respMap, $this->_kernel->getConfig("alipayPublicKey"))) {
                        return AlipayOpenApiGenericResponse::fromMap($this->_kernel->toRespModel($respMap));
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
     * @param string $method
     * @param string[] $textParams
     * @param mixed[] $bizParams
     * @param string[] $fileParams
     * @return AlipayOpenApiGenericResponse
     * @throws TeaError
     * @throws Exception
     * @throws TeaUnableRetryError
     */
    public function fileExecute($method, $textParams, $bizParams, $fileParams){
        $_runtime = [
            "ignoreSSL" => $this->_kernel->getConfig("ignoreSSL"),
            "httpProxy" => $this->_kernel->getConfig("httpProxy"),
            "connectTimeout" => 100000,
            "readTimeout" => 100000,
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
                    "method" => $method,
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
                $boundary = $this->_kernel->getRandomBoundary();
                $_request->protocol = $this->_kernel->getConfig("protocol");
                $_request->method = "POST";
                $_request->pathname = "/gateway.do";
                $_request->headers = [
                    "host" => $this->_kernel->getConfig("gatewayHost"),
                    "content-type" => $this->_kernel->concatStr("multipart/form-data;charset=utf-8;boundary=", $boundary)
                ];
                $_request->query = $this->_kernel->sortMap(Tea::merge([
                    "sign" => $this->_kernel->sign($systemParams, $bizParams, $textParams, $this->_kernel->getConfig("merchantPrivateKey"))
                ], $systemParams, $textParams));
                $_request->body = $this->_kernel->toMultipartRequestBody($textParams, $fileParams, $boundary);
                $_lastRequest = $_request;
                $_response= Tea::send($_request, $_runtime);
                $respMap = $this->_kernel->readAsJson($_response, $method);
                if ($this->_kernel->isCertMode()) {
                    if ($this->_kernel->verify($respMap, $this->_kernel->extractAlipayPublicKey($this->_kernel->getAlipayCertSN($respMap)))) {
                        return AlipayOpenApiGenericResponse::fromMap($this->_kernel->toRespModel($respMap));
                    }
                }
                else {
                    if ($this->_kernel->verify($respMap, $this->_kernel->getConfig("alipayPublicKey"))) {
                        return AlipayOpenApiGenericResponse::fromMap($this->_kernel->toRespModel($respMap));
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
     * @param string $method
     * @param string[] $textParams
     * @param mixed[] $bizParams
     * @return AlipayOpenApiGenericSDKResponse
     */
    public function sdkExecute($method, $textParams, $bizParams){
        $_request = new Request();
        $systemParams = [
            "method" => $method,
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
        $sign = $this->_kernel->sign($systemParams, $bizParams, $textParams, $this->_kernel->getConfig("merchantPrivateKey"));
        $response = [
            "body" => $this->_kernel->generateOrderString($systemParams, $bizParams, $textParams, $sign)
        ];
        return AlipayOpenApiGenericSDKResponse::fromMap($response);
        $_lastRequest = $_request;
        $_response= Tea::send($_request);
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

    /**
     * 生成页面类请求所需URL或Form表单
     * @param string $method 接口名称，如：ant.merchant.expand.indirect.zft.consult
     * @param array $bizParams 业务参数（OpenAPI中biz_content里的参数）
     * @param array $textParams 公共请求参数（OpenAPI中非biz_content里的参数）
     * @param string $httpMethod 生成的请求类型，GET生成URL, POST生成HTML表单（自动执行表单POST请求）
     * @return object AlipayOpenApiGenericSDKResponse
     */
    public function generatePage($method, $bizParams = [], $textParams = [], $httpMethod = 'POST')
    {
        $systemParams = [
            'method' => $method,
            'app_id' => $this->_kernel->getConfig('appId'),
            'timestamp' => $this->_kernel->getTimestamp(),
            'format' => 'json',
            'version' => '1.0',
            'alipay_sdk' => $this->_kernel->getSdkVersion(),
            'charset' => 'UTF-8',
            'sign_type' => $this->_kernel->getConfig('signType'),
            'app_cert_sn' => $this->_kernel->getMerchantCertSN(),
            'alipay_root_cert_sn' => $this->_kernel->getAlipayRootCertSN()
        ];
        $sign = $this->_kernel->sign($systemParams, $bizParams, $textParams, $this->_kernel->getConfig('merchantPrivateKey'));
        $response = ['body' => $this->_kernel->generatePage($httpMethod, $systemParams, $bizParams, $textParams, $sign)];
        return AlipayOpenApiGenericSDKResponse::fromMap($response);
    }

}