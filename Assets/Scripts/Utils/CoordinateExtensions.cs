using Game.Network.Data;
using UnityEngine;

namespace Game.Utils
{
    public static class CoordinateExtensions
    {
        public static Vector3 GetVector3(this Coordinate coordinate)
        {
            return new Vector3(coordinate.x, coordinate.y, coordinate.z);
        }
    }
}