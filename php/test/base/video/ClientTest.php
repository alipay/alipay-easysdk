<?php


namespace Alipay\EasySDK\Test\base\video;


use Alipay\EasySDK\Kernel\Factory;
use Alipay\EasySDK\Test\TestAccount;
use PHPUnit\Framework\TestCase;

class ClientTest extends TestCase
{
    public function testUpload(){
        $account = new TestAccount();
        Factory::setOptions($account->getTestAccount());
        $filePath = dirname(__FILE__) . '/resources/fixture/sample.mp4';
        $result = Factory::base()->video()->upload("测试视频", $filePath);
        $this->assertEquals('10000', $result->code);
        $this->assertEquals('Success', $result->msg);
    }
}