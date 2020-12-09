package com.alipay.easysdk.kms.aliyun;

import com.alipay.easysdk.TestAccount;
import com.alipay.easysdk.base.qrcode.models.AlipayOpenAppQrcodeCreateResponse;
import com.alipay.easysdk.factory.Factory;
import com.alipay.easysdk.kms.aliyun.credentials.utils.CredentialType;
import org.junit.Before;
import org.junit.Ignore;
import org.junit.Test;

import static org.hamcrest.CoreMatchers.*;
import static org.hamcrest.MatcherAssert.assertThat;

public class ClientTest {
    AliyunKMSConfig config;

    @Before
    public void setUp() {
        config = TestAccount.AliyunKMS.CONFIG;
        Factory.setOptions(config);
    }

    @Test
    public void testCreate() throws Exception {
        AlipayOpenAppQrcodeCreateResponse response = Factory.Base.Qrcode().create(
                "https://opendocs.alipay.com", "ageIndex=1", "文档站点");

        assertThat(response.code, is("10000"));
        assertThat(response.msg, is("Success"));
        assertThat(response.subCode, is(nullValue()));
        assertThat(response.subMsg, is(nullValue()));
        assertThat(response.httpBody, not(nullValue()));
        assertThat(response.qrCodeUrl, not(nullValue()));
    }

    @Test
    public void test_access_key_credentials() throws Exception {
        //凭据类型默认为ACCESS_KEY，如果使用其他凭据请在这里指定为你需要的类型
        //目前支持的凭据类型有："access_key"，"sts"，"ecs_ram_role"，"ram_role_arn"
        config.credentialType = CredentialType.ACCESS_KEY;
        Factory.setOptions(config);

        AlipayOpenAppQrcodeCreateResponse response = Factory.Base.Qrcode().create(
                "https://opendocs.alipay.com", "ageIndex=1", "文档站点");

        assertThat(response.code, is("10000"));
        assertThat(response.msg, is("Success"));
        assertThat(response.subCode, is(nullValue()));
        assertThat(response.subMsg, is(nullValue()));
        assertThat(response.httpBody, not(nullValue()));
        assertThat(response.qrCodeUrl, not(nullValue()));

    }

    //因为SecurityToken是有失效时间的，所以这个例子需要替换成即时的SecurityToken再运行测试
    @Ignore
    public void test_sts_credentials() throws Exception {
        //凭据类型默认为ACCESS_KEY，如果使用其他凭据请在这里指定为你需要的类型
        //目前支持的凭据类型有："access_key"，"sts"，"ecs_ram_role"，"ram_role_arn"
        config.credentialType = CredentialType.STS;
        config.aliyunSecurityToken = "security token";
        Factory.setOptions(config);

        AlipayOpenAppQrcodeCreateResponse response = Factory.Base.Qrcode().create(
                "https://opendocs.alipay.com", "ageIndex=1", "文档站点");

        assertThat(response.code, is("10000"));
        assertThat(response.msg, is("Success"));
        assertThat(response.subCode, is(nullValue()));
        assertThat(response.subMsg, is(nullValue()));
        assertThat(response.httpBody, not(nullValue()));
        assertThat(response.qrCodeUrl, not(nullValue()));
    }

    @Test
    public void test_ram_role_arn_credentials() throws Exception {
        //凭据类型默认为ACCESS_KEY，如果使用其他凭据请在这里指定为你需要的类型
        //目前支持的凭据类型有："access_key"，"sts"，"ecs_ram_role"，"ram_role_arn"
        config.credentialType = CredentialType.RAM_ROLE_ARN;
        config.aliyunRoleArn = "acs:ram::1540355698848459:role/aliyunramrolearntest";
        Factory.setOptions(config);

        AlipayOpenAppQrcodeCreateResponse response = Factory.Base.Qrcode().create(
                "https://opendocs.alipay.com", "ageIndex=1", "文档站点");

        assertThat(response.code, is("10000"));
        assertThat(response.msg, is("Success"));
        assertThat(response.subCode, is(nullValue()));
        assertThat(response.subMsg, is(nullValue()));
        assertThat(response.httpBody, not(nullValue()));
        assertThat(response.qrCodeUrl, not(nullValue()));
    }

    //此测试例子需要在绑定指定RAM角色的ECS实例上运行
    @Ignore
    public void test_ecs_ram_role_credentials() throws Exception {
        //凭据类型默认为ACCESS_KEY，如果使用其他凭据请在这里指定为你需要的类型
        //目前支持的凭据类型有："access_key"，"sts"，"ecs_ram_role"，"ram_role_arn"
        config.credentialType = CredentialType.ECS_RAM_ROLE;
        config.aliyunRoleName = "AliyunECSRamRoleTest";
        Factory.setOptions(config);

        AlipayOpenAppQrcodeCreateResponse response = Factory.Base.Qrcode().create(
                "https://opendocs.alipay.com", "ageIndex=1", "文档站点");

        assertThat(response.code, is("10000"));
        assertThat(response.msg, is("Success"));
        assertThat(response.subCode, is(nullValue()));
        assertThat(response.subMsg, is(nullValue()));
        assertThat(response.httpBody, not(nullValue()));
        assertThat(response.qrCodeUrl, not(nullValue()));
    }
}
