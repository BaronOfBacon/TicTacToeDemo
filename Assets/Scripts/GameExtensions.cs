using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace Root
{
    public static class GameExtensions
    {
        public static int GetLongestChain(this Dictionary<Vector2Int, EcsEntity> cells, Vector2Int position)
        {
            var startEntity = cells[position];
            if (!startEntity.Has<Taken>()) return 0;
            
            var startType = startEntity.Ref<Taken>().Unref().value;
            var directions = new Vector2Int[4,2]
            {
                {Vector2Int.up, Vector2Int.down},
                {Vector2Int.left, Vector2Int.right},
                {Vector2Int.up + Vector2Int.left, Vector2Int.down + Vector2Int.right},
                {Vector2Int.up + Vector2Int.right, Vector2Int.down + Vector2Int.left},
            };
            
            var currentLength = 1;
            var maxLength = 1;
            for (var i = 0; i < directions.GetLength(0); i++)
            {
                currentLength = 1;
                for (var j = 0; j < directions.GetLength(1); j++)
                {
                    var direction = directions[i, j];
                    var currentPosition = position + direction;

                    while (cells.TryGetValue(currentPosition, out var entity))
                    {
                        if (!entity.Has<Taken>())
                        {
                            break;
                        }
                        else
                        {
                            var type = entity.Ref<Taken>().Unref().value;
                            if (type != startType)
                            {
                                break;
                            }

                            currentLength++;
                            currentPosition += direction;
                        }
                    }

                    if (maxLength < currentLength)
                        maxLength = currentLength;
                }
            }

            return maxLength;
        }
    }
}