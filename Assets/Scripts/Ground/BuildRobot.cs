using UnityEngine;

namespace Portname.CDGamesTestTask
{
    public class BuildRobot : MonoBehaviour
    {
        public void Activate()
        {
            gameObject.SetActive(true);
        }
        public void Disactivate()
        {
            gameObject.SetActive(false);
        }
    }
}