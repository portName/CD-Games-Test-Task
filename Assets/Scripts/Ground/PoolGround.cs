using System.Collections.Generic;
using UnityEngine;

namespace Portname.CDGamesTestTask
{
    [DisallowMultipleComponent]
    public class PoolGround : MonoBehaviour, IPool<Ground>
    {
        private Stack<Ground> _groundsPassivePool;
        [SerializeField] private List<Ground> _groundsActivePool;

        #region Singleton

            public static PoolGround Instance { get; private set; }

            private void Awake()
            {
                if (Instance != null && Instance != this) {
                    Destroy(gameObject);
                } else {
                    Instance = this;
                }
                _groundsPassivePool = new Stack<Ground>();
                _groundsActivePool = new List<Ground>();
                foreach (var ground in GetComponentsInChildren<Ground>())
                {
                    AddPassiveGround(ground);
                }
            }

        #endregion
        
        public Ground CreateObjectFromPool(Vector3 positionCreate, Quaternion quaternionCreate)
        {
            var ground = _groundsPassivePool.Pop().Create(positionCreate, quaternionCreate);
            
            AddActiveGround(ground);
            return ground;
        }

        private void AddPassiveGround(Ground ground)
        {
            ground.gameObject.SetActive(false);
            _groundsPassivePool.Push(ground);
        }
        private void AddActiveGround(Ground ground)
        {
            ground.DeleteEvent += DeleteActiveGround;
            ground.gameObject.SetActive(true);
            _groundsActivePool.Add(ground);
        }

        private void DeleteActiveGround(Ground ground)
        {
            _groundsActivePool.Remove(ground);
            AddPassiveGround(ground);
            ground.DeleteEvent -= DeleteActiveGround;
        }
    }
}