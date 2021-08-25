using System;
using UnityEngine;

namespace Portname.CDGamesTestTask
{
    [DisallowMultipleComponent]
    public class Inventory : MonoBehaviour
    {
        #region Events

            public event Action<int> ChangeAmountBoardsEvent; 

        #endregion
        
        #region Private Fields

          private int _boards;    

        #endregion

        #region MonoBehaviour Callback

            private void Start()
            {
                _boards = 0;
            }

        #endregion

        #region Custom Methods

            public bool HasBoards()
            {
                return _boards > 0;
            }

            public void AddBoard(int amount)
            {
                _boards += amount;
                ChangeAmountBoardsEvent?.Invoke(_boards);
            }
            public void SubBoard(int amount)
            {
                _boards -= amount;
                ChangeAmountBoardsEvent?.Invoke(_boards);
            }

        #endregion
    }
}