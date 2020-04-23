<?php

// This file is auto-generated, don't edit it. Thanks.
namespace Alipay\EasySDK\Util\AES;

use AlibabaCloud\Tea\Tea;
use AlibabaCloud\Tea\Model;
use AlibabaCloud\Tea\Request;
use AlibabaCloud\Tea\Exception\TeaError;
use AlibabaCloud\Tea\Exception\TeaUnableRetryError;
use Alipay\EasySDK\Kernel\BaseClient;

class Client extends BaseClient{
    private $_aesDecrypt;
    private $_aesEncrypt;
    private $_getConfig;

    /**
     * @param string $cipherText
     * @return string
     * @throws \Exception
     */
    public function decrypt($cipherText){
        return $this->_aesDecrypt($cipherText, $this->_getConfig("encryptKey"));
    }

    /**
     * @param string $plainText
     * @return string
     * @throws \Exception
     */
    public function encrypt($plainText){
        return $this->_aesEncrypt($plainText, $this->_getConfig("encryptKey"));
    }
}
