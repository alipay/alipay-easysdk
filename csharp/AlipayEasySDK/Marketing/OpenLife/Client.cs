// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Tea;

using Alipay.EasySDK.Kernel;
using Alipay.EasySDK.Marketing.OpenLife.Models;

namespace Alipay.EasySDK.Marketing.OpenLife
{
    public class Client : BaseClient
    {

        public Client(Config config): base(config.ToMap())
        { }

        public AlipayOpenPublicMessageContentCreateResponse CreateImageTextContent(string title, string cover, string content, string contentComment, string ctype, string benefit, string extTags, string loginIds)
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.message.content.create"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"title", title},
                        {"cover", cover},
                        {"content", content},
                        {"could_comment", contentComment},
                        {"ctype", ctype},
                        {"benefit", benefit},
                        {"ext_tags", extTags},
                        {"login_ids", loginIds},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.message.content.create");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageContentCreateResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageContentCreateResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<AlipayOpenPublicMessageContentCreateResponse> CreateImageTextContentAsync(string title, string cover, string content, string contentComment, string ctype, string benefit, string extTags, string loginIds)
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.message.content.create"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"title", title},
                        {"cover", cover},
                        {"content", content},
                        {"could_comment", contentComment},
                        {"ctype", ctype},
                        {"benefit", benefit},
                        {"ext_tags", extTags},
                        {"login_ids", loginIds},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.message.content.create");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageContentCreateResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageContentCreateResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public AlipayOpenPublicMessageContentModifyResponse ModifyImageTextContent(string contentId, string title, string cover, string content, string couldComment, string ctype, string benefit, string extTags, string loginIds)
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.message.content.modify"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"content_id", contentId},
                        {"title", title},
                        {"cover", cover},
                        {"content", content},
                        {"could_comment", couldComment},
                        {"ctype", ctype},
                        {"benefit", benefit},
                        {"ext_tags", extTags},
                        {"login_ids", loginIds},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.message.content.modify");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageContentModifyResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageContentModifyResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<AlipayOpenPublicMessageContentModifyResponse> ModifyImageTextContentAsync(string contentId, string title, string cover, string content, string couldComment, string ctype, string benefit, string extTags, string loginIds)
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.message.content.modify"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"content_id", contentId},
                        {"title", title},
                        {"cover", cover},
                        {"content", content},
                        {"could_comment", couldComment},
                        {"ctype", ctype},
                        {"benefit", benefit},
                        {"ext_tags", extTags},
                        {"login_ids", loginIds},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.message.content.modify");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageContentModifyResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageContentModifyResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public AlipayOpenPublicMessageTotalSendResponse SendText(string text)
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.message.total.send"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Text textObj = new Text
                    {
                        Title = "",
                        Content = text,
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"msg_type", "text"},
                        {"text", textObj},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.message.total.send");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageTotalSendResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageTotalSendResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<AlipayOpenPublicMessageTotalSendResponse> SendTextAsync(string text)
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.message.total.send"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Text textObj = new Text
                    {
                        Title = "",
                        Content = text,
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"msg_type", "text"},
                        {"text", textObj},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.message.total.send");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageTotalSendResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageTotalSendResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public AlipayOpenPublicMessageTotalSendResponse SendImageText(List<Article> articles)
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.message.total.send"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"msg_type", "image-text"},
                        {"articles", articles},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.message.total.send");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageTotalSendResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageTotalSendResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<AlipayOpenPublicMessageTotalSendResponse> SendImageTextAsync(List<Article> articles)
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.message.total.send"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"msg_type", "image-text"},
                        {"articles", articles},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.message.total.send");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageTotalSendResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageTotalSendResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public AlipayOpenPublicMessageSingleSendResponse SendSingleMessage(string toUserId, Template template)
        {
            template.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.message.single.send"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"to_user_id", toUserId},
                        {"template", template},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.message.single.send");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageSingleSendResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageSingleSendResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<AlipayOpenPublicMessageSingleSendResponse> SendSingleMessageAsync(string toUserId, Template template)
        {
            template.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.message.single.send"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"to_user_id", toUserId},
                        {"template", template},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.message.single.send");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageSingleSendResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicMessageSingleSendResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public AlipayOpenPublicLifeMsgRecallResponse RecallMessage(string messageId)
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.life.msg.recall"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"message_id", messageId},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.life.msg.recall");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicLifeMsgRecallResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicLifeMsgRecallResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<AlipayOpenPublicLifeMsgRecallResponse> RecallMessageAsync(string messageId)
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.life.msg.recall"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"message_id", messageId},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.life.msg.recall");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicLifeMsgRecallResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicLifeMsgRecallResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public AlipayOpenPublicTemplateMessageIndustryModifyResponse SetIndustry(string primaryIndustryCode, string primaryIndustryName, string secondaryIndustryCode, string secondaryIndustryName)
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.template.message.industry.modify"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"primary_industry_code", primaryIndustryCode},
                        {"primary_industry_name", primaryIndustryName},
                        {"secondary_industry_code", secondaryIndustryCode},
                        {"secondary_industry_name", secondaryIndustryName},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.template.message.industry.modify");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicTemplateMessageIndustryModifyResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicTemplateMessageIndustryModifyResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<AlipayOpenPublicTemplateMessageIndustryModifyResponse> SetIndustryAsync(string primaryIndustryCode, string primaryIndustryName, string secondaryIndustryCode, string secondaryIndustryName)
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.template.message.industry.modify"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>()
                    {
                        {"primary_industry_code", primaryIndustryCode},
                        {"primary_industry_name", primaryIndustryName},
                        {"secondary_industry_code", secondaryIndustryCode},
                        {"secondary_industry_name", secondaryIndustryName},
                    };
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.template.message.industry.modify");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicTemplateMessageIndustryModifyResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicTemplateMessageIndustryModifyResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public AlipayOpenPublicSettingCategoryQueryResponse GetIndustry()
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.setting.category.query"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>(){};
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.setting.category.query");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicSettingCategoryQueryResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicSettingCategoryQueryResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<AlipayOpenPublicSettingCategoryQueryResponse> GetIndustryAsync()
        {
            Dictionary<string, object> runtime_ = new Dictionary<string, object>()
            {
                {"connectTimeout", 15000},
                {"readTimeout", 15000},
                {"retry", new Dictionary<string, int?>()
                {
                    {"maxAttempts", 0},
                }},
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    Dictionary<string, string> systemParams = new Dictionary<string, string>()
                    {
                        {"method", "alipay.open.public.setting.category.query"},
                        {"app_id", _getConfig("appId")},
                        {"timestamp", _getTimestamp()},
                        {"format", "json"},
                        {"version", "1.0"},
                        {"alipay_sdk", _getSdkVersion()},
                        {"charset", "UTF-8"},
                        {"sign_type", _getConfig("signType")},
                        {"app_cert_sn", _getMerchantCertSN()},
                        {"alipay_root_cert_sn", _getAlipayRootCertSN()},
                    };
                    Dictionary<string, object> bizParams = new Dictionary<string, object>(){};
                    Dictionary<string, string> textParams = new Dictionary<string, string>(){};
                    request_.Protocol = _getConfig("protocol");
                    request_.Method = "POST";
                    request_.Pathname = "/gateway.do";
                    request_.Headers = new Dictionary<string, string>()
                    {
                        {"host", _getConfig("gatewayHost")},
                        {"content-type", "application/x-www-form-urlencoded;charset=utf-8"},
                    };
                    request_.Query = TeaConverter.merge<string>(
                        new Dictionary<string, string>()
                        {
                            {"sign", _sign(systemParams, bizParams, textParams, _getConfig("merchantPrivateKey"))},
                        },
                        systemParams,
                        textParams
                    );
                    request_.Body = TeaCore.BytesReadable(_toUrlEncodedRequestBody(bizParams));
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.open.public.setting.category.query");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicSettingCategoryQueryResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayOpenPublicSettingCategoryQueryResponse>(_toRespModel(respMap));
                        }
                    }
                    throw new TeaException(new Dictionary<string, string>()
                    {
                        {"message", "验签失败，请检查支付宝公钥设置是否正确。"},
                    });
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

    }
}
