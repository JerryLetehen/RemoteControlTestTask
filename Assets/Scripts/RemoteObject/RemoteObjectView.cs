using Game.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class RemoteObjectView : MonoBehaviour
    {
        [SerializeField] private Text nameField;
        [SerializeField] private Renderer skinRenderer;

        private RemoteObjectAnimator objectAnimator;

        private void Start()
        {
            objectAnimator = new RemoteObjectAnimator(transform);
        }

        public void Init(RemoteObjectViewData data)
        {
            SetName(data.Name);
            SetMaterial(data.Material);
            SetPositon(data.Position, data.AnimationTime);
        }

        private void SetPositon(Vector3 position, float time)
        {
            objectAnimator.SetPosition(position, time);
        }

        private void SetMaterial(Material material)
        {
            if (material == null)
            {
                return;
            }

            skinRenderer.material = material;
        }

        private void SetName(string name)
        {
            nameField.text = name;
        }

        private void OnDestroy()
        {
            objectAnimator.Dispose();
        }
    }
}