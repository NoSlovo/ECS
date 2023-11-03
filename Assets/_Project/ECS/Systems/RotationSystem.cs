using Client._Project.ECS.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client._Project.ECS.Systems
{
    public sealed class RotationSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilterInject<Inc<TransfromComponent>> _filter = null;
        private readonly EcsPoolInject<TransfromComponent> _transformPool;

        private Joystick _joystick;

        public RotationSystem(Joystick Joystick)
        {
            _joystick = Joystick;
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var i in _filter.Value)
            {
                ref var  transfromComponent = ref _transformPool.Value.Get(i);
                if(_joystick.Direction == Vector2.zero){return;}
                transfromComponent.Transform.rotation = Quaternion.LookRotation(new Vector3(_joystick.Direction.x,0,_joystick.Direction.y));
            }
        }
    }
}