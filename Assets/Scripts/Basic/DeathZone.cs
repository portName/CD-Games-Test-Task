using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portname.CDGamesTestTask
{
    [RequireComponent(typeof(Collider))]
    [DisallowMultipleComponent]
    public class DeathZone : MonoBehaviour
    {
        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player>();
            var builder = other.GetComponent<BuildControl>();
            if (player != null)
            {
                _collider.isTrigger = false;
                player.Delete();
            }
            builder?.Delete();
        }
        private void OnCollisionStay(Collision other)
        {
            var player = other.gameObject.GetComponent<Player>();
            var builder = other.gameObject.GetComponent<BuildControl>();
            player?.Delete();
            builder?.Delete();
            
        }
    }
}
