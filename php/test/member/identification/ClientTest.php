<?php


namespace Alipay\EasySDK\Test\member\identification;


use Alipay\EasySDK\Kernel\Factory;
use Alipay\EasySDK\Member\Identification\Models\IdentityParam;
use Alipay\EasySDK\Member\Identification\Models\MerchantConfig;
use Alipay\EasySDK\Test\TestAccount;
use PHPUnit\Framework\TestCase;

class ClientTest extends TestCase
{
    protected $app = null;

    public function __construct($name = null, array $data = [], $dataName = '')
    {
        parent::__construct($name, $data, $dataName);
        $account = new TestAccount();
        $this->app = new Factory($account->getTestAccount());
    }

    public function testInit()
    {
        $identityParam = new IdentityParam();
        $identityParam->identityType = "CERT_INFO";
        $identityParam->certType = "IDENTITY_CARD";
        $identityParam->certName = "张三";
        $identityParam->certNo = "5139011988090987631";

        $merchantConfig = new MerchantConfig();
        $merchantConfig->returnUrl = "www.taobao.com";

        $result = $this->app->member()->identification()->init(microtime(),'FACE',$identityParam,$merchantConfig);
        $this->assertEquals('10000', $result['code']);
        $this->assertEquals('Success', $result['msg']);
    }

    public function testCertify()
    {
        $result = $this->app->member()->identification()->certify("16cbbf40de9829e337d51818a76eacc2");
        $this->assertEquals(true, strpos($result,'sign')>0);
        $this->assertEquals(true, strpos($result,'gateway.do')>0);
    }

    public function testQuery()
    {
        $result = $this->app->member()->identification()->query("16cbbf40de9829e337d51818a76eacc2");
        $this->assertEquals('10000', $result['code']);
        $this->assertEquals('Success', $result['msg']);

    }

}