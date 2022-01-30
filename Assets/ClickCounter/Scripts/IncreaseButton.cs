using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseButton : MonoBehaviour
{
    private Manager _manager;
    private Button _button;
    
    private void Start() {
        _manager = Manager.Instance;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(AddCount);
    }
    private void AddCount() {
        _manager.ClickCount++;
    }
}
