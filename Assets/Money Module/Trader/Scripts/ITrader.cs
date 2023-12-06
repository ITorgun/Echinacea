using System;

namespace Assets.Money_Module.Trader
{
    public interface ITrader
    {
        public event Action TradingStarted;
        public event Action TradingEnded;
    }
}
