using UnityEngine;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject cube;
        private GameObject newCube = null;

        [SerializeField] private UIManager uiManager;

        public int cubeCount;

        #region Properties
        // timeInterval, время, через которое спавнится новый куб
        private float _interval;
        public float Interval {
            get => _interval;
            set { _interval = value; }
        }
        // Скорость, с которой куб перемещается
        private float _speed;
        public float Speed {
            get => _speed;
            set { _speed = value; }
        }
        // Расстояние на которое передвигается
        private float _distance;
        public float Distance {
            get => _distance;
            set {
                _distance = value; 
                Debug.Log($"Distance: {value}");
            }
        }
        #endregion
        

        private void Start() {
            if (cube != null || Distance != 0) {
                SpawnNewCube();
            }

            if (uiManager != null) {
                uiManager.OnInputChanged += ChangeValue;
            }
        }

        private void ChangeValue(string type,float value) {
            Debug.Log(type);
            
            if (type == "SpeedIF") {
                Debug.Log($"Speed value in Spawner changed to {value}");
                Speed = value;
            }

            if (type == "DistanceIF") Distance = value;
        }

        private void Update() {
            if (newCube != null && newCube.transform.position.x < _distance) {
                MoveCube();
            }
            else
            {
                Destroy(newCube);
                SpawnNewCube();
            }
        }

        private void SpawnNewCube() {
            newCube = Instantiate(cube, transform.position, Quaternion.identity);
            cubeCount++;
        }

        private void MoveCube() {
            newCube.transform.Translate(Vector3.right*Time.deltaTime * _speed);
        }
    }
}


