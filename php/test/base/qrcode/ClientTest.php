<?php

namespace Alipay\EasySDK\Test\Base;

use Alipay\EasySDK\Kernel\Factory;
use Alipay\EasySDK\Test\TestAccount;
use PHPUnit\Framework\TestCase;

class ClientTest extends TestCase
{
    public function testCreate(){
        $account = new TestAccount();
        Factory::setOptions($account->getTestAccount());
        $result = Factory::base()->qrcode()->create('https://opendocs.alipay.com','ageIndex=1','文档站点');
        $this->assertEquals('10000', $result->code);
        $this->assertEquals('Success', $result->msg);
    }
}