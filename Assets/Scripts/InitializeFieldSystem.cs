using Leopotam.Ecs;
using UnityEngine;

namespace Root
{
    internal class InitializeFieldSystem : IEcsInitSystem
    {
        private Configuration _configuration;
        private EcsWorld _world;
        
        public void Init()
        {
            for (var i = 0; i < _configuration.LevelWidth; i++)
            {
                for (var j = 0; j < _configuration.LevelHeight; j++)
                {
                    var cellEntity = _world.NewEntity();
                    cellEntity.Get<Cell>();
                    ref var position = ref cellEntity.Get<Position>();
                    position.value = new Vector2Int(i,j);
                }
            }

            _world.NewEntity().Get<UpdateCameraEvent>();
        }
    }
}