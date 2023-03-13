using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Root
{
    internal class CreateCellViewSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Position>.Exclude<CellViewRef> _filter;
        private Configuration _configuration;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get2(index);

                var cellVew = Object.Instantiate(_configuration.CellView);

                cellVew.entity = _filter.GetEntity(index);
                
                cellVew.transform.position = new Vector2(
                    position.value.x + _configuration.Offset.x * position.value.x,
                    position.value.y + _configuration.Offset.y * position.value.y);
                
                _filter.GetEntity(index).Get<CellViewRef>().value = cellVew;
            }
        }
    }
}