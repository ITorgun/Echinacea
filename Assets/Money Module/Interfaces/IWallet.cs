using System;

public interface IWallet
{
    int Value { get; }

    void InitView();
    void Add(int value);
    bool TryReduce(int value);

    public event Action<int> Changed;
}
