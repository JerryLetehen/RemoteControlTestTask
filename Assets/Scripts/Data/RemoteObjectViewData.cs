using UnityEngine;

namespace Game.Data
{
    public readonly struct RemoteObjectViewData
    {
        public readonly string Name;
        public readonly Material Material;
        public readonly Vector3 Position;
        public readonly float AnimationTime;

        public RemoteObjectViewData(string name, Material material, Vector3 position, float animationTime)
        {
            Name = name;
            Material = material;
            Position = position;
            AnimationTime = animationTime;
        }
    }
}