using System.Collections;
using UnityEngine;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject cubePrefab;
        private Manager _manager;
        
        public int cubeCount;


        private void Start() {
            _manager = Manager.Instance;
            _manager.OnValueChanged += Reset;
            Reset(TypeOfValue.Interval);
        }
        
        private void Update() {
        }

        private void Reset(TypeOfValue type) {
            if (type == TypeOfValue.Interval) {
                CancelInvoke("SpawnCube");
                InvokeRepeating("SpawnCube",0,_manager.Interval);
            }
        }

        private void SpawnCube() {
            if (_manager.Distance != 0) {
                Debug.Log($"Spawn Cube number: {cubeCount}");
                cubeCount++;
                Instantiate(cubePrefab, transform.position, Quaternion.identity);
            }
        }
    }
}


