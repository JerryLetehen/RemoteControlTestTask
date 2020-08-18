using System.Threading;
using System.Threading.Tasks;
using Game.Config;
using Game.Models;
using Game.Network;
using Game.Network.Data;
using UnityEngine;

namespace Game
{
    public class RemoteControl : MonoBehaviour
    {
        [SerializeField] private RemoteControlConfig config;
        [SerializeField] private RemoteObjectsController objectsController;

        private CancellationTokenSource networkCancellationToken;
        private GameNetwork gameNetwork = new GameNetwork();
        private RemoteControlModel model;

        private async void Start()
        {
            networkCancellationToken = new CancellationTokenSource();
            RequestData();
            StartViews();
            while (networkCancellationToken.IsCancellationRequested == false)
            {
                await Task.Delay((int) (config.UpdateDelay * 1000));
                if (networkCancellationToken.IsCancellationRequested == false)
                {
                    RequestData();
                }
            }
        }

        private async void StartViews()
        {
            await Task.Delay((int) (config.StartViewsDelay * 1000), networkCancellationToken.Token);
            objectsController.UpdateViews(model.ObjectData);
        }

        private async void RequestData()
        {
            OnReceiveData(await gameNetwork.GetText(config.Url, networkCancellationToken));
        }

        private void OnReceiveData(string data)
        {
            if (networkCancellationToken.IsCancellationRequested)
            {
                return;
            }

            var remoteControlData = JsonUtility.FromJson<RemoteControlData>(data);
            if (model == null)
            {
                model = new RemoteControlModel(remoteControlData);
                model.OnUpdated += OnModelUpdated;
                objectsController.CreateViews(remoteControlData.data.Length);
            }
            else
            {
                model.Update(remoteControlData);
            }
        }

        private void OnModelUpdated(RemoteControlData remoteControlData)
        {
            objectsController.UpdateViews(remoteControlData.data);
        }

        private void OnDestroy()
        {
            networkCancellationToken?.Cancel();
        }
    }
}