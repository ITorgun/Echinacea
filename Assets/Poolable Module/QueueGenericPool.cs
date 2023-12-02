using Assets.Enemy_Module.Grounded.Robot_Bomb.Configs;
using System;
using System.Collections.Generic;

public class QueueGenericPool<T> : IPool<T>, IDisposable
{
    private readonly int _maxSize;
    private Queue<T> _elements;

    private readonly Func<T> CreateElementFunc;
    private readonly Action<T> OnGetting;
    private readonly Action<T> OnReleasing;
    private readonly Action<T> OnDestorying;

    public int CountAll { get; private set; }
    public int CountActive => CountAll - CountInactive;
    public int CountInactive => _elements.Count;

    public QueueGenericPool(Func<T> CreateElementFunc, Action<T> onGetting = null, Action<T> onReleasing = null,
        Action<T> onDestorying = null, int maxSize = 10000)
    {
        if (CreateElementFunc == null)
        {
            throw new ArgumentNullException("createFunc");
        }

        if (maxSize <= 0)
        {
            throw new ArgumentException("Max Size must be greater than 0", "maxSize");
        }
        
        _maxSize = maxSize;
        _elements = new Queue<T>(maxSize);

        this.CreateElementFunc = CreateElementFunc;
        OnGetting = onGetting;
        OnReleasing = onReleasing;
        OnDestorying = onDestorying;
    }

    public virtual T Get()
    {
        T element;
        if (_elements.Count == 0)
        {
            element = CreateElementFunc.Invoke();
            CountAll++;
        }
        else
        {
            element = _elements.Dequeue();
        }

        OnGetting?.Invoke(element);

        return element;
    }

    public virtual void ClearPool()
    {
        foreach (T item in _elements)
        {
            OnDestorying.Invoke(item);
        }

        _elements.Clear();
        CountAll = 0;
    }

    public virtual void Release(T element)
    {
        if (_elements.Contains(element))
        {
            throw new InvalidOperationException("Trying to release an object that has already been released to the pool.");
        }

        OnReleasing?.Invoke(element);

        if (CountInactive < _maxSize)
        {
            _elements.Enqueue(element);
        }
        else
        {
            OnDestorying?.Invoke(element);
        }
    }

    public void Dispose()
    {
        _elements.Clear();
    }
}
