using System;
using UnityEngine;

public abstract class UIElement : MonoBehaviour
{
    protected IDisposable _subscription;
    public virtual void Initialize() { }
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _subscription?.Dispose();
    }
}
