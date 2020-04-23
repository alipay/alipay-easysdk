[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Falipay%2Falipay-easysdk.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2Falipay%2Falipay-easysdk?ref=badge_shield)
[![Maven Central](https://img.shields.io/maven-central/v/com.alipay.sdk/alipay-easysdk.svg)](https://mvnrepository.com/artifact/com.alipay.sdk/alipay-easysdk)
[![NuGet](https://badge.fury.io/nu/AlipayEasySDK.svg)](https://badge.fury.io/nu/AlipayEasySDK)
[![Packagist](https://poser.pugx.org/alipaysdk/easysdk/v/stable)](https://packagist.org/packages/alipaysdk/easysdk)

欢迎使用 Alipay **Easy** SDK。

打造**最好用**的支付宝开放平台**服务端SDK**，Alipay Easy SDK让您享受**极简编程**体验，快速访问支付宝开放平台开放的各项**核心能力**。

## 设计理念
不同于原有的Alipay SDK通用而全面的设计理念，Alipay Easy SDK对开放能力的API进行了更加贴近高频场景的精心设计与裁剪，简化了服务端调用方式，让调用API像使用语言内置的函数一样简便。

Alipay Easy SDK提供了与[能力地图](https://opendocs.alipay.com/mini/00am3f)相对应的代码组织结构，让开发者可以快速找到不同能力对应的API。

Alipay Easy SDK主要目标是提升开发者在**服务端**集成支付宝开放平台开放的各类核心能力的效率。

### 化繁为简

| Alipay Easy SDK  | Alipay SDK                                                     |
|------------------|----------------------------------------------------------------|
| 极简代码风格，更贴近自然语言阅读习惯  | 传统代码风格，需要多行代码完成一个接口的调用 |
| Factory单例全局任何地方都可直接引用 | AlipayClient实例需自行创建并在上下文中传递 |
| 只保留高频场景下的必备参数    | 可选参数最多可达数十个，对普通开发者的干扰项较多 |


* Alipay Easy SDK :smiley:

```java
Factory.Payment.Common().create("Iphone6 16G", "202003019443", "0.10", "2088002656718920");
```

* Alipay SDK :confused:

```java
AlipayTradeCreateRequest request = new AlipayTradeCreateRequest();

AlipayTradeCreateModel model = new AlipayTradeCreateModel();
model.setSubject("Iphone6 16G");
model.setOutTradeNo("202003019443");
model.setTotalAmount("0.10");
model.setBuyerId("2088002656718920");
...

request.setBizModel(model);
...

alipayClient.execute(request);
```

### 如何切换
* 无论是Alipay Easy SDK还是Alipay SDK，本质都是发送HTTP请求访问Open API网关，所以只需将原来通过Alipay SDK调用Open API的代码，替换为Alipay Easy SDK中对应API的调用即可。

* Alipay Easy SDK和Alipay SDK并无冲突，可以共存。
	* 如果您所对接的能力和场景，Alipay Easy SDK已完全支持（[已支持的API列表](#apiList)），或者可以通过[通用接口](./APIDoc.md#generic)覆盖，您也可以去除对Alipay SDK的依赖。

* 我们会持续挖掘高频场景，不断丰富Alipay Easy SDK支持的API，让您在绝大多数常见场景下，都能享受Alipay Easy SDK带来的便捷。对于非高频场景的对接，依然建议使用Alipay SDK，Alipay SDK对支付宝开放平台开放的所有能力提供了**最全面**的支持。

## 技术特点
### 纯语言开发
所有Alipay Easy SDK的具体编程语言的实现，均只采用纯编程语言进行开发，不引入任何重量级框架，减少潜在的框架冲突，让SDK可以自由集成进任何代码环境中。

### 结构清晰
我们按照能力类别和场景类别对API进行了归类，结构更加清晰，一目了然。
> 更多信息请参见[API组织规范](#spec)。

### 参数精简
Alipay Easy SDK对每个API都精心打磨，剔除了`Open API`中不常用的可选参数，减少普通用户的无效选择，提升开发效率。

### 测试/示例完备
每个API都有对应的单元测试进行覆盖，良好的单元测试天生就是最好的示例。

同时您也可以前往[API Doc](./APIDoc.md)查看每个API的详细使用说明。

> 注：单元测试中使用到的私钥均进行了脱敏处理，会导致单元测试无法直接执行。您可以自行更改单元测试项目中的`TestAccout类`和`privateKey.json`文件中的相关账号与私钥配置后再执行单元测试。

### 多语言
Alipay Easy SDK基于阿里集团研发的`Tea DSL`工具链进行架构，通过DSL中间语言定义API模型，再基于DSL语言自动生成不同编程语言（Java、C#、PHP、TS等）实现的SDK，极大地提升了SDK能力的扩展效率和适用范围，同时也保证了相同的`Easy API`在不同语言生态中体验的一致性。

API模型的Tea DSL描述可以进入[tea](./tea)目录查看。

> Tea DSL相关介绍和编写规范正在筹划开放中，后续您也可以参与Tea DSL的编写贡献更多优秀的`Easy API`模型，而无需关心多语言问题。

### 快速集成
各语言SDK均会在各自的中央仓库（Maven、NuGet、Composer、NPM etc.）中同步发布，让您使用各语言主流依赖管理工具即可一键安装集成SDK。

## 语言支持情况
Alipay Easy SDK首发暂只支持`Java`、`C#`、`PHP`编程语言，更多编程语言支持正在积极新增中，敬请期待。

各语言具体的**使用说明**和**详细介绍**请点击如下链接进入各语言主目录查看。

[Java](./java)

[C#](./csharp)

[PHP](./php)

<a name="spec"/>

## API组织规范

在Alipay Easy SDK中，API的引用路径与能力地图的组织层次一致，遵循如下规范

> Factory.能力名称.场景名称.接口方法名称( ... )

比如，如果您想要使用[能力地图](https://opendocs.alipay.com/mini/00am3f)中`营销能力`下的`模板消息`场景中的`小程序发送模板消息`，只需按如下形式编写调用代码即可（不同编程语言的连接符号可能不同）。

`Factory.Marketing.TemplateMessage().send( ... )`

其中，接口方法名称通常是对其依赖的OpenAPI功能的一个最简概况，接口方法的出入参与OpenAPI中同名参数含义一致，可参照OpenAPI相关参数的使用说明。

Alipay Easy SDK将致力于保持良好的API命名，以符合开发者的编程直觉。

<a name="apiList"/>

## 已支持的API列表

| 能力类别      | 场景类别            | 接口方法名称                 | 调用的OpenAPI名称                                              |
|-----------|-----------------|------------------------|-----------------------------------------------------------|
| Base      | OAuth           | getToken               | alipay\.system\.oauth\.token                              |
| Base      | OAuth           | refreshToken           | alipay\.system\.oauth\.token                              |
| Base      | Qrcode          | create                 | alipay\.open\.app\.qrcode\.create                         |
| Base      | Image           | upload                 | alipay\.offline\.material\.image\.upload                  |
| Base      | Video           | upload                 | alipay\.offline\.material\.image\.upload                  |
| Member    | Identification  | init                   | alipay\.user\.certify\.open\.initialize                   |
| Member    | Identification  | certify                | alipay\.user\.certify\.open\.certify                      |
| Member    | Identification  | query                  | alipay\.user\.certify\.open\.query                        |
| Payment   | Common          | create                 | alipay\.trade\.create                                     |
| Payment   | Common          | query                  | alipay\.trade\.query                                      |
| Payment   | Common          | refund                 | alipay\.trade\.refund                                     |
| Payment   | Common          | close                  | alipay\.trade\.close                                      |
| Payment   | Common          | cancel                 | alipay\.trade\.cancel                                     |
| Payment   | Common          | queryRefund            | alipay\.trade\.fastpay\.refund\.query                     |
| Payment   | Common          | downloadBill           | alipay\.data\.dataservice\.bill\.downloadurl\.query       |
| Payment   | Common          | verifyNotify           | -                                                         |
| Payment   | Huabei          | create                 | alipay\.trade\.create                                     |
| Payment   | FaceToFace      | pay                    | alipay\.trade\.pay                                        |
| Payment   | FaceToFace      | precreate              | alipay\.trade\.precreate                                  |
| Payment   | App             | pay                    | alipay\.trade\.app\.pay                                   |
| Payment   | Page            | pay                    | alipay\.trade\.page\.pay                                  |
| Payment   | Wap             | pay                    | alipay\.trade\.wap\.pay                                   |
| Security  | TextRisk        | detect                 | alipay\.security\.risk\.content\.detect                   |
| Marketing | Pass            | createTemplate         | alipay\.pass\.template\.add                               |
| Marketing | Pass            | updateTemplate         | alipay\.pass\.template\.update                            |
| Marketing | Pass            | addInstance            | alipay\.pass\.instance\.add                               |
| Marketing | Pass            | updateInstance         | alipay\.pass\.instance\.update                            |
| Marketing | TemplateMessage | send                   | alipay\.open\.app\.mini\.templatemessage\.send            |
| Marketing | OpenLife        | createImageTextContent | alipay\.open\.public\.message\.content\.create            |
| Marketing | OpenLife        | modifyImageTextContent | alipay\.open\.public\.message\.content\.modify            |
| Marketing | OpenLife        | sendText               | alipay\.open\.public\.message\.total\.send                |
| Marketing | OpenLife        | sendImageText          | alipay\.open\.public\.message\.total\.send                |
| Marketing | OpenLife        | sendSingleMessage      | alipay\.open\.public\.message\.single\.send               |
| Marketing | OpenLife        | recallMessage          | alipay\.open\.public\.life\.msg\.recall                   |
| Marketing | OpenLife        | setIndustry            | alipay\.open\.public\.template\.message\.industry\.modify |
| Marketing | OpenLife        | getIndustry            | alipay\.open\.public\.setting\.category\.query            |
| Util      | AES             | decrypt                | -                                                         |
| Util      | AES             | encrypt                | -                                                         |
| Util      | Generic         | execute                | -                                                         |

> 注：更多高频场景的API持续更新中，敬请期待。

您还可以前往[API Doc](./APIDoc.md)查看每个API的详细使用说明。

# 变更日志
每个版本的详细更改记录在[变更日志](./CHANGELOG)中。

> 版本号最末一位修订号的增加（比如从`1.0.0`升级为`1.0.1`），意味着SDK的功能没有发生任何变化，仅仅是修复了部分Bug。该类升级可能不会记录在变更日志中。

> 版本号中间一位次版本号的增加（比如从`1.0.0`升级为`1.1.0`），意味着SDK的功能发生了可向下兼容的新增或修改。

> 版本号首位主版本号的增加（比如从`1.0.0`升级为`2.0.0`），意味着SDK的功能可能发生了不向下兼容的较大调整，升级主版本号后请注意做好相关的回归测试工作。

# 相关
* [支付宝开放平台](https://open.alipay.com/platform/home.htm)
* [支付宝开放平台文档中心](https://docs.open.alipay.com/catalog)
* [最新源码](https://github.com/alipay/alipay-easysdk)

# 许可证
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Falipay%2Falipay-easysdk.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Falipay%2Falipay-easysdk?ref=badge_large)

# 交流与技术支持
不管您在使用Alipay Easy SDK的过程中遇到任何问题，欢迎在当前 GitHub [提交 Issues](https://github.com/alipay/alipay-easysdk/issues/new)。

您也可以使用钉钉扫描下方二维码，与更多开发者和支付宝工程师共同交流。

![支付宝官方Alipay Easy SDK开源交流群](https://gw.alipayobjects.com/mdn/rms_0e15fa/afts/img/A*f4urToyhLUIAAAAAAAAAAABkARQnAQ)

