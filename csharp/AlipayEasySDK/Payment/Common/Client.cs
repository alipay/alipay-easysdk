// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Tea;

using Alipay.EasySDK.Kernel;
using Alipay.EasySDK.Payment.Common.Models;

namespace Alipay.EasySDK.Payment.Common
{
    public class Client : BaseClient
    {

        public Client(Config config): base(config.ToMap())
        { }

        public AlipayTradeCreateResponse Create(string subject, string outTradeNo, string totalAmount, string buyerId)
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
                        {"method", "alipay.trade.create"},
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
                        {"subject", subject},
                        {"out_trade_no", outTradeNo},
                        {"total_amount", totalAmount},
                        {"buyer_id", buyerId},
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

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.trade.create");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayTradeCreateResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayTradeCreateResponse>(_toRespModel(respMap));
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

        public async Task<AlipayTradeCreateResponse> CreateAsync(string subject, string outTradeNo, string totalAmount, string buyerId)
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
                        {"method", "alipay.trade.create"},
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
                        {"subject", subject},
                        {"out_trade_no", outTradeNo},
                        {"total_amount", totalAmount},
                        {"buyer_id", buyerId},
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

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.trade.create");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayTradeCreateResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayTradeCreateResponse>(_toRespModel(respMap));
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

        public AlipayTradeQueryResponse Query(string outTradeNo)
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
                        {"method", "alipay.trade.query"},
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
                        {"out_trade_no", outTradeNo},
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

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.trade.query");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayTradeQueryResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayTradeQueryResponse>(_toRespModel(respMap));
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

        public async Task<AlipayTradeQueryResponse> QueryAsync(string outTradeNo)
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
                        {"method", "alipay.trade.query"},
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
                        {"out_trade_no", outTradeNo},
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

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.trade.query");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayTradeQueryResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayTradeQueryResponse>(_toRespModel(respMap));
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

        public AlipayTradeRefundResponse Refund(string outTradeNo, string refundAmount)
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
                        {"method", "alipay.trade.refund"},
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
                        {"out_trade_no", outTradeNo},
                        {"refund_amount", refundAmount},
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

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.trade.refund");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayTradeRefundResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayTradeRefundResponse>(_toRespModel(respMap));
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

        public async Task<AlipayTradeRefundResponse> RefundAsync(string outTradeNo, string refundAmount)
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
                        {"method", "alipay.trade.refund"},
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
                        {"out_trade_no", outTradeNo},
                        {"refund_amount", refundAmount},
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

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.trade.refund");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayTradeRefundResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayTradeRefundResponse>(_toRespModel(respMap));
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

        public AlipayTradeCloseResponse Close(string outTradeNo)
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
                        {"method", "alipay.trade.close"},
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
                        {"out_trade_no", outTradeNo},
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

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.trade.close");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayTradeCloseResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayTradeCloseResponse>(_toRespModel(respMap));
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

        public async Task<AlipayTradeCloseResponse> CloseAsync(string outTradeNo)
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
                        {"method", "alipay.trade.close"},
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
                        {"out_trade_no", outTradeNo},
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

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.trade.close");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayTradeCloseResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayTradeCloseResponse>(_toRespModel(respMap));
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

        public AlipayTradeCancelResponse Cancel(string outTradeNo)
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
                        {"method", "alipay.trade.cancel"},
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
                        {"out_trade_no", outTradeNo},
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

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.trade.cancel");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayTradeCancelResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayTradeCancelResponse>(_toRespModel(respMap));
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

        public async Task<AlipayTradeCancelResponse> CancelAsync(string outTradeNo)
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
                        {"method", "alipay.trade.cancel"},
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
                        {"out_trade_no", outTradeNo},
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

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.trade.cancel");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayTradeCancelResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayTradeCancelResponse>(_toRespModel(respMap));
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

        public AlipayTradeFastpayRefundQueryResponse QueryRefund(string outTradeNo, string outRequestNo)
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
                        {"method", "alipay.trade.fastpay.refund.query"},
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
                        {"out_trade_no", outTradeNo},
                        {"out_request_no", outRequestNo},
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

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.trade.fastpay.refund.query");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayTradeFastpayRefundQueryResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayTradeFastpayRefundQueryResponse>(_toRespModel(respMap));
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

        public async Task<AlipayTradeFastpayRefundQueryResponse> QueryRefundAsync(string outTradeNo, string outRequestNo)
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
                        {"method", "alipay.trade.fastpay.refund.query"},
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
                        {"out_trade_no", outTradeNo},
                        {"out_request_no", outRequestNo},
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

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.trade.fastpay.refund.query");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayTradeFastpayRefundQueryResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayTradeFastpayRefundQueryResponse>(_toRespModel(respMap));
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

        public AlipayDataDataserviceBillDownloadurlQueryResponse DownloadBill(string billType, string billDate)
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
                        {"method", "alipay.data.dataservice.bill.downloadurl.query"},
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
                        {"bill_type", billType},
                        {"bill_date", billDate},
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

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.data.dataservice.bill.downloadurl.query");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayDataDataserviceBillDownloadurlQueryResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayDataDataserviceBillDownloadurlQueryResponse>(_toRespModel(respMap));
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

        public async Task<AlipayDataDataserviceBillDownloadurlQueryResponse> DownloadBillAsync(string billType, string billDate)
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
                        {"method", "alipay.data.dataservice.bill.downloadurl.query"},
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
                        {"bill_type", billType},
                        {"bill_date", billDate},
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

                    Dictionary<string, object> respMap = _readAsJson(response_, "alipay.data.dataservice.bill.downloadurl.query");
                    if (_isCertMode())
                    {
                        if (_verify(respMap, _extractAlipayPublicKey(_getAlipayCertSN(respMap))))
                        {
                            return TeaModel.ToObject<AlipayDataDataserviceBillDownloadurlQueryResponse>(_toRespModel(respMap));
                        }
                    }
                    else
                    {
                        if (_verify(respMap, _getConfig("alipayPublicKey")))
                        {
                            return TeaModel.ToObject<AlipayDataDataserviceBillDownloadurlQueryResponse>(_toRespModel(respMap));
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

        public bool? VerifyNotify(Dictionary<string, string> parameters)
        {
            if (_isCertMode())
            {
                return _verifyParams(parameters, _extractAlipayPublicKey(""));
            }
            else
            {
                return _verifyParams(parameters, _getConfig("alipayPublicKey"));
            }
        }

    }
}
