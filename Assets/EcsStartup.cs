using Client._Project.ECS.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using Voody.UniLeo.Lite;

namespace Client
{
    sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        
        
        EcsWorld _world;
        IEcsSystems _systems;

        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _systems.ConvertScene()
               .Add(new MovementSystem(_joystick))
               .Add(new RotationSystem(_joystick))
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                .Inject()
                .Init();
        }

        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy()
        {
            if (_systems != null)
            {
                // list of custom worlds will be cleared
                // during IEcsSystems.Destroy(). so, you
                // need to save it here if you need.
                _systems.Destroy();
                _systems = null;
            }

            // cleanup custom worlds here.

            // cleanup default world.
            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}