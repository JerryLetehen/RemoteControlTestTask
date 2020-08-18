using System;
using UnityEngine;

namespace Game.Config
{
    [CreateAssetMenu(fileName = "RemoteObjectViewConfig", menuName = "Configs/RemoteObject/RemoteObjectViewConfig", order = 0)]
    public class RemoteObjectViewConfig : ScriptableObject
    {
        [SerializeField] private RemoteObjectView prefab;
        [SerializeField] private float animationTime = 3f;
        [SerializeField] private TypeMaterialPair[] typeMaterialPairs;

        public RemoteObjectView Prefab => prefab;
        public float AnimationTime => animationTime;

        public Material GetMaterial(int type)
        {
            foreach (var pair in typeMaterialPairs)
            {
                if (pair.Type.Equals(type))
                {
                    return pair.Material;
                }
            }

            return null;
        }

        [Serializable]
        private struct TypeMaterialPair
        {
            [SerializeField] private int type;
            [SerializeField] private Material material;

            public int Type => type;
            public Material Material => material;
        }
    }
}