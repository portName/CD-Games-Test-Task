using UnityEngine;

namespace Portname.CDGamesTestTask
{
    public interface IMove
    {
        void Move(Vector3 moveDiraction, float speed);
        void Rotation(Quaternion rotate, float speed);

    }
}