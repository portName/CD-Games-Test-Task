using System;
using Portname.CDGamesTestTask;
using UnityEngine;
using UnityEngine.UI;

namespace Portname.CDGamesTestTask
{
    [RequireComponent(typeof(Text))]
    [DisallowMultipleComponent]
    public class TextShowAmountWood : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Start()
        {
            Player.Instance.GetInventory().ChangeAmountBoardsEvent += OnChangeAmountBoardsHandler;
        }

        private void OnChangeAmountBoardsHandler(int boards)
        { 
            _text.text = "Amount boards: " + boards;
        }
    }
}