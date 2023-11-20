using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IValueable
{
    int Value { get; }

    void AddCoin(ICollectorValueable moneyPicker);
    void Remove();
}
