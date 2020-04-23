<?php

namespace Alipay\EasySDK\Kernel;

use Alipay\EasySDK\Base\Image\Client as imageClient;
use Alipay\EasySDK\Base\OAuth\Client as oauthClient;
use Alipay\EasySDK\Base\Qrcode\Client as qrcodeClient;
use Alipay\EasySDK\Base\Video\Client as videoClient;
use Alipay\EasySDK\Marketing\OpenLife\Client as openLifeClient;
use Alipay\EasySDK\Marketing\Pass\Client as passClient;
use Alipay\EasySDK\Marketing\TemplateMessage\Client as templateMessageClient;
use Alipay\EasySDK\Member\Identification\Client as identificationClient;
use Alipay\EasySDK\Payment\App\Client as appClient;
use Alipay\EasySDK\Payment\Common\Client as commonClient;
use Alipay\EasySDK\Payment\FaceToFace\Client as faceToFaceClient;
use Alipay\EasySDK\Payment\Huabei\Client as huabeiClient;
use Alipay\EasySDK\Payment\Page\Client as pageClient;
use Alipay\EasySDK\Payment\Wap\Client as wapClient;
use Alipay\EasySDK\Security\TextRisk\Client as textRiskClient;
use Alipay\EasySDK\Util\Generic\Client as genericClient;
use Alipay\EasySDK\Util\AES\Client as aesClient;

class Factory
{
    public $config = null;
    private static $instance;
    protected static $base;
    protected static $marketing;
    protected static $member;
    protected static $payment;
    protected static $security;
    protected static $util;

    private function __construct($config)
    {
        if (!empty($config->alipayCertPath)) {
            $certEnvironment = new CertEnvironment();
            $certEnvironment->certEnvironment(
                $config->merchantCertPath,
                $config->alipayCertPath,
                $config->alipayRootCertPath
            );
            $config->merchantCertSN = $certEnvironment->getMerchantCertSN();
            $config->alipayRootCertSN = $certEnvironment->getRootCertSN();
            $config->alipayPublicKey = $certEnvironment->getCachedAlipayPublicKey();
        }

        self::$base = new Base($config);
        self::$marketing = new Marketing($config);
        self::$member = new Member($config);
        self::$payment = new Payment($config);
        self::$security = new Security($config);
        self::$util = new Util($config);
    }

    public static function setOptions($config)
    {
        if (!(self::$instance instanceof self)) {
            self::$instance = new self($config);
        }
        return self::$instance;
    }

    private function __clone()
    {
    }

    public static function base()
    {
        return self::$base;
    }

    public static function marketing()
    {
        return self::$marketing;
    }

    public static function member()
    {
        return self::$member;
    }

    public static function payment()
    {
        return self::$payment;
    }

    public static function security()
    {
        return self::$security;
    }

    public static function util()
    {
        return self::$util;
    }
}


class Base
{
    private $config;

    public function __construct($config)
    {
        $this->config = $config;
    }

    public function image()
    {
        return new imageClient($this->config);
    }

    public function oauth()
    {
        return new oauthClient($this->config);
    }

    public function qrcode()
    {
        return new qrcodeClient($this->config);
    }

    public function video()
    {
        return new videoClient($this->config);
    }
}

class Marketing
{
    private $config;

    public function __construct($config)
    {
        $this->config = $config;
    }

    public function openLife()
    {
        return new openLifeClient($this->config);
    }

    public function pass()
    {
        return new passClient($this->config);
    }

    public function templateMessage()
    {
        return new templateMessageClient($this->config);
    }
}

class Member
{
    private $config;

    public function __construct($config)
    {
        $this->config = $config;
    }

    public function identification()
    {
        return new identificationClient($this->config);
    }
}

class Payment
{
    private $config;

    public function __construct($config)
    {
        $this->config = $config;
    }

    public function app()
    {
        return new appClient($this->config);
    }

    public function common()
    {
        return new commonClient($this->config);
    }

    public function faceToFace()
    {
        return new faceToFaceClient($this->config);
    }

    public function huabei()
    {
        return new huabeiClient($this->config);
    }

    public function page()
    {
        return new pageClient($this->config);
    }

    public function wap()
    {
        return new wapClient($this->config);
    }
}

class Security
{
    private $config;

    public function __construct($config)
    {
        $this->config = $config;
    }

    public function textRisk()
    {
        return new textRiskClient($this->config);
    }
}

class Util
{
    private $config;

    public function __construct($config)
    {
        $this->config = $config;
    }

    public function generic()
    {
        return new genericClient($this->config);
    }

    public function aes(){
        return new aesClient($this->config);
    }
}

