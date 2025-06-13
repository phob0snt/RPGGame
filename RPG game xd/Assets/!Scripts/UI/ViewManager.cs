using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [SerializeField] private View _startView;
    [SerializeField] private View[] _views;

    private View _currentView;

    private readonly Stack<View> _history = new();

    private void Awake()
    {
        foreach (var view in _views)
        {
            view.Show();
            view.Initialize();
            view.Hide();
        }
        if (_startView != null)
            Show(_startView, true);
    }
    
    public T GetView<T>() where T : View
    {
        foreach (var view in _views)
        {
            if (view is T resView)
                return resView;
        }
        return null;
    }

    public void Show<T>(bool remember = true, bool hidePrevious = true) where T: View
    {
        foreach (var view in _views)
        {
            if (view is T)
            {
                if (_currentView != null)
                {
                    if (remember)
                    {
                        _history.Push(_currentView);
                    }
                    if (hidePrevious)
                    {
                        _currentView.Hide();
                    }
                }
                if (_history.Contains(view))
                {
                    while (_history.Peek() != view)
                        _history.Pop();
                    view.Show();
                }
                else
                    view.Show();
                _currentView = view;
            }
        }
    }

    public void Show(View view, bool remember = true, bool hidePrevious = true)
    {
        if (_currentView != null)
        {
            if (remember)
            {
                _history.Push(_currentView);
            }
            if (hidePrevious)
            {
                _currentView.Hide();
            }
        }
        if (_history.Contains(view))
        {
            while (_history.Peek() != view)
                _history.Pop();
            view.Show();
        }    
        else
            view.Show();
        _currentView = view;
    }

    public void ShowLast()
    {
        if (_history.Count != 0)
            Show(_history.Pop(), false);
    }

    //public bool CheckIfViewEnabled<T>() where T : View
    //{
    //    foreach (var view in _history)
    //    {
    //        Debug.Log(view.GetType());
    //        if (view is T)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    public bool IsCurrentView<T>() where T : View
    {
        return _currentView is T;
    }
}
