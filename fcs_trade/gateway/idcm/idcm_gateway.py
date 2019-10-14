# encoding: UTF-8

'''
IDCM交易接口
'''
from __future__ import print_function

import json
import hashlib
import hmac
import sys
import base64
import zlib
from datetime import timedelta, datetime
from copy import copy

from fcs_trade.event import Event
from fcs_trade.api.rest import RestClient, Request
from fcs_trade.api.websocket import WebsocketClient
#from fcs_trade.trader.vtFunction import getJsonPath
from fcs_trade.trader.gateway import BaseGateway
from fcs_trade.trader.object import (
    TickData,
    OrderData,
    LogData,
    DealData,
    TradeData,
    AccountData,
    ContractData,
    OrderRequest,
    CancelRequest,
    SubscribeRequest
)
from fcs_trade.trader.utility import getJsonPath
from fcs_trade.trader.event import EVENT_TIMER
#from threading import Thread

REST_HOST = 'https://api.IDCM.cc:8323'
#WEBSOCKET_HOST = 'wss://real.idcm.cc:10330/websocket'
EXCHANGE_IDCM = "IDCM"

# 内外盘
#dealStatusMap = {}
#dealStatusMap[TRADED_BUY] = 2   # 外盘
#dealStatusMap[TRADED_SELL] = 1  # 内盘

# 委托状态类型映射
#orderStatusMap = {}
#orderStatusMap[STATUS_CANCELLED] = -2
#orderStatusMap[STATUS_NOTVALID] = -1
#orderStatusMap[STATUS_NOTTRADED] = 0
#orderStatusMap[STATUS_PARTTRADED] = 1
#orderStatusMap[STATUS_ALLTRADED] = 2
#orderStatusMap[STATUS_ORDERED] = 3

# 方向和订单类型映射
#directionMap = {}
#directionMap[(DIRECTION_BUY)] = 0
#directionMap[(DIRECTION_SELL)] = 1

#orderTypeMap = {}
#orderTypeMap[(PRICETYPE_MARKETPRICE)] = 0
#orderTypeMap[(PRICETYPE_LIMITPRICE)] = 1

#dealStatusMapReverse = {v: k for k, v in dealStatusMap.items()}
#orderStatusMapReverse = {v: k for k, v in orderStatusMap.items()}
#directionMapReverse = {v: k for k, v in directionMap.items()}
#orderTypeMapReverse = {v: k for k, v in orderTypeMap.items()}

#错误码对应表
errMsgMap = {}
errMsgMap[10001] = '验证失败'
errMsgMap[10002] = '系统错误'
errMsgMap[10003] = '该连接已经请求了其他用户的实时交易数据'
errMsgMap[10005] = 'SecretKey不存在'
errMsgMap[10006] = 'Api_key不存在'
errMsgMap[10007] = '签名不匹配'
errMsgMap[10017] = 'API鉴权失败'

errMsgMap[41000] = '签名不匹配'
errMsgMap[41017] = 'API鉴权失败'

errMsgMap[51003] = '账号被冻结'
errMsgMap[51004] = '用户不存在'
errMsgMap[51011] = '交易品种不存在'

errMsgMap[51018] = '虚拟币不存在'
errMsgMap[51022] = '申请数量太少'
errMsgMap[51021] = '虚拟币资产信息不足'
errMsgMap[51023] = '可用数量不足'
errMsgMap[51026] = '数据不存在'
errMsgMap[51027] = '提币申请状态只有在，申请状态才能撤销'

errMsgMap[51040] = '货币资产信息不存在'
errMsgMap[51041] = '现金资产不足'
errMsgMap[51043] = '申报价无效'
errMsgMap[51044] = '申报数量无效'
errMsgMap[51045] = '最小交易量无效'
errMsgMap[51046] = '最小金额无效'
errMsgMap[51047] = '金额变动量无效'
errMsgMap[51048] = '最小申报变动量无效'

errMsgMap[51089] = '非法的站点'
errMsgMap[51092] = '访问过快'
errMsgMap[51111] = '钱包余额不足'
errMsgMap[51112] = '申报金额无效'


def getErrMsg(errcode):
    return errMsgMap[errcode]
    msg = '错误代码：%s, 错误信息：%s' % (data['code'], errMsg)
    self.gateway.writeLog(msg)


