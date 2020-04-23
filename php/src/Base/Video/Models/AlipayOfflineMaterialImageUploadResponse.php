<?php

// This file is auto-generated, don't edit it. Thanks.
namespace Alipay\EasySDK\Base\Video\Models;

use AlibabaCloud\Tea\Model;

class AlipayOfflineMaterialImageUploadResponse extends Model{
    protected $_name = [
        'httpBody' => 'http_body',
        'code' => 'code',
        'msg' => 'msg',
        'subCode' => 'sub_code',
        'subMsg' => 'sub_msg',
        'imageId' => 'image_id',
        'imageUrl' => 'image_url',
    ];
    public function validate() {
        Model::validateRequired('httpBody', $this->httpBody, true);
        Model::validateRequired('code', $this->code, true);
        Model::validateRequired('msg', $this->msg, true);
        Model::validateRequired('subCode', $this->subCode, true);
        Model::validateRequired('subMsg', $this->subMsg, true);
        Model::validateRequired('imageId', $this->imageId, true);
        Model::validateRequired('imageUrl', $this->imageUrl, true);
    }
    public function toMap() {
        $res = [];
        $res['http_body'] = $this->httpBody;
        $res['code'] = $this->code;
        $res['msg'] = $this->msg;
        $res['sub_code'] = $this->subCode;
        $res['sub_msg'] = $this->subMsg;
        $res['image_id'] = $this->imageId;
        $res['image_url'] = $this->imageUrl;
        return $res;
    }
    /**
     * @param array $map
     * @return AlipayOfflineMaterialImageUploadResponse
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
        if(isset($map['image_id'])){
            $model->imageId = $map['image_id'];
        }
        if(isset($map['image_url'])){
            $model->imageUrl = $map['image_url'];
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
    public $imageId;
    /**
     * @var string
     */
    public $imageUrl;
}
