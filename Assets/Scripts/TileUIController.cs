using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TileUIController : MonoBehaviour
    {
        private Tile m_selectTile;
        [SerializeField] private GameObject selectionVFX;
        [SerializeField] private Vector3 selctionOffset;
        private bool isUIMenuActive;
        public void SelectTile(Tile _tileToSelect)
        {
            m_selectTile = _tileToSelect;
            selectionVFX.SetActive(true);
            selectionVFX.transform.position = _tileToSelect.transform.position + selctionOffset;
        }

        public void RemoveSelection()
        {
            if (isUIMenuActive)
            {
                m_selectTile = null;
                selectionVFX.SetActive(false);
            }
        }
        
        public void OpenMenu()
        {
            //addBuildingMenu
        }
        
    }
}