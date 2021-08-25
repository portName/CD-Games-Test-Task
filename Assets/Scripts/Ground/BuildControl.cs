using System;
using UnityEngine;

namespace Portname.CDGamesTestTask
{
    [RequireComponent(typeof(BuildGround))]
    [RequireComponent(typeof(BuildMovement))]
    [DisallowMultipleComponent]
    public class BuildControl : MonoBehaviour, IDelete<BuildControl>
    {
        #region Private Serialize Field

            [SerializeField] private Transform _target;
            [SerializeField] private Vector3 _offset;
            [SerializeField] private int _amountGroundFront;
            [SerializeField] private BuildRobot _buildRobot;

        #endregion

        #region Private Fields

            private BuildGround _buildGround;
            private BuildMovement _buildMovement;
            private int _hasAmountGroundFront;
            private Vector3 _startBuildPosition;

        #endregion
        
        #region Singleton

            public static BuildControl Instance { get; private set; }

            private void Awake()
            {
                if (Instance != null && Instance != this) {
                    Destroy(gameObject);
                } else {
                    Instance = this;
                }
                _buildGround = GetComponent<BuildGround>();
                _buildMovement = GetComponent<BuildMovement>();
            }

        #endregion

        #region Custom Methods

            public void OffsetWithBuild(Inventory inventory)
            {
                _buildGround.Build(inventory);
                _buildRobot?.Activate();
                ValueWithBuild();
                
                _buildMovement.MoveOffsetByBuild(
                    _target.position, 
                    TapInput.Instance.GetHieghtBuild(),
                    _startBuildPosition,
                    _hasAmountGroundFront,
                    _buildGround.NeedDistanceBetweenGround(),
                    _buildGround.LastGroundPosition()
                    );
            }
            public void OffsetWithoutBuild()
            {
                _buildRobot?.Disactivate();
                _buildMovement.MoveOffset(_target.position, _offset);
                DefaultValue();
            }

            private void DefaultValue()
            {
                _startBuildPosition = default;
                _hasAmountGroundFront = 0;
            }
            private void ValueWithBuild()
            {
               
                if (_startBuildPosition == default)
                {
                    _startBuildPosition = transform.position;
                }
                
                if (_hasAmountGroundFront != _amountGroundFront)
                {
                    _hasAmountGroundFront += 1;
                }
            }
        #endregion

        #region Interface Delete

                public event Action<BuildControl> DeleteEvent;
                public void Delete()
                {
                    enabled = false;
                }

        #endregion
    }
}