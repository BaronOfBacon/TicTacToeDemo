using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace Root
{
    public class GameState
    {
        public SignType CurrentSign = SignType.Cross;
        public readonly Dictionary<Vector2Int, EcsEntity> Cells = new();
    }
}