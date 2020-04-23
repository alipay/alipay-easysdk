<?php

// This file is auto-generated, don't edit it. Thanks.
namespace Alipay\EasySDK\Base\Qrcode\Models;

use AlibabaCloud\Tea\Model;

class AlipayOpenAppQrcodeCreateResponse extends Model{
    protected $_name = [
        'httpBody' => 'http_body',
        'code' => 'code',
        'msg' => 'msg',
        'subCode' => 'sub_code',
        'subMsg' => 'sub_msg',
        'qrCodeUrl' => 'qr_code_url',
    ];
    public function validate() {
        Model::validateRequired('httpBody', $this->httpBody, true);
        Model::validateRequired('code', $this->code, true);
        Model::validateRequired('msg', $this->msg, true);
        Model::validateRequired('subCode', $this->subCode, true);
        Model::validateRequired('subMsg', $this->subMsg, true);
        Model::validateRequired('qrCodeUrl', $this->qrCodeUrl, true);
    }
    public function toMap() {
        $res = [];
        $res['http_body'] = $this->httpBody;
        $res['code'] = $this->code;
        $res['msg'] = $this->msg;
        $res['sub_code'] = $this->subCode;
        $res['sub_msg'] = $this->subMsg;
        $res['qr_code_url'] = $this->qrCodeUrl;
        return $res;
    }
    /**
     * @param array $map
     * @return AlipayOpenAppQrcodeCreateResponse
     */
    public static function fromMap($map = []) {
        $model = new self();
        if(isset($map['http_body'])){
            $model->httpBody = $map['http_body'];
        }
        if(isset($map['code'])){
            $model->code = $map['code'];
        }
        if(isset($map['msg'])){
            $model->msg = $map['msg'];
        }
        if(isset($map['sub_code'])){
            $model->subCode = $map['sub_code'];
        }
        if(isset($map['sub_msg'])){
            $model->subMsg = $map['sub_msg'];
        }
        if(isset($map['qr_code_url'])){
            $model->qrCodeUrl = $map['qr_code_url'];
        }
        return $model;
    }
    /**
     * @description 响应原始字符串
     * @var string
     */
    public $httpBody;
    /**
     * @var string
     */
    public $code;
    /**
     * @var string
     */
    public $msg;
    /**
     * @var string
     */
    public $subCode;
    /**
     * @var string
     */
    public $subMsg;
    /**
     * @var string
     */
    public $qrCodeUrl;
}
