using System;
using System.Collections;
using Portname.CDGamesTestTask;
using UnityEngine;
using UnityEngine.UI;

namespace Portname.CDGamesTestTask
{
    [RequireComponent(typeof(Collider))]
    [DisallowMultipleComponent]
    public class ShowTutorial : MonoBehaviour
    {
        [SerializeField] private GameObject _tutorial;
        [SerializeField] private float _disactivateAfterSeconds;
        private void Start()
        {
            Disactivate();
        }

        private void Activate()
        {
            _tutorial.gameObject.SetActive(true);
        }
        private void Disactivate()
        {
            _tutorial.gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player>();
            if (player == null) return;
            
            Activate();
            StartCoroutine(DeisactivateAfterSeconds());
        }

        private IEnumerator DeisactivateAfterSeconds()
        {
            yield return new WaitForSeconds(_disactivateAfterSeconds);
            Disactivate();
        }
        
    }
}