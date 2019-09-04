from pathlib import Path

from fcs_trade.trader.app import BaseApp
from fcs_trade.trader.constant import Direction
from fcs_trade.trader.object import TickData, BarData, TradeData, OrderData
from fcs_trade.trader.utility import BarGenerator, ArrayManager

from .engine import RecorderEngine, APP_NAME


class DataRecorderApp(BaseApp):
    """"""
    app_name = APP_NAME
    app_module = __module__
    app_path = Path(__file__).parent
    display_name = "行情记录"
    engine_class = RecorderEngine
    widget_name = "RecorderManager"
    icon_name = "recorder.ico"
