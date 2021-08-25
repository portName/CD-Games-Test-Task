using System;
using UnityEngine;

namespace Portname.CDGamesTestTask
{
    [RequireComponent(typeof(Collider))]
    [DisallowMultipleComponent]
    public class BoardPack : MonoBehaviour, IDelete<BoardPack>, ICreate<BoardPack>
    {
        [SerializeField] private int _amount;

        public int AmountBoard()
        {
            return _amount;
        }
        private void OnTriggerEnter(Collider other)
        {
            var pickUpAction = other.gameObject.GetComponent<IPickUp<BoardPack>>();
            
            if (pickUpAction == null) return;
            
            pickUpAction.PickUp(this);
            Delete();

        }

        #region Interface Delete

            public event Action<BoardPack> DeleteEvent;
            public void Delete()
            {
                gameObject.SetActive(false);
            }

        #endregion

        #region Interface Create

        public BoardPack Create(Vector3 positionCreate, Quaternion quaternionCreate)
        {
            transform.SetPositionAndRotation(positionCreate, quaternionCreate);
            gameObject.SetActive(true);
            return this;
        }

        #endregion
    }
}