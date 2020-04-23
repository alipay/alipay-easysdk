// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Tea;

using Alipay.EasySDK.Kernel;

namespace Alipay.EasySDK.Util.AES
{
    public class Client : BaseClient
    {

        public Client(Config config): base(config.ToMap())
        { }


        public string Decrypt(string cipherText)
        {
            return _aesDecrypt(cipherText, _getConfig("encryptKey"));
        }

        public string Encrypt(string plainText)
        {
            return _aesEncrypt(plainText, _getConfig("encryptKey"));
        }

    }
}
