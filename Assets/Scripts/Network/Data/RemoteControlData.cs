using System;
using Game.Utils;

namespace Game.Network.Data
{
    [Serializable]
    public struct RemoteControlData
    {
        public string name;
        public int id;
        public string modifiedData;
        public RemoteObjectData[] data;

        public bool Equals(RemoteControlData data)
        {
            return StringExtension.Equals(modifiedData, data.modifiedData) && DataEquals(data.data);
        }

        private bool DataEquals(RemoteObjectData[] other)
        {
            if (data == null != (other == null))
            {
                return false;
            }

            if (data != null && other != null && data.Length.Equals(other.Length))
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].Equals(other[i]) == false)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}