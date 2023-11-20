using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitcoin : MonoBehaviour, IValueable
{
    [field: SerializeField] public int Value {get; private set;}

    public void AddCoin(ICollectorValueable moneyPicker)
    {
        moneyPicker.Add(Value);
    }

    public void Remove()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ICollectorValueable collector))
        {
            collector.Add(Value);
            Remove();
        }
    }
}
