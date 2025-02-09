using UnityEngine;

namespace DefaultNamespace.Utilities
{
    public static class Extentions
    {
        public static Vector3 BetterAdditionHor(this Vector3 _innitialVector, Vector2 _x)
        {
            return new Vector3(_innitialVector.x + _x.x, _innitialVector.y, _innitialVector.z + _x.y);
        }

        public static Vector3 BetterAdditionVert(this Vector3 _innitialVector, Vector2 _x)
        {
            return new Vector3(_innitialVector.x + _x.x, _innitialVector.y + _x.y, _innitialVector.z);
        }
}
}