<?php


namespace Alipay\EasySDK\Test\payment\common;


use Alipay\EasySDK\Kernel\Factory;
use Alipay\EasySDK\Test\TestAccount;
use PHPUnit\Framework\TestCase;

class verifyNotifyTest extends TestCase
{

    public function testVerifyNotify()
    {
        Factory::setOptions($this->getConfig());
        $params = $this->getParameters();
        $result = Factory::payment()->common()->verifyNotify($params);
        $this->assertEquals(true, $result);
    }

    private function getConfig()
    {
        $account = new TestAccount();
        $options = $account->getTestAccount();
        $options->alipayPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAkKHoQ7HAruVVIr5qoEWY4PkNbvtiLXAGiWiT"
            . "JbuoGIebQr0QCKsN7ujU02kftNQIVAHkr4RoPhWo0thEavoH/QUvxVbW+6wizot5k0XEKEbZm7icFtM70Hi1uL1tF6P/V2h"
            . "+nqVdX4im8gHcmz1K8VWiuiucDn20eFratwM0CfWaZhxZewgtOaePUBqr1ByusvPJ7vl6AfwViQmvrIUUlmXRCqu9igLjJs"
            . "fJt0WNJu/ThkBmrdAXttvAHemsEoQiarobUEwErPrDKSEmlrupW3hVPuqQf253Z5TKMi0EJduO6Orn4AtEFtJlzBrBfxx9x"
            . "Y6JP2JtV91M/3MEwLYyiQIDAQAB";
        return $options;
    }

    private function getParameters()
    {
        $parameters = array(
            "charset" => "UTF-8",
            "notify_time" => "2020-03-25 16:27:08",
            "commodity_order_id" => "202003250000000005945192",
            "total_price" => "0.01",
            "method" => "alipay.open.servicemarket.order.notify",
            "miniapp_release_bundle" => "1032",
            "sign" => "GM0CbuqaEivqgb6aRdWK1yvg3QoOIdBLIEB/wfeXHXlsYLvA2ChYO1VEDtLmnULrqfeSw2+BnwAxf04"
                . "+DZHMtFgbUwNOES9BUyx2tZ5lQCettBHkobTwZIPk5qoq4ld6DMcPBoSbDKmuxPbaqti2"
                . "+5M4BdVngKnc2ich6TfYSB4oLPqUAQHLpPoq3d1iaJwTN7jeLDBzbhqCv/aFIrnwk0W5hDcMGFGD32xbuFr2tHW"
                . "/+tDFliapsVrH86PykVPn1OCtrbKBrC6v/+w+uUOnRB2mD7PYMoodntwOLvRP9am0N08fYciyBts3fLV8zmApMHWV7oHFsX4dbngcHEkTRg==",
            "order_time" => "2020-03-25 16:27:00",
            "title" => "社区新零售",
            "version" => "1.0",
            "notify_id" => "2020032500222162707030491455661685",
            "merchant_pid" => "2088112276053036",
            "notify_type" => "servicemarket_order_notify",
            "phone" => "15936350926",
            "name" => "赵华杰",
            "order_item_num" => "1",
            "consumer_miniAppId" => "2021001146661669",
            "contactor" => "赵华杰",
            "app_id" => "2018091261392200",
            "sign_type" => "RSA2",
            "isv_ticket" => "",
            "timestamp" => "2020-03-25 16:27:08"
        );
        return $parameters;
    }
}