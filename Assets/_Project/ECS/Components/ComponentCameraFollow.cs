using System;
using UnityEngine;

namespace Client._Project.ECS.Components
{
    [Serializable]
    public struct ComponentCameraFollow
    {
        public Transform Target;
        public Transform CameraTransfrom;
        public Vector3 Offset;
        public float Magnitude;
    }
}