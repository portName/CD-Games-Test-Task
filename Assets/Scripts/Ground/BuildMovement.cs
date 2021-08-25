using UnityEngine;

namespace Portname.CDGamesTestTask
{
    public class BuildMovement : MonoBehaviour
    {
        public void MoveOffsetByBuild(
            Vector3 targetPosition, 
            float height, 
            Vector3 startBuildPosition, 
            int hasAmountGroundFront, 
            float needDistanceBetweenGround, 
            Vector3 lastGroundPosition)
        {

            var newPosition = startBuildPosition;
            newPosition.z = targetPosition.z + needDistanceBetweenGround * hasAmountGroundFront;
            newPosition.y += height * 2;
                
            transform.position = newPosition;
            transform.LookAt(lastGroundPosition);
        }
        public void MoveOffset(Vector3 targetPosition,Vector3 offset)
        {

            transform.position = targetPosition + offset;

        }
    }
}