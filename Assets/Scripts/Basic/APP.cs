using UnityEngine;

namespace Portname.CDGamesTestTask
{
    public static class APP
    {
        
        #region Custom Methods

        public static void EndGame()
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        #endregion
    }
}