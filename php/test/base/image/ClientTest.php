<?php


namespace Alipay\EasySDK\Test\base\image;


use Alipay\EasySDK\Kernel\Factory;
use Alipay\EasySDK\Test\TestAccount;
use PHPUnit\Framework\TestCase;

class ClientTest extends TestCase
{
    public function testUpload(){
        $account = new TestAccount();
        Factory::setOptions($account->getTestAccount());
        $result =  Factory::base()->image()->upload("测试图片",
            "test/resources/fixture/sample.png");
        $this->assertEquals('10000',$result['code']);
        $this->assertEquals('Success',$result['msg']);
    }
}