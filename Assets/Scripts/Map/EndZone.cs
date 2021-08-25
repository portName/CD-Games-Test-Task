using System;
using Portname.CDGamesTestTask;
using UnityEngine;

namespace Portname.CDGamesTestTask
{
    
    [DisallowMultipleComponent]
    public class EndZone : MonoBehaviour
    {
        [SerializeField] private Transform _translateOnObject;

        public event Action<Vector3, Quaternion> EndZoneEvent;
        
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player>();
            
            if (player == null) return;
            
            EndZoneEvent?.Invoke(_translateOnObject.position, Quaternion.identity);
           
        }
    }
}