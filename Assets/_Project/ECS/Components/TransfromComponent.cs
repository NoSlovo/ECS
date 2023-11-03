
using System;
using UnityEngine;

namespace Client._Project.ECS.Components
{
    [Serializable]
    public struct TransfromComponent
    {
        [SerializeField] private Transform _transform;

        public Transform Transform => _transform;
    }
}