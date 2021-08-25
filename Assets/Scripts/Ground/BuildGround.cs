using UnityEngine;

namespace Portname.CDGamesTestTask
{
    [DisallowMultipleComponent]
    public class BuildGround : MonoBehaviour
    {

        #region Private Serialize Field

            [SerializeField] private float _minDistanceFromLastGround;
            [SerializeField] private float _waitBeforeDelete;
            [SerializeField] private int _needBoardForBuild;

        #endregion

        #region Private Fields

            private Vector3 _lastGroundPosition;

        #endregion
        
        #region Custom Methods

            public void Build(Inventory inventory)
            {
                if (!inventory.HasBoards() || !IsMinDistanceFromLastGround()) return;
                
                inventory.SubBoard(_needBoardForBuild);
                
                var transform1 = transform;
                var ground = PoolGround.Instance.CreateObjectFromPool(transform1.position, transform1.rotation);
                
                _lastGroundPosition = ground.transform.position;
                StartCoroutine(ground.WaitBeforeDelete(_waitBeforeDelete));
            }

            private bool IsMinDistanceFromLastGround()
            {
                return _minDistanceFromLastGround <= Vector3.Distance(transform.position, _lastGroundPosition);
            }

            public float NeedDistanceBetweenGround()
            {
                return _minDistanceFromLastGround;
            }

            public Vector3 LastGroundPosition()
            {
                return _lastGroundPosition;
            }
        #endregion
    }
}