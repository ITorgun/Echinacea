namespace Assets.MoneyModule
{
    public interface IValueable
    {
        int Value { get; }

        void AddCoin(ICollectorValueable moneyPicker);
        void Remove();
    }
}