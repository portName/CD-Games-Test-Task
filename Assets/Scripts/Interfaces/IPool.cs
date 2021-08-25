using UnityEngine;

namespace Portname.CDGamesTestTask
{
    public interface IPool<T>
    {
        T CreateObjectFromPool(Vector3 positionCreate, Quaternion quaternionCreate);
        
    }
}