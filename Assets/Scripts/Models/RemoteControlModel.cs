using System;
using Game.Network.Data;

namespace Game.Models
{
    public class RemoteControlModel
    {
        public event Action<RemoteControlData> OnUpdated;

        public RemoteObjectData[] ObjectData => data.data;

        private RemoteControlData data;

        public RemoteControlModel(RemoteControlData data)
        {
            Update(data);
        }

        public void Update(RemoteControlData data)
        {
            AssignNewData(data);
        }

        private void AssignNewData(RemoteControlData data)
        {
            if (this.data.Equals(data) == false)
            {
                OnUpdated?.Invoke(data);
            }

            this.data = data;
        }
    }
}