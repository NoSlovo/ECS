using Client._Project.ECS.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client._Project.ECS.Systems
{
    public class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilterInject<Inc<CharacterMovement,AnimatorCompanent>> _filterInject = null;
        private readonly EcsPoolInject<CharacterMovement> _characterPool;
        private readonly EcsPoolInject<AnimatorCompanent> _animatorPool;

        private static readonly int Speed = Animator.StringToHash("speed");
        private Joystick _joystick;

        public MovementSystem(Joystick joystick)
        {
            _joystick = joystick;
        }
            
        public void Run(IEcsSystems systems)
        {
            foreach (var i in _filterInject.Value)
            {
                ref var characterComponent = ref _characterPool.Value.Get(i);
                ref var animatorCompanent = ref _animatorPool.Value.Get(i);
                var characterController = characterComponent.CharacterController;
                characterController.Move(new Vector3(_joystick.Direction.x,0,_joystick.Direction.y) * (characterComponent.Speed * Time.deltaTime));
                animatorCompanent.Animator.SetFloat(Speed,_joystick.Direction.magnitude);
            }
        }
    }
}