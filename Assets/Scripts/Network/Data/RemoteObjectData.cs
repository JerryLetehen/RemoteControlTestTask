using System;
using Game.Utils;

namespace Game.Network.Data
{
    [Serializable]
    public struct RemoteObjectData
    {
        public string modifiedData;
        public Coordinate coordinate;
        public string name;
        public int id;
        public int type;

        public bool Equals(RemoteObjectData data)
        {
            return StringExtension.Equals(modifiedData, data.modifiedData);
        }
    }
}