class IdcmGateway(BaseGateway):
    """IDCM接口"""
    # ----------------------------------------------------------------------
    def __init__(self, event_engine):
        """Constructor"""
        super().__init__(event_engine, 'IDCM')
        self.localID = 10000

        self.accountDict = {}
        self.orderDict = {}
        self.localOrderDict = {}
        #self.orderLocalDict = {}

        self.qryEnabled = False         # 是否要启动循环查询

        #self.restApi = IdcmRestApi(self)
        self.wsApi = WebsocketApi(self)

        self.fileName = 'GatewayConfig/' + self.gateway_name + '_connect.json'
        self.filePath = getJsonPath(self.fileName, __file__)
        #symbols_filepath = os.getcwd() + '\GatewayConfig' + '/' + self.fileName

    def connect(self):
        """连接"""
        try:
            f = open(self.filePath)
        except IOError:
            log = LogData()
            log.gateway_name = self.gateway_name
            log.logContent = '读取连接配置出错，请检查'
            self.onLog(log)
            return

        # 解析json文件
        setting = json.load(f)
        f.close()

        try:
            apiKey = str(setting['apiKey'])
            secretKey = str(setting['secretKey'])
            symbols = setting['symbols']
        except KeyError:
            log = LogData()
            log.gateway_name = self.gateway_name
            log.logContent = '连接配置缺少字段，请检查'
            self.onLog(log)
            return

        # 创建行情和交易接口对象
        try:
            self.restApi.connect(apiKey, secretKey, symbols)
        except Exception as e:
            print(e)
            print('restapi')

        try:
            self.wsApi.connect(apiKey, secretKey, symbols)
        except Exception as e:
            print(e)
            print('wsApi')

        # 初始化并启动查询
        #self.initQuery()

    def subscribe(self, subscribeReq):
        """订阅行情"""
        self.wsApi.subscribe(subscribeReq)

    # ----------------------------------------------------------------------
    def send_order(self, orderReq):
        """发单"""
        self.restApi.sendOrder(orderReq)

    # ----------------------------------------------------------------------
    def cancel_order(self, cancelOrderReq):
        """撤单"""
        self.restApi.cancelOrder(cancelOrderReq)

    def query_account(self):
        pass

    def query_position(self):
        pass

    def cancelAllOrders(self):
        """全部撤单"""
        self.restApi.cancelAllOrders()

    # ----------------------------------------------------------------------
    def close(self):
        """关闭"""
        #self.restApi.stop()
        self.wsApi.stop()

    # ----------------------------------------------------------------------
    def initQuery(self):
        """初始化连续查询"""
        if self.qryEnabled:
            # 需要循环的查询函数列表
            self.qryFunctionList = [self.queryInfo]

            self.qryCount = 0  # 查询触发倒计时
            self.qryTrigger = 4  # 查询触发点
            self.qryNextFunction = 0  # 上次运行的查询函数索引

            self.startQuery()

    # ----------------------------------------------------------------------
    def query(self, event):
        """注册到事件处理引擎上的查询函数"""
        self.qryCount += 1

        if self.qryCount > self.qryTrigger:
            # 清空倒计时
            self.qryCount = 0

            # 执行查询函数
            function = self.qryFunctionList[self.qryNextFunction]
            function()

            # 计算下次查询函数的索引，如果超过了列表长度，则重新设为0
            self.qryNextFunction += 1
            if self.qryNextFunction == len(self.qryFunctionList):
                self.qryNextFunction = 0

    # ----------------------------------------------------------------------
    def startQuery(self):
        """启动连续查询"""
        self.event_engine.register(EVENT_TIMER, self.query)

    # ----------------------------------------------------------------------
    def setQryEnabled(self, qryEnabled):
        """设置是否要启动循环查询"""
        self.qryEnabled = qryEnabled

    def processQueueOrder(self, data, historyFlag):
        for d in data['data']:
            # self.gateway.localID += 1
            # localID = str(self.gateway.localID)

            order = OrderData()
            order.gateway_name = self.gateway_name

            order.symbol = d['symbol']
            order.exchange = 'IDCM'
            order.vtSymbol = '.'.join([order.exchange, order.symbol])

            order.orderID = d['orderid']
            # order.vtOrderID = '.'.join([self.gateway_name, localID])
            order.vtOrderID = '.'.join([self.gateway_name, order.orderID])

            #order.price = float(d['price'])  # 委托价格
            order.price = float(d['price'])  # 委托价格
            order.avgprice = float(d['avgprice'])  # 平均成交价
            order.volume = float(d['amount']) + float(d['executedamount'])  # 委托数量
            order.tradedVolume = float(d['executedamount'])  # 成交数量
            order.status = orderStatusMapReverse[d['status']]  # 订单状态
            order.direction = directionMapReverse[d['side']]  # 交易方向   0 买入 1 卖出
            order.orderType = orderTypeMapReverse[d['type']]  # 订单类型  0	市场价  1	 限价

            dt = datetime.fromtimestamp(d['timestamp'])
            order.orderTime = dt.strftime('%Y-%m-%d %H:%M:%S')

            if order.status == STATUS_ALLTRADED:
                # order.vtTradeID =  '.'.join([self.gateway_name, order.orderID])
                if historyFlag:
                    self.onTrade(order)
                else:
                    self.onOrder(order)  # 普通推送更新委托列表
            else:
                self.onOrder(order)

    def writeLog(self, msg):
        """"""
        log = LogData()
        log.logContent = msg
        log.gateway_name = self.gateway_name

        event = Event(EVENT_LOG)
        event.dict_['data'] = log
        self.event_engine.put(event)


