using System;
using System.Collections;
using UnityEngine;

namespace Portname.CDGamesTestTask
{
    [DisallowMultipleComponent]
    public class Ground : MonoBehaviour, ICreate<Ground>, IDelete<Ground>
    {
        public event Action<Ground> DeleteEvent;
        
        public Ground Create(Vector3 positionCreate, Quaternion quaternionCreate)
        {
            transform.SetPositionAndRotation(positionCreate, quaternionCreate);
            return this;
        }

        public void Delete()
        {
            DeleteEvent?.Invoke(this);
            transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
        
        public IEnumerator WaitBeforeDelete(float delay)
        {
            yield return new WaitForSeconds(delay);
            Delete();
        }
    }
}