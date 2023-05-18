// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections.Generic;
using System.IO;

using Tea;

namespace Alipay.EasySDK.Base.Qrcode.Models
{
    public class AlipayOpenAppQrcodeCreateResponse : TeaModel
    {
        /// <summary>
        /// 响应原始字符串
        /// </summary>
        [NameInMap("http_body")]
        [Validation(Required = true)]
        public string HttpBody { get; set; }

        [NameInMap("code")]
        [Validation(Required = true)]
        public string Code { get; set; }

        [NameInMap("msg")]
        [Validation(Required = true)]
        public string Msg { get; set; }

        [NameInMap("sub_code")]
        [Validation(Required = true)]
        public string SubCode { get; set; }

        [NameInMap("sub_msg")]
        [Validation(Required = true)]
        public string SubMsg { get; set; }

        /// <summary>
        /// 方形二维码图片链接地址
        /// </summary>
        [NameInMap("qr_code_url")]
        [Validation(Required = true)]
        public string QrCodeUrl { get; set; }

        /// <summary>
        /// 圆形二维码地址，白色slogan
        /// </summary>
        [NameInMap("qr_code_url_circle_white")]
        [Validation(Required = false)]
        public string QrCodeUrlCircleWhite { get; set; }

        /// <summary>
        /// 圆形二维码地址，蓝色slogan
        /// </summary>
        [NameInMap("qr_code_url_circle_blue")]
        [Validation(Required = false)]
        public string QrCodeUrlCircleBlue { get; set; }
    }

}
