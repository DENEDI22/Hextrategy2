using System;
using UnityEngine;

namespace DefaultNamespace
{
    
    [RequireComponent(typeof(Tile))]
    public class TileUIController : MonoBehaviour
    {
        private Tile m_selectTile;
        [SerializeField] private GameObject selectionVFX;

        public void SelectTile(Tile _tileToSelect)
        {
            
        }
        
    }
}