using UnityEngine;

namespace Portname.CDGamesTestTask
{
    public interface ICreate<out T>
    {
        T Create(Vector3 positionCreate, Quaternion quaternionCreate);
    }
}