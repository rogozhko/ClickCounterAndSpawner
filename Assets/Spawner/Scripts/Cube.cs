using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawner
{
    public class Cube : MonoBehaviour
    {
        private Manager _manager;
        private float distance;
        
        void Start() {
            _manager = Manager.Instance;
            distance = _manager.Distance;
        }
        
        void Update() {
            if (transform.position.x < _manager.Distance) {
                transform.Translate(Vector3.right * Time.deltaTime*_manager.Speed);
            }

            else {
                Destroy(gameObject);
            }
        }
    }
}
