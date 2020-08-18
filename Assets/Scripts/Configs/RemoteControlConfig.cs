using UnityEngine;

namespace Game.Config
{
    [CreateAssetMenu(fileName = "RemoteControlConfig", menuName = "Configs/Network/RemoteControlConfig", order = 0)]
    public class RemoteControlConfig : ScriptableObject
    {
        [SerializeField] private string url;
        [SerializeField] private float updateDelay = 10f;
        [SerializeField] private float startViewsDelay = 5f;

        public float UpdateDelay => updateDelay;
        public float StartViewsDelay => startViewsDelay;
        public string Url => url;
    }
}