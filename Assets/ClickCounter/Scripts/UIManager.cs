using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private Manager _manager;
    [SerializeField] private TMP_Text uiText;
    
    void Start()
    {
        _manager = Manager.Instance;
        _manager.OnChangeClickCount += SetUI;
    }
    
    private void SetUI()
    {
        Debug.Log("Set UI");
        uiText.text = $"Click count: {_manager.ClickCount}";
    }
}
