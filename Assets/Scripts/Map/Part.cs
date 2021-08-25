using System;
using System.Collections.Generic;
using UnityEngine;

namespace Portname.CDGamesTestTask
{
    public class Part : MonoBehaviour , ICreate<Part>
    {
        private List<BoardPack> _boardPacks;
        private EndZone _endZone;
        
        private void Awake()
        {
            _boardPacks = new List<BoardPack>();
            _boardPacks.AddRange(GetComponentsInChildren<BoardPack>());
            _endZone = GetComponentInChildren<EndZone>();
        }

        private void Start()
        {
            _endZone.EndZoneEvent += ResetPart;
        }

        private void ResetPart(Vector3 positionCreate, Quaternion quaternionCreate)
        {
            Create(positionCreate, quaternionCreate);
        }

        public Part Create(Vector3 positionCreate, Quaternion quaternionCreate)
        {
            transform.SetPositionAndRotation(positionCreate, quaternionCreate);
            foreach (var boardPack in _boardPacks)
            {
                var transform1 = boardPack.transform;
                boardPack.Create(transform1.position, transform1.rotation);
            }
            return this;
        }
    }
}