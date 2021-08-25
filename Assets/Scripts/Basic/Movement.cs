using UnityEngine;

namespace Portname.CDGamesTestTask
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Collision))]
    [DisallowMultipleComponent]
    public class Movement : MonoBehaviour, IMove
    {
        #region Private Serialize Fields

            [SerializeField] private LayerMask _layerMaskGround;

        #endregion
        
        #region Private Fields

            private CharacterController _characterController;
            private const float _offsetFromCollider = 2f;
            private Collider _ground;

        #endregion

        #region MonoBehaviour CallBacks

            private void Awake()
            {
                _characterController = GetComponent<CharacterController>();
            }

        private void Update()
        {
            _ground = GetGround();
        }

        #endregion

        #region Custom Methods

            public void Move(Vector3 moveDirection, float speed)
            {
                _characterController.SimpleMove(moveDirection * speed);
            }

            public void Rotation(Quaternion rotate, float speed)
            {
                if (_ground == null) return;
                
                var rotation = transform.rotation;
                var newRotate = Quaternion.Euler(-_ground.transform.rotation.eulerAngles.x, 0, 0);

                
                transform.rotation = Quaternion.LerpUnclamped(rotation, newRotate, speed);
            }

            private Collider GetGround()
            {
                return Physics.Raycast(
                    transform.position, 
                    Vector3.down, 
                    out var hit,
                    _characterController.height + _offsetFromCollider, 
                    _layerMaskGround) ? hit.collider : null;
            }

        #endregion

    }
}