using System;
using UnityEngine;

namespace Client._Project.ECS.Components
{
    [Serializable]
    public struct CharacterMovement
    {
        [SerializeField] private float _speed;
        
        public CharacterController CharacterController;
        
        public float Speed => _speed;
    }
}