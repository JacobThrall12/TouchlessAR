using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    private void Awake()
    {
        instance = this;
    }

    public event Action NextItem, PrevItem;

    public void OnNext() => NextItem?.Invoke();
    public void OnPrior() => PrevItem?.Invoke();
}
