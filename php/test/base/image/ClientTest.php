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
        $filePath = dirname(__FILE__) . '/resources/fixture/sample.png';
        $result =  Factory::base()->image()->upload("测试图片", $filePath);
        $this->assertEquals('10000', $result->code);
        $this->assertEquals('Success', $result->msg);
    }
}