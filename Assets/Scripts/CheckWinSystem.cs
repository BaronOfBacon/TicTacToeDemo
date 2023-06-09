using System;
using Leopotam.Ecs;

namespace Root
{
    internal class CheckWinSystem : IEcsRunSystem
    {
        private EcsFilter<Position, Taken, CheckWinEvent> _filter;
        private GameState _gameState;
        private Configuration _configuration;
            
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get1(index); 

                var chainLength = _gameState.Cells.GetLongestChain(position.value);

                if (chainLength >= _configuration.WinChainLength)
                {
                    _filter.GetEntity(index).Get<Winner>();
                }
            }
        }
    }
}