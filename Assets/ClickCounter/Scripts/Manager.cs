using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ChangeClickCount();

public class Manager : MonoBehaviour
{
    public event ChangeClickCount OnChangeClickCount = null;

    // Singleton для доступа к свойству ClickCount
    public static Manager Instance { get; private set; }


    private int _clickCount;
    public int CLickCount {
        get => _clickCount;
        set
        {
            _clickCount = value;
            OnChangeClickCount?.Invoke();
        }
    }
    
    public void Awake() {
        Instance = this;
        OnChangeClickCount += ShowInConsole;
    }

    public void ShowInConsole() {
        Debug.Log($"Change value {CLickCount}");
    }
}


