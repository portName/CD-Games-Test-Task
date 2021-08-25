using System;
using UnityEngine;

namespace Portname.CDGamesTestTask
{
    [DisallowMultipleComponent]
    public class CameraTracking : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offsetFollow;
        [SerializeField] private Vector3 _offsetLook;
        [SerializeField] private float _speed;

        private void FixedUpdate()
        {
            Follow();

        }

        private void Follow()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + _offsetFollow, _speed);
        }
        
    }
}