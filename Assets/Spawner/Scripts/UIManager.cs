using System;
using System.Diagnostics;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace Spawner
{
    public delegate void ChangeInputValue(string type, float value);
    public class UIManager : MonoBehaviour
    {
        public event ChangeInputValue OnInputChanged;

        [SerializeField] private TMP_InputField intervalInputField;
        [SerializeField] private TMP_InputField speedInputField;
        [SerializeField] private TMP_InputField distanceInputField;

        private Manager _manager;

        private void Awake() {
        }
        
        private void Start() {
            _manager = Manager.Instance;
            
            intervalInputField.onEndEdit.AddListener(delegate { CheckFieldAndInvokeEvent(intervalInputField); });
            speedInputField.onEndEdit.AddListener(delegate { CheckFieldAndInvokeEvent(speedInputField); });
            distanceInputField.onEndEdit.AddListener(delegate { CheckFieldAndInvokeEvent(distanceInputField); });

            _manager.OnValueChanged += SetUIText;
            SetUIText(TypeOfValue.Interval);
            SetUIText(TypeOfValue.Speed);
            SetUIText(TypeOfValue.Distance);
        }

        private void CheckFieldAndInvokeEvent(TMP_InputField field)
        {
            float value = 0;
            
            if (field.text.Length > 0) {
                value = float.Parse(field.text, NumberStyles.Float);    
            }
            
            OnInputChanged?.Invoke(field.name, value);
        }

        private void SetUIText(TypeOfValue type) {
            if (type == TypeOfValue.Interval) {
                intervalInputField.text = _manager.Interval.ToString();
            }
            if (type == TypeOfValue.Speed) {
                speedInputField.text = _manager.Speed.ToString();
            }
            if (type == TypeOfValue.Distance) {
                distanceInputField.text = _manager.Distance.ToString();
            }
        }
    }
}


