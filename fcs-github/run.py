# encoding: UTF-8

# 重载sys模块，设置默认字符串编码方式为utf8
#try:
#    reload         # Python 2
#except NameError:  # Python 3
#    from importlib import reload
import sys
import datetime
#reload(sys)
#sys.setdefaultencoding('utf8')

# vn.trader模块
from fcs_trade.event import EventEngine
from fcs_trade.trader.engine import MainEngine
from fcs_trade.trader.ui import create_qapp

# 加载底层接口
from fcs_trade.gateway.huobi import HuobiGateway
from fcs_trade.gateway.idcm import IdcmGateway
#, okexGateway, okexfGateway,
                                 #binanceGateway, bitfinexGateway,
                                 #bitmexGateway, fcoinGateway,
                                 #bigoneGateway,
                                 #lbankGateway,
                                 #coinbaseGateway, ccxtGateway)

# 加载上层应用
#from fcs_trade.trader.app import (algoTrading)


#from fcs_trade.trader.app import (riskManager)  # 风控模块
#from fcs_trade.trader.app import (dataRecorder)
#from fcs_trade.trader.app import (optionMaster)
#from fcs_trade.trader.app import (rpcService)
#from fcs_trade.trader.app import (rtdService)
#from fcs_trade.trader.app import (spreadTrading)
#from fcs_trade.trader.app import (tradeCopy)

# 当前目录组件
from fcs_trade.trader.ui.mainwindow import MainWindow


def main():
    """主程序入口"""
    # 创建Qt应用对象
    qApp = create_qapp()

    # 创建事件引擎
    ee = EventEngine()

    # 创建主引擎
    me = MainEngine(ee)

    # 添加交易接口
    #me.addGateway(okexfGateway)
    #me.addGateway(ccxtGateway)
    #me.addGateway(coinbaseGateway)
    #me.addGateway(lbankGateway)
    #me.addGateway(bigoneGateway)
    #me.addGateway(fcoinGateway)
    #me.addGateway(bitmexGateway)
    me.add_gateway(IdcmGateway)
    me.add_gateway(HuobiGateway)
    #me.addGateway(okexGateway)
    #me.addGateway(binanceGateway)
    #me.addGateway(bitfinexGateway)


    # 创建主窗口
    mw = MainWindow(me, ee)
    mw.showMaximized()

    # 在主线程中启动Qt事件循环
    sys.exit(qApp.exec_())


if __name__ == '__main__':
    main()
