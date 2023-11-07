using Client._Project.ECS.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client._Project.ECS.Systems
{
    public class AttackSystem : IEcsInitSystem,IEcsDestroySystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilterInject<Inc<AnimatorCompanent,ButtonAttackComponent>> _filterInject;
        private readonly EcsPoolInject<AnimatorCompanent> _poolAnimation;
        private readonly EcsPoolInject<ButtonAttackComponent> _poolAttackComponent;

        private Animator _animator;

        public void Init(IEcsSystems systems)
        {
            foreach (var i in _filterInject.Value)
            {
                _animator =  _poolAnimation.Value.Get(i).Animator;
                ref var button = ref _poolAttackComponent.Value.Get(i);
                button.Button.onClick.AddListener(AttackPlay);
            }
        }

        private void AttackPlay()
        {
            _animator.Play("AttachFilter");
        }

        public void Destroy(IEcsSystems systems)
        {
            foreach (var i in _filterInject.Value)
            {
                ref var button = ref _poolAttackComponent.Value.Get(i);
                button.Button.onClick.RemoveListener(AttackPlay);
            }
        }
    }
}