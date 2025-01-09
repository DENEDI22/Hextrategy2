using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewTile", menuName = "Hextrategy/Tile information", order = 0)]
    public class TileInformation : ScriptableObject
    {
        public string tileName;
        public GameObject prefab;
        public List<TileInformation> allowedNeighbours;
        public bool canHaveRiver;
    }
}