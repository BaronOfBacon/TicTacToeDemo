using System;
using Leopotam.Ecs;
using UnityEngine;

namespace Root {
    sealed class EcsStartup : MonoBehaviour {
        
        public Configuration Configuration;
        public SceneData SceneData;
        
        EcsWorld _world;
        EcsSystems _systems;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            var gameState = new GameState();
            
            _systems
                .Add(new InitializeFieldSystem())
                .Add(new CreateCellViewSystem())
                .Add(new SetCameraSystem())
                .Add(new ControllSystem())
                .Add(new AnalyzeClickSystem())
                .Add(new CreateVewTakenSystem())
                .Add(new CheckWinSystem())
                .Add(new WinSystem())
                // register your systems here, for example:
                // .Add (new TestSystem1 ())
                // .Add (new TestSystem2 ())
                
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                .OneFrame<UpdateCameraEvent>()
                .OneFrame<Clicked>()
                .OneFrame<CheckWinEvent>()
                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Inject(Configuration)
                .Inject(SceneData)
                .Inject(gameState) 
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}