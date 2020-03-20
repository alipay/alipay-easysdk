<?php


namespace Alipay\EasySDK\Test\marketing\openlife;


use Alipay\EasySDK\Kernel\Factory;
use Alipay\EasySDK\Marketing\OpenLife\Models\Article;
use Alipay\EasySDK\Marketing\OpenLife\Models\Context;
use Alipay\EasySDK\Marketing\OpenLife\Models\Keyword;
use Alipay\EasySDK\Marketing\OpenLife\Models\Template;
use Alipay\EasySDK\Test\TestAccount;
use PHPUnit\Framework\TestCase;

class ClientTest extends TestCase
{
    protected $app = null;

    public function __construct($name = null, array $data = [], $dataName = '')
    {
        parent::__construct($name, $data, $dataName);
        $account = new TestAccount();
        $this->app = new Factory($account->getTestCertAccount());
    }

    public function testCreateImageTextContent()
    {
        $result = $this->app->marketing()->openLife()->createImageTextContent("标题",
            "http://dl.django.t.taobao.com/rest/1.0/image?fileIds=hOTQ1lT1TtOjcxGflvnUXgAAACMAAQED",
            "示例", "T", "activity", "满100减10",
            "关键,热度", "13434343432,xxx@163.com");
        $this->assertEquals('10000', $result['code']);
        $this->assertEquals('Success', $result['msg']);
    }

    public function testModifyImageTextContent()
    {
        $result = $this->app->marketing()->openLife()->modifyImageTextContent(
            "20190510645210035577f788-d6cd-4020-9dba-1a195edb7342", "新标题",
            "http://dl.django.t.taobao.com/rest/1.0/image?fileIds=hOTQ1lT1TtOjcxGflvnUXgAAACMAAQED",
            "新示例", "T", "activity", "满100减20",
            "关键,热度", "13434343432,xxx@163.com");
        if($result['code'] == '10000'){
            $this->assertEquals('10000', $result['code']);
            $this->assertEquals('Success', $result['msg']);
        }else{
            $this->assertEquals('40004', $result['code']);
            $this->assertEquals('Business Failed', $result['msg']);
            $this->assertEquals('PUB.MSG_BATCH_SD_OVER', $result['sub_code']);
            $this->assertEquals('批量发送消息频率超限', $result['sub_msg']);
        }

    }

    public function testSendText()
    {
        $result = $this->app->marketing()->openLife()->sendText("测试");
        if($result['code'] == '10000'){
            $this->assertEquals('10000', $result['code']);
            $this->assertEquals('Success', $result['msg']);
        }else{
            $this->assertEquals('40004', $result['code']);
            $this->assertEquals('Business Failed', $result['msg']);
            $this->assertEquals('PUB.MSG_BATCH_SD_OVER', $result['sub_code']);
            $this->assertEquals('批量发送消息频率超限', $result['sub_msg']);
        }
    }

    public function testSendImageText()
    {
        $article = new Article();
        $article->actionName = '测试';
        $article->desc = '测试';
        $article->title = '测试';
        $article->imageUrl = 'http://dl.django.t.taobao.com/rest/1.0/image?fileIds=hOTQ1lT1TtOjcxGflvnUXgAAACMAAQED';
        $article->url = 'https://docs.open.alipay.com/api_6/alipay.open.public.message.total.send';
        $result = $this->app->marketing()->openLife()->sendImageText((array)$article);
        if($result['code'] == '10000'){
            $this->assertEquals('10000', $result['code']);
            $this->assertEquals('Success', $result['msg']);
        }else{
            $this->assertEquals('40004', $result['code']);
            $this->assertEquals('Business Failed', $result['msg']);
            $this->assertEquals('PUB.MSG_BATCH_SD_OVER', $result['sub_code']);
            $this->assertEquals('批量发送消息频率超限', $result['sub_msg']);
        }
    }

    public function testSendSingleMessage()
    {
        $keyword = new Keyword();
        $keyword->color = "#85be53";
        $keyword->value = "HU7142";

        $context = new Context();
        $context->headColor = "#85be53";
        $context->url = "https://docs.open.alipay.com/api_6/alipay.open.public.message.single.send";
        $context->actionName = "查看详情";
        $context->keyword1 = $keyword;
        $context->keyword2 = $keyword;
        $context->first = $keyword;
        $context->remark = $keyword;

        $template = new Template();
        $template->templateId = "e44cd3e52ffa46b1a50afc145f55d1ea";
        $template->context = $context;

        $result = $this->app->marketing()->openLife()->sendSingleMessage("2088002656718920", $template);

        $this->assertEquals('10000', $result['code']);
        $this->assertEquals('Success', $result['msg']);
    }

    public function testRecallMessage()
    {
        $result = $this->app->marketing()->openLife()->recallMessage("201905106452100327f456f6-8dd2-4a06-8b0e-ec8a3a85c46a");

        $this->assertEquals('10000', $result['code']);
        $this->assertEquals('Success', $result['msg']);
    }

    public function testSetIndustry()
    {
        $result = $this->app->marketing()->openLife()->setIndustry(
            "10001/20102", "IT科技/IT软件与服务",
            "10001/20102", "IT科技/IT软件与服务");

        if($result['code'] == '10000'){
            $this->assertEquals('10000', $result['code']);
            $this->assertEquals('Success', $result['msg']);
        }else{
            $this->assertEquals('40004', $result['code']);
            $this->assertEquals('Business Failed', $result['msg']);
            $this->assertEquals('3002', $result['sub_code']);
            $this->assertEquals('模板消息行业一月只能修改一次', $result['sub_msg']);
        }
    }

    public function testGetIndustry()
    {
        $result = $this->app->marketing()->openLife()->getIndustry();
        var_dump($result);
        $this->assertEquals('10000', $result['code']);
        $this->assertEquals('Success', $result['msg']);
        $this->assertEquals('IT科技/IT软件与服务', $result['primary_category']);
        $this->assertEquals('IT科技/IT软件与服务', $result['secondary_category']);
    }
}