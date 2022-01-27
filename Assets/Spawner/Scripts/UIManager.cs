using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Spawner
{
    public delegate void ChangeValue(string type, float value);
    public class UIManager : MonoBehaviour
    {
        public event ChangeValue OnInputChanged;

        [SerializeField] private TMP_InputField timeInputField;
        [SerializeField] private TMP_InputField speedInputField;
        [SerializeField] private TMP_InputField distanceInputField;

        private void Awake() {
        }
        
        private void Start() {
            timeInputField.onEndEdit.AddListener(delegate { CheckFieldAndInvokeEvent(timeInputField); });
            speedInputField.onEndEdit.AddListener(delegate { CheckFieldAndInvokeEvent(speedInputField); });
            distanceInputField.onEndEdit.AddListener(delegate { CheckFieldAndInvokeEvent(distanceInputField); });
        }

        private void CheckFieldAndInvokeEvent(TMP_InputField field)
        {
            float value = 0;
            
            if (field.text.Length > 0) {
                value = float.Parse(field.text, NumberStyles.Float);    
            }
            else
            {
                field.text = "0";
            }
            
            // Debug.Log($"{field.name}: {field.text}");
            
            OnInputChanged?.Invoke(field.name, value);
        }
    }
}


