<?php

// This file is auto-generated, don't edit it. Thanks.
namespace Alipay\EasySDK\Payment\Common\Models;

use AlibabaCloud\Tea\Model;

class AlipayTradeCancelResponse extends Model{
    protected $_name = [
        'httpBody' => 'http_body',
        'code' => 'code',
        'msg' => 'msg',
        'subCode' => 'sub_code',
        'subMsg' => 'sub_msg',
        'tradeNo' => 'trade_no',
        'outTradeNo' => 'out_trade_no',
        'retryFlag' => 'retry_flag',
        'action' => 'action',
        'gmtRefundPay' => 'gmt_refund_pay',
        'refundSettlementId' => 'refund_settlement_id',
    ];
    public function validate() {
        Model::validateRequired('httpBody', $this->httpBody, true);
        Model::validateRequired('code', $this->code, true);
        Model::validateRequired('msg', $this->msg, true);
        Model::validateRequired('subCode', $this->subCode, true);
        Model::validateRequired('subMsg', $this->subMsg, true);
        Model::validateRequired('tradeNo', $this->tradeNo, true);
        Model::validateRequired('outTradeNo', $this->outTradeNo, true);
        Model::validateRequired('retryFlag', $this->retryFlag, true);
        Model::validateRequired('action', $this->action, true);
        Model::validateRequired('gmtRefundPay', $this->gmtRefundPay, true);
        Model::validateRequired('refundSettlementId', $this->refundSettlementId, true);
    }
    public function toMap() {
        $res = [];
        $res['http_body'] = $this->httpBody;
        $res['code'] = $this->code;
        $res['msg'] = $this->msg;
        $res['sub_code'] = $this->subCode;
        $res['sub_msg'] = $this->subMsg;
        $res['trade_no'] = $this->tradeNo;
        $res['out_trade_no'] = $this->outTradeNo;
        $res['retry_flag'] = $this->retryFlag;
        $res['action'] = $this->action;
        $res['gmt_refund_pay'] = $this->gmtRefundPay;
        $res['refund_settlement_id'] = $this->refundSettlementId;
        return $res;
    }
    /**
     * @param array $map
     * @return AlipayTradeCancelResponse
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
        if(isset($map['trade_no'])){
            $model->tradeNo = $map['trade_no'];
        }
        if(isset($map['out_trade_no'])){
            $model->outTradeNo = $map['out_trade_no'];
        }
        if(isset($map['retry_flag'])){
            $model->retryFlag = $map['retry_flag'];
        }
        if(isset($map['action'])){
            $model->action = $map['action'];
        }
        if(isset($map['gmt_refund_pay'])){
            $model->gmtRefundPay = $map['gmt_refund_pay'];
        }
        if(isset($map['refund_settlement_id'])){
            $model->refundSettlementId = $map['refund_settlement_id'];
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
    public $tradeNo;
    /**
     * @var string
     */
    public $outTradeNo;
    /**
     * @var string
     */
    public $retryFlag;
    /**
     * @var string
     */
    public $action;
    /**
     * @var string
     */
    public $gmtRefundPay;
    /**
     * @var string
     */
    public $refundSettlementId;
}
