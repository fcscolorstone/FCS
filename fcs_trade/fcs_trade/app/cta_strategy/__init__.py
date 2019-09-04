from pathlib import Path

from fcs_trade.trader.app import BaseApp
from fcs_trade.trader.constant import Direction
from fcs_trade.trader.object import TickData, BarData, TradeData, OrderData
from fcs_trade.trader.utility import BarGenerator, ArrayManager

from .base import APP_NAME, StopOrder
from .engine import CtaEngine
from .backtesting import BacktestingEngine, OptimizationSetting
from .template import CtaTemplate, CtaSignal, TargetPosTemplate


class CtaStrategyApp(BaseApp):
    """"""

    app_name = APP_NAME
    app_module = __module__
    app_path = Path(__file__).parent
    display_name = "CTA策略"
    engine_class = CtaEngine
    widget_name = "CtaManager"
    icon_name = "cta.ico"
