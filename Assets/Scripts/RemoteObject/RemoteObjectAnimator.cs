using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    public readonly struct RemoteObjectAnimator : IDisposable
    {
        private readonly CancellationTokenSource cancellationToken;
        private readonly Transform transform;

        public RemoteObjectAnimator(Transform transform)
        {
            cancellationToken = new CancellationTokenSource();
            this.transform = transform;
        }

        public void SetPosition(Vector3 position, float time)
        {
            cancellationToken.Cancel();
            Flight(position, time);
        }

        private async void Flight(Vector3 target, float time)
        {
            var t = 0f;
            var startPos = transform.position;
            while (cancellationToken.IsCancellationRequested == false || t < 1f)
            {
                var stepStartTime = Time.time;
                transform.position = Vector3.Lerp(startPos, target, t);
                await Task.Yield();
                t += (Time.time - stepStartTime) / time;
            }

            if (cancellationToken.IsCancellationRequested == false)
            {
                transform.position = target;
            }
        }

        public void Dispose()
        {
            cancellationToken?.Cancel();
        }
    }
}