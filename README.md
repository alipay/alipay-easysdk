欢迎使用 Alipay **Easy** SDK。

打造**最好用**的支付宝开放平台SDK，Alipay Easy SDK让您享受**极简编程**体验，快速访支付宝开放平台开放的各项**高频能力**。

## 设计理念
不同于原有的`Alipay SDK`通用而全面的设计理念，Alipay Easy SDK对开放能力的API进行了更加贴近高频场景的精心设计与裁剪，简化了服务端调用方式，让调用API像使用语言内置的函数一样简便。

Alipay Easy SDK提供了与[能力地图](https://opendocs.alipay.com/mini/00am3f)相对应的代码组织结构，让开发者可以快速找到不同能力对应的API。

Alipay Easy SDK主要目标是提升开发者在**服务端**集成支付宝开放平台中各类高频场景下的开放能力的效率。

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
> 注：单元测试中使用到的私钥均进行了脱敏处理，会导致单元测试无法直接执行。您可以自行更改单元测试项目中的`TestAccout类`和`privateKey.json`文件中的相关账号与私钥配置后再执行单元测试。

### 多语言
Alipy Easy SDK基于阿里集团研发的`Tea DSL`工具链进行架构，通过DSL中间语言定义API模型，再基于DSL语言自动生成不同编程语言（Java、C#、PHP、TS等）实现的SDK，极大地提升了SDK能力的扩展效率和适用范围，同时也保证了相同的`Easy API`在不同语言生态中体验的一致性。

API模型的Tea DSL描述可以进入[tea](./tea)目录查看。

> Tea DSL相关介绍和编写规范正在筹划开放中，后续您也可以参与Tea DSL的编写贡献更多优秀的`Easy API`模型，而无需关心多语言问题。

## 语言支持情况
Alipay Easy SDK首发暂只支持`Java`、`C#`编程语言，更多编程语言支持正在积极新增中，敬请期待。

各语言具体的**使用说明**和**详细介绍**请点击如下链接进入各语言主目录查看。

[Java](./java)

[C#](./csharp)

<a name="spec"/>

## API组织规范

在Alipay Easy SDK中，API的引用路径与能力地图的组织层次一致，遵循如下规范

> Factory.能力名称.[场景名称.]接口方法名称( ... )

比如，如果您想要使用[能力地图](https://opendocs.alipay.com/mini/00am3f)中`营销能力`下的`模板消息`场景中的`小程序发送模板消息`，只需按如下形式编写调用代码即可。

`Factory.Marketing.TemplateMessage().send( ... )`


其中，接口方法名称通常是对其依赖的OpenAPI功能的一个最简概况，接口方法的出入参与OpenAPI中同名参数含义一致，可参照OpenAPI相关参数的使用说明。

Alipay Easy SDK将致力于保持良好的API命名，以符合开发者的编程直觉。

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
| Payment   | Common          | cancel                 | alipay\.trade\.close                                      |
| Payment   | HuaBei          | create                 | alipay\.trade\.create                                     |
| Payment   | FaceToFace      | pay                    | alipay\.trade\.pay                                        |
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

> 注：更多高频场景的API持续更新中，敬请期待。

# 变更日志
每个版本的详细更改记录在[变更日志](./CHANGELOG)中。

# 相关
* [支付宝开放平台](https://open.alipay.com/platform/home.htm)
* [支付宝开放平台文档中心](https://docs.open.alipay.com/catalog)
* [最新源码](https://github.com/alipay/alipay-easysdk)

# 许可证
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Falipay%2Falipay-easysdk.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Falipay%2Falipay-easysdk?ref=badge_large)

# 交流与技术支持
不管您在使用Alipay Easy SDK的过程中遇到任何问题，欢迎在当前 GitHub [提交 Issues](https://github.com/alipay/alipay-easysdk/issues/new)。

