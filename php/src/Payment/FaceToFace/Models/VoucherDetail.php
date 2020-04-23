<?php

// This file is auto-generated, don't edit it. Thanks.
namespace Alipay\EasySDK\Payment\FaceToFace\Models;

use AlibabaCloud\Tea\Model;

class VoucherDetail extends Model{
    protected $_name = [
        'id' => 'id',
        'name' => 'name',
        'type' => 'type',
        'amount' => 'amount',
        'merchantContribute' => 'merchant_contribute',
        'otherContribute' => 'other_contribute',
        'memo' => 'memo',
        'templateId' => 'template_id',
        'purchaseBuyerContribute' => 'purchase_buyer_contribute',
        'purchaseMerchantContribute' => 'purchase_merchant_contribute',
        'purchaseAntContribute' => 'purchase_ant_contribute',
    ];
    public function validate() {
        Model::validateRequired('id', $this->id, true);
        Model::validateRequired('name', $this->name, true);
        Model::validateRequired('type', $this->type, true);
        Model::validateRequired('amount', $this->amount, true);
        Model::validateRequired('merchantContribute', $this->merchantContribute, true);
        Model::validateRequired('otherContribute', $this->otherContribute, true);
        Model::validateRequired('memo', $this->memo, true);
        Model::validateRequired('templateId', $this->templateId, true);
        Model::validateRequired('purchaseBuyerContribute', $this->purchaseBuyerContribute, true);
        Model::validateRequired('purchaseMerchantContribute', $this->purchaseMerchantContribute, true);
        Model::validateRequired('purchaseAntContribute', $this->purchaseAntContribute, true);
    }
    public function toMap() {
        $res = [];
        $res['id'] = $this->id;
        $res['name'] = $this->name;
        $res['type'] = $this->type;
        $res['amount'] = $this->amount;
        $res['merchant_contribute'] = $this->merchantContribute;
        $res['other_contribute'] = $this->otherContribute;
        $res['memo'] = $this->memo;
        $res['template_id'] = $this->templateId;
        $res['purchase_buyer_contribute'] = $this->purchaseBuyerContribute;
        $res['purchase_merchant_contribute'] = $this->purchaseMerchantContribute;
        $res['purchase_ant_contribute'] = $this->purchaseAntContribute;
        return $res;
    }
    /**
     * @param array $map
     * @return VoucherDetail
     */
    public static function fromMap($map = []) {
        $model = new self();
        if(isset($map['id'])){
            $model->id = $map['id'];
        }
        if(isset($map['name'])){
            $model->name = $map['name'];
        }
        if(isset($map['type'])){
            $model->type = $map['type'];
        }
        if(isset($map['amount'])){
            $model->amount = $map['amount'];
        }
        if(isset($map['merchant_contribute'])){
            $model->merchantContribute = $map['merchant_contribute'];
        }
        if(isset($map['other_contribute'])){
            $model->otherContribute = $map['other_contribute'];
        }
        if(isset($map['memo'])){
            $model->memo = $map['memo'];
        }
        if(isset($map['template_id'])){
            $model->templateId = $map['template_id'];
        }
        if(isset($map['purchase_buyer_contribute'])){
            $model->purchaseBuyerContribute = $map['purchase_buyer_contribute'];
        }
        if(isset($map['purchase_merchant_contribute'])){
            $model->purchaseMerchantContribute = $map['purchase_merchant_contribute'];
        }
        if(isset($map['purchase_ant_contribute'])){
            $model->purchaseAntContribute = $map['purchase_ant_contribute'];
        }
        return $model;
    }
    /**
     * @var string
     */
    public $id;
    /**
     * @var string
     */
    public $name;
    /**
     * @var string
     */
    public $type;
    /**
     * @var string
     */
    public $amount;
    /**
     * @var string
     */
    public $merchantContribute;
    /**
     * @var string
     */
    public $otherContribute;
    /**
     * @var string
     */
    public $memo;
    /**
     * @var string
     */
    public $templateId;
    /**
     * @var string
     */
    public $purchaseBuyerContribute;
    /**
     * @var string
     */
    public $purchaseMerchantContribute;
    /**
     * @var string
     */
    public $purchaseAntContribute;
}
