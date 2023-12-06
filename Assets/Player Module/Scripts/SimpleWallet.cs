using System;
using UnityEngine;

public class SimpleWallet : IWallet
{
    private int _wallet;

    public int Value { get => _wallet; private set => _wallet = value; }

    public event Action<int> Changed;

    public SimpleWallet(int value)
    {
        if (value < 0)
            throw new Exception("Wallet's less than zero");

        Value = value;
    }

    public void Add(int value)
    {
        Value += value;
        Debug.Log("Value: " + Value);
        Changed?.Invoke(Value);
    }

    public bool TryReduce(int value)
    {
        if (value > Value)
            return false;

        Value -= value;
        Changed?.Invoke(Value);
        return true;
    }

    public void InitView()
    {
        Changed?.Invoke(Value);
    }
}
