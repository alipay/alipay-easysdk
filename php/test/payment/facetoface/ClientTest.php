<?php


namespace Alipay\EasySDK\Test\payment\facetoface;


use Alipay\EasySDK\Kernel\Factory;
use Alipay\EasySDK\Test\TestAccount;
use PHPUnit\Framework\TestCase;

class ClientTest extends TestCase
{
    public function testPay()
    {
        $account = new TestAccount();
        Factory::setOptions($account->getTestAccount());
        $create =Factory::payment()->common()->create("Iphone6 16G",
            microtime(), "88.88", "2088002656718920");

        $result = Factory::payment()->faceToFace()->pay("Iphone6 16G", $create['out_trade_no'], "0.10",
            "1234567890");
        $this->assertEquals('40004', $result['code']);
        $this->assertEquals('Business Failed', $result['msg']);
        $this->assertEquals('ACQ.PAYMENT_AUTH_CODE_INVALID', $result['sub_code']);
        $this->assertEquals('支付失败，获取顾客账户信息失败，请顾客刷新付款码后重新收款，如再次收款失败，请联系管理员处理。[SOUNDWAVE_PARSER_FAIL]', $result['sub_msg']);
    }

}