using Leopotam.Ecs;
using UnityEngine;

namespace Root
{
    internal class SetCameraSystem : IEcsRunSystem
    {
        private EcsFilter<UpdateCameraEvent> _filter;
        private SceneData _sceneData;
        private Configuration _configuration;
        
        public void Run()
        {
            if (_filter.IsEmpty()) return;

            var height = _configuration.LevelHeight;
            var width = _configuration.LevelWidth;
            
            var camera = _sceneData.Camera;
            camera.orthographic = true;
            camera.orthographicSize = height / 2f + (height - 1) * _configuration.Offset.y / 2;

            _sceneData.CameraTransform.position = new Vector3(
                width / 2f + (width - 1) * _configuration.Offset.x / 2,
                height / 2f + (height - 1) * _configuration.Offset.y / 2);
        }
    }
}