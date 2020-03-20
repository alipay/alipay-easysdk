<?php


namespace Alipay\EasySDK\Test\security\textrisk;


use Alipay\EasySDK\Kernel\Factory;
use Alipay\EasySDK\Test\TestAccount;
use PHPUnit\Framework\TestCase;

class ClientTest extends TestCase
{
    public function testDetectContent(){
        $account = new TestAccount();
        $app = new Factory($account->getTestAccount());
        $result = $app->security()->textRisk()->detect("test");
        $this->assertEquals('10000', $result['code']);
        $this->assertEquals('Success', $result['msg']);
    }
}