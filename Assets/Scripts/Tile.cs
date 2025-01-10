using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace
{
    public class Tile : MonoBehaviour
    {
        [Tooltip("Leave 6 for maximum enthropy and put 0 to make it a fixed tile that won't be affected by generation")] public int enthropy = 6;
        [SerializeField] private List<Vector3> neighbourSearchingOffsets;
        [SerializeField] public List<Tile> neighbours;
        public TileInformation currentTile;

        public bool isCollapsed
        {
            get { return enthropy == 0; }
        }

        public void CollapseInto(TileInformation _TileToCollapseInto)
        {
            currentTile = _TileToCollapseInto;
            enthropy = 0;
            neighbours.ForEach(neighbour => neighbour.NeighbourCollapsed());
            GameObject.Instantiate(_TileToCollapseInto.prefab, transform);
        }
        
        public void TryFindNeighbours()
        {
            RaycastHit hit;
            foreach (var VARIABLE in neighbourSearchingOffsets)
            {
                if (Physics.Raycast(transform.position + Vector3.up + VARIABLE, Vector3.down, out hit))
                {
                    neighbours.Add(hit.collider.GetComponent<Tile>());
                }
            }
        }
        
        public void NeighbourCollapsed()
        {
            if (enthropy <= 1) return;
            enthropy--;
        }
    }
}