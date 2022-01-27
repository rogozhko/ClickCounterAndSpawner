using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawner
{
    public enum TypeOfValue {
        Interval,
        Speed,
        Distance
    }
    
    public delegate void ChangeValueDelegate(TypeOfValue type);
    public class Manager : MonoBehaviour
    {
        public static Manager Instance { get; private set; }
        [SerializeField] private UIManager uiManager;

        public event ChangeValueDelegate OnValueChanged;

        #region Properties

        [SerializeField] private float _interval;
        public float Interval {
            get => _interval;
            set {
                _interval = value;
                OnValueChanged?.Invoke(TypeOfValue.Interval);
                // Debug.Log($"Interval: {value}");
            }
        }

        [SerializeField] private float _speed;
        public float Speed {
            get => _speed;
            set {
                _speed = value;
                OnValueChanged?.Invoke(TypeOfValue.Speed);
                // Debug.Log($"Speed: {value}");
            }
        }

        [SerializeField] private float _distance;
        public float Distance {
            get => _distance;
            set {
                _distance = value;
                OnValueChanged?.Invoke(TypeOfValue.Distance);
                // Debug.Log($"Distance: {value}");
            }
        }
        #endregion

        private void Awake() {
            Instance = this;
            
            // Set start values
            Interval = 0.3f;
            Speed = 20;
            Distance = 25;
        }
        
        private void Start() {
            if (uiManager != null) {
                uiManager.OnInputChanged += ChangeValue;
            }
        }
        
        private void ChangeValue(string type,float value) {
            if (type == "SpeedIF") Speed = value;
            if (type == "DistanceIF") Distance = value;
            if (type == "IntervalIF") Interval = value;
        }
    }
}
