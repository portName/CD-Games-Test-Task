using System;
using UnityEngine;

namespace Portname.CDGamesTestTask
{
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Inventory))]
    [DisallowMultipleComponent]
    public class Player : MonoBehaviour, IDelete<Player>, IPickUp<BoardPack>
    {
        #region Private Serialize Field

            [SerializeField] private float _speedMove;
            [SerializeField] private float _speedRotate;

        #endregion

        #region Private Fields

            private Movement _movement;
            private Inventory _inventory;
            private BuildControl _buildControl;

        #endregion
        
        #region Singleton

            public static Player Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) {
                Destroy(gameObject);
            } else {
                Instance = this;
            }
            _movement = GetComponent<Movement>();
            _inventory = GetComponent<Inventory>();
        }

        #endregion

        #region MonoBehaviour Callbacks

            private void Start()
            {
                _buildControl = BuildControl.Instance;
            }

            private void FixedUpdate()
            {
                _movement.Move( Vector3.forward, _speedMove);
                _movement.Rotation( Quaternion.identity, _speedRotate);
                if (TapInput.Instance.IsBuild() && _buildControl.isActiveAndEnabled)
                {
                    _buildControl.OffsetWithBuild(_inventory);
                }
                else
                {
                    _buildControl.OffsetWithoutBuild();
                }
            }
        #endregion

        #region Interface Delete

            public event Action<Player> DeleteEvent;
            public void Delete()
            {
                APP.EndGame();
            }

        #endregion

        #region Interface PickUp

            public void PickUp(BoardPack pickUpObj)
            {
                _inventory.AddBoard(pickUpObj.AmountBoard());
            }

        #endregion

        #region Custom Methods

            public Inventory GetInventory()
            {
                return _inventory;
            }

        #endregion
    }
}
