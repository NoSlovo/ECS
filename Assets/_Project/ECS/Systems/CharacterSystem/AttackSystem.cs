using Client._Project.ECS.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Client._Project.ECS.Systems
{
    public class AttackSystem : IEcsInitSystem,IEcsDestroySystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilterInject<Inc<AnimatorCompanent>> _filterInject;
        private readonly EcsPoolInject<AnimatorCompanent> _poolAnimation;

        public AttackSystem()
        {
            
        }
        
        public void Init(IEcsSystems systems)
        {
            
        }

        public void Destroy(IEcsSystems systems)
        {
            
        }
    }
}