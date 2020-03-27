<?php

// This file is auto-generated, don't edit it. Thanks.

namespace Alipay\EasySDK\Payment\Common\Models;

use AlibabaCloud\Tea\Model;

use Alipay\EasySDK\Payment\Common\Models\TradeFundBill;
use Alipay\EasySDK\Payment\Common\Models\PresetPayToolInfo;

class AlipayTradeRefundResponse extends Model{
    protected $_name = [];

    public $httpBody;

    public $code;

    public $msg;

    public $subCode;

    public $subMsg;

    public $tradeNo;

    public $outTradeNo;

    public $buyerLogonId;

    public $fundChange;

    public $refundFee;

    public $refundCurrency;

    public $gmtRefundPay;

    public $refundDetailItemList;

    public $storeName;

    public $buyerUserId;

    public $refundPresetPaytoolList;

    public $refundSettlementId;

    public $presentRefundBuyerAmount;

    public $presentRefundDiscountAmount;

    public $presentRefundMdiscountAmount;

}