class WebsocketApi(WebsocketClient):
    def __init__(self, gateway):
        """Constructor"""
        super().__init__()

        self.gateway = gateway
        self.gateway_name = gateway.gateway_name

        self.apiKey = ''
        self.secretKey = ''
        self.symbols = ''

        self.accountDict = gateway.accountDict
        self.orderDict = gateway.orderDict
        self.localOrderDict = gateway.localOrderDict

        self.tradeID = 0
        self.callbackDict = {}
        self.channelSymbolDict = {}
        self.tickDict = {}
        self.dealDict = {}

    # ----------------------------------------------------------------------
    def unpackData(self, data):
        """重载"""
        return json.loads(zlib.decompress(data, -zlib.MAX_WBITS))

    # ----------------------------------------------------------------------
    def connect(self, apiKey, secretKey, symbols):
        """"""
        self.apiKey = apiKey
        self.secretKey = secretKey
        self.symbols = symbols

        self.start()
        #for symbol in symbols:
        #    self.subscribeMarketData(symbol)

    """
    def subscribeMarketData(self, symbol):
        # 订阅行情
        tick = TickData()
        tick.gateway_name = self.gateway_name
        tick.symbol = symbol
        tick.exchange = "IDCM"
        tick.vtSymbol = '.'.join([tick.symbol, tick.exchange])
        self.tickDict[symbol] = tick
    """

    def onConnect(self):
        """连接回调"""
        self.gateway.writeLog('Websocket API连接成功')
        self.login()

    def onData(self, data):
        """数据回调"""
        if 'Event' in data:
            if data['Event'] == "login":
                if data["Result"]:
                    # 连接成功,开始订阅
                    # return
                    self.subscribe()
                else:
                    msg = '错误代码：%s, 错误信息：%s' % (data['ErrorCode'], errMsgMap[int(data['ErrorCode'])])
                    self.gateway.writeLog(msg)
        elif 'channel' in data:
            # print(data)
            if 'depth' in data['channel']:
                self.onDepth(data)
            elif 'ticker' in data['channel']:
                self.onTick(data)
            elif 'deals' in data['channel']:
                self.onDeals(data)
            elif 'balance' in data['channel']:
                self.onBalance(data)
            elif 'order' in data['channel']:
                self.onOrder(data)

    def onOrder(self, data):
        self.gateway.processQueueOrder(data, historyFlag=0)

    # ----------------------------------------------------------------------
    def onDisconnected(self):
        """连接回调"""
        self.gateway.writeLog('Websocket API连接断开')

    # ----------------------------------------------------------------------
    def onPacket(self, packet):
        """数据回调"""
        d = packet[0]

        channel = d['channel']
        callback = self.callbackDict.get(channel, None)
        if callback:
            callback(d)

    @staticmethod
    def sign(apiKey, secretkey):
        # 拼接apikey = {你的apikey} & secret_key = {你的secretkey} 进行MD5，结果大写
        convertStr = "apikey=" + apiKey + "&secret_key=" + secretkey
        return hashlib.md5(convertStr.encode()).hexdigest().upper()

    def login(self):
        try:
            signature = self.sign(self.apiKey, self.secretKey)
            req = {
                "event": "login",
                "parameters": {
                    "ApiKey": self.apiKey,
                    "Sign": signature
                }
            }
            self.sendReq(req)
        except Exception as e:
            print(e)

    def subscribe(self):
        # 初始化
        for symbol in self.symbols:
            #l.append('ticker.' + symbol)
            #l.append('depth.L20.' + symbol)
            tick = TickData()
            tick.gateway_name = self.gateway_name
            tick.symbol = symbol
            tick.exchange = EXCHANGE_IDCM
            tick.vtSymbol = '.'.join([tick.exchange, tick.symbol])
            self.tickDict[symbol] = tick

            deal = DealData()
            deal.gateway_name = self.gateway_name
            deal.symbol = symbol
            deal.exchange = EXCHANGE_IDCM
            deal.vtSymbol = '.'.join([deal.exchange, deal.symbol])
            self.dealDict[symbol] = deal

        for symbol in self.symbols:
            # 订阅行情深度,支持5，10，20档
            channel = "idcm_sub_spot_" + symbol + "_depth_20"
            req = {
                'event': 'addChannel',
                'channel': channel
            }
            self.sendReq(req)

            # 订阅行情数据
            channel = "idcm_sub_spot_" + symbol + "_ticker"
            req = {
                'event': 'addChannel',
                'channel': channel
            }
            self.sendReq(req)

            # 订阅成交记录
            channel = "idcm_sub_spot_" + symbol + "_deals"
            req = {
                'event': 'addChannel',
                'channel': channel
            }
            self.sendReq(req)

    # ----------------------------------------------------------------------
    def onTick(self, d):
        """"""
        data = d['data']

        symbol = d['channel'].split('_')[3]
        tick = self.tickDict[symbol]
        tick.lastPrice = float(data['last'])
        tick.highPrice = float(data['high'])
        tick.lowPrice = float(data['low'])
        tick.volume = float(data['vol'])
        tick.datetime = datetime.fromtimestamp(data['timestamp'])
        tick.time = tick.datetime.strftime('%H:%M:%S')
        self.gateway.onTick(tick)

    def onDeals(self, d):
        """"""
        data = d['data'][0]

        symbol = d['channel'].split('_')[3]
        deal = self.dealDict[symbol]
        deal.price = float(data['price'])
        deal.volume = float(data['amount'])
        #deal.type = dealStatusMapReverse[data['type']]
        try:
            deal.datetime = datetime.fromtimestamp(data['timestamp'])
            deal.time = deal.datetime.strftime('%H:%M:%S')
            self.gateway.onDeal(deal)
        except Exception as e:
            print(e)

    # ----------------------------------------------------------------------
    def onDepth(self, d):
        try:
            symbol = d['channel'].split('_')[3]
            tick = self.tickDict[symbol]

            bids = d['data']['bids']
            asks = d['data']['asks']

            depth = 20
            # 买单
            for index in range(depth):
                para = "bidPrice" + str(index + 1)
                if index >= len(bids):
                    setattr(tick, para, 0)
                else:
                    setattr(tick, para, bids[index]['Price'])

                para = "bidVolume" + str(index + 1)
                if index >= len(bids):
                    setattr(tick, para, 0)
                else:
                    setattr(tick, para, float(bids[index]['Amount']))  # float can sum

            # 卖单
            for index in range(depth):
                para = "askPrice" + str(index + 1)
                if index >= len(asks):
                    setattr(tick, para, 0)
                else:
                    setattr(tick, para, asks[index]['Price'])

                para = "askVolume" + str(index + 1)
                if index >= len(asks):
                    setattr(tick, para, 0)
                else:
                    setattr(tick, para, float(asks[index]['Amount']))

            #tick.datetime = datetime.fromtimestamp(d['timestamp'])
            #tick.date = tick.datetime.strftime('%Y%m%d')
            #tick.time = tick.datetime.strftime('%H:%M:%S')

            self.gateway.onTick(copy(tick))
        except Exception as e:
            print(e)

    def onBalance(self, d):
        currency = d['channel'].split('_')[3]  # format:idcm_sub_spot_ETH_balance
        account = self.accountDict.get(currency, None)

        data = d['data']
        account.available = format(float(data['free']), ',.4f')
        account.margin = format(float(data['freezed']), ',.4f')

        account.balance = format(float(data['free'] + data['freezed']), ',.4f')

        self.gateway.onAccount(account)
