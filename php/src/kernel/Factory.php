<?php

namespace Alipay\EasySDK\Kernel;

use AlibabaCloud\Tea\Model;
use Alipay\EasySDK\Base\Image\Client as imageClient;
use Alipay\EasySDK\Base\OAuth\Client as oauthClient;
use Alipay\EasySDK\Base\Qrcode\Client as qrcodeClient;
use Alipay\EasySDK\Base\Video\Client as videoClient;
use Alipay\EasySDK\Marketing\OpenLife\Client as openLifeClient;
use Alipay\EasySDK\Marketing\Pass\Client as passClient;
use Alipay\EasySDK\Marketing\TemplateMessage\Client as templateMessageClient;
use Alipay\EasySDK\Member\Identification\Client as identificationClient;
use Alipay\EasySDK\Payment\Common\Client as commonClient;
use Alipay\EasySDK\Payment\FaceToFace\Client as faceToFaceClient;
use Alipay\EasySDK\Payment\Huabei\Client as huabeiClient;
use Alipay\EasySDK\Security\TextRisk\Client as textRiskClient;
use Alipay\EasySDK\Util\Generic\Client as genericClient;
use Pimple\Container;

class Factory extends Container
{
    protected $config = null;

    public function __construct(Model $config)
    {
        parent::__construct($config->toMap());
        $this->config = $config;
    }

    public function base()
    {
        return new Base($this->config);
    }

    public function marketing()
    {
        return new Marketing($this->config);
    }

    public function member()
    {
        return new Member($this->config);
    }

    public function payment()
    {
        return new Payment($this->config);
    }

    public function security()
    {
        return new Security($this->config);
    }
    public function util(){
        return new Util($this->config);
    }
}


class Base extends Factory
{
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

class Marketing extends Factory
{
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

class Member extends Factory
{
    public function identification()
    {
        return new identificationClient($this->config);
    }
}

class Payment extends Factory
{
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
}

class Security extends Factory
{
    public function textRisk()
    {
        return new textRiskClient($this->config);
    }
}

class Util extends Factory
{
    public function generic()
    {
        return new genericClient($this->config);
    }
}

