using Client._Project.ECS.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client._Project.ECS.Systems
{
    public class FollowCameraTargetSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilterInject<Inc<ComponentCameraFollow>> _filterInject = null;
        private EcsPoolInject<ComponentCameraFollow> _poolCammeraFollow;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var i in _filterInject.Value)
            {
                ref var cameraComponent = ref _poolCammeraFollow.Value.Get(i);
                cameraComponent.CameraTransfrom.position = Vector3.Lerp( cameraComponent.CameraTransfrom.position, cameraComponent.Target.transform.position + cameraComponent.Offset, Time.deltaTime * cameraComponent.Magnitude);
            }
        }
    }
}