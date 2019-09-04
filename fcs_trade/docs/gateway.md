# 交易接口

## 如何连接

从gateway文件夹上引入接口程序，通过add_gateway()函数调动，最终展示到图形化操作界面VN Trader中。



&nbsp;

### 加载需要用的接口

加载接口示例在根目录"tests\trader"文件夹的run.py文件中。
- 从gateway文件夹引入接口类文件，如from fcs_trade.gateway.ctp import CtpGateway;
- 创建事件引擎对象并且通过add_gateway()函数添加接口程序;
- 创建图形化对象main_window，以VN Trader操作界面展示出来。


```
from fcs_trade.gateway.ctp import CtpGateway

def main():
    """"""
    qapp = create_qapp()
    main_engine = MainEngine(event_engine)
    main_engine.add_gateway(CtpGateway)
    main_window = MainWindow(main_engine, event_engine)
    main_window.showMaximized()
    qapp.exec()
```

&nbsp;


### 配置和连接

打开cmd窗口，使用命令“Python run.py"即可进入VN Trader操作界面。在左上方的菜单栏中点击"系统"->"连接CTP”按钮会弹出账号配置窗口，输入账号、密码等相关信息即连接接口。

连接接口的流程首先是初始化账户信息，然后调用connet()函数来连接交易端口和行情端口。
- 交易端口：查询用户相关信息（如账户资金、持仓、委托记录、成交记录）、查询可交易合约信息、挂撤单操作；
- 行情端口：接收订阅的行情信息推送、接收用户相关信息（如账户资金更新、持仓更新、委托推送、成交推送）更新的回调推送。


&nbsp;


### 修改json配置文件

接口配置相关保存在json文件中，放在如图C盘用户目录下的.vntrader文件夹内。


所以要修改接口配置文件，用户即可以在图形化界面VN Trader内修改，也可以直接在.vntrader修改json文件。
另外将json配置文件分离于fcs的好处在于：避免每次升级都要重新配置json文件。


&nbsp;





&nbsp;

## 接口分类

| 接口 |类型 | 
| ------ | :------: | 
| CTP | 期货 | 
| OES | 国内股票 |
| IB | 外盘股票、期货、期权 |
| FUTU | 国内股票、港股、美股 |
| TIGER | 国内股票、港股、美股 |
| BITMEX | 数字货币 |
| OKEX | 数字货币 |
| HUOBI | 数字货币 |



&nbsp;


## 接口详解

### BITMEX

#### 如何加载

先从gateway上调用BitmexGateway类；然后通过add_gateway()函数添加到main_engine上。
```
from vnpy.gateway.oes import BitmexGateway
main_engine.add_gateway(BitmexGateway)
```

&nbsp;


#### 相关字段

- 用户ID：ID
- 密码：Secret
- 会话数：3
- 服务器：REAL 或 TESTNET
- 代理地址：
- 代理端口：



&nbsp;


#### 获取账号

在BITMEX官网开户并且入金后可以获得API接入权限。



&nbsp;

### OKEX


#### 如何加载

先从gateway上调用OkexGateway类；然后通过add_gateway()函数添加到main_engine上。
```
from fcs_trade.gateway.oes import OkexGateway
main_engine.add_gateway(OkexGateway)
```

&nbsp;


#### 相关字段

- API秘钥：API Key
- 密码秘钥：Secret Key
- 会话数：3
- 密码：passphrase
- 代理地址：
- 代理端口：



&nbsp;


#### 获取账号

在OKEX官网开户并且入金后可以获得API接入权限。



&nbsp;

### 火币

#### 如何加载

先从gateway上调用HuobiGateway类；然后通过add_gateway()函数添加到main_engine上。
```
from fcs_trade.gateway.oes import HuobiGateway
main_engine.add_gateway(HuobiGateway)
```

&nbsp;


#### 相关字段

- API秘钥：API Key
- 密码秘钥：Secret Key
- 会话数：3
- 代理地址：
- 代理端口：



&nbsp;


#### 获取账号

在火币官网开户并且入金后可以获得API接入权限。