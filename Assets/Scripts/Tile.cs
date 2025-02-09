using System;
using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace
{
    public enum TileState
    {
        Neutral,
        Enemy,
        Occupied
    }

    public class Tile : MonoBehaviour
    {
        [Tooltip("Leave 6 for maximum enthropy and put 0 to make it a fixed tile that won't be affected by generation")]
        public int enthropy = 6;

        [SerializeField] private List<Vector3> neighbourSearchingOffsets;
        [SerializeField] public List<Tile> neighbours;
        public TileInformation currentTile;
        public TileState currentTileState = TileState.Neutral;
        [SerializeField] private MeshRenderer banner;
        private GameObject m_spawnedPrefab;
        private Recourses m_playerRecourses;
        // private Recourses m_enemyRecourses; //we are going to need it later for the enemy

        public bool isCollapsed
        {
            get { return enthropy == 0; }
        }

        private void Start()
        {
            m_playerRecourses = FindObjectsByType<Recourses>(FindObjectsSortMode.None).ToList()
                .Find(x => x.isPlayerControlled);
            // m_enemyRecourses = FindObjectsByType<Recourses>(FindObjectsSortMode.None).ToList().Find(x => !x.isPlayerControlled); //we are going to need it later for the enemy
        }

        public void CollapseInto(TileInformation _TileToCollapseInto)
        {
            currentTile = _TileToCollapseInto;
            enthropy = 0;
            neighbours.ForEach(neighbour => neighbour.NeighbourCollapsed());
            m_spawnedPrefab = GameObject.Instantiate(_TileToCollapseInto.prefab, transform);
        }

        public void TryFindNeighbours()
        {
            RaycastHit hit;
            foreach (Vector3 VARIABLE in neighbourSearchingOffsets)
            {
                if (Physics.Raycast(transform.position + Vector3.up + VARIABLE, Vector3.down, out hit))
                {
                    neighbours.Add(hit.collider.GetComponent<Tile>());
                }
            }
        }

        public void Occupy(bool isFromPlayer)
        {
            if (isFromPlayer)
            {
                if (currentTileState == TileState.Neutral &&
                    m_playerRecourses.TryTakeResources(currentTile.recoursesToDevelop))
                {
                    m_playerRecourses.AddToRecoursesPerTick(currentTile.recoursesPerTick);
                    banner.material.color = Color.blue;
                    currentTileState = TileState.Occupied;
                }
                else if (currentTileState == TileState.Enemy &&
                         m_playerRecourses.TryTakeResources(currentTile.recoursesToOccupy))
                {
                    //TODO take tick materials from the m_enemyRecourses
                    m_playerRecourses.AddToRecoursesPerTick(currentTile.recoursesPerTick);
                    banner.material.color = Color.blue;
                    currentTileState = TileState.Occupied;
                }
                else
                {
                    Debug.LogError("You shouldn't be able to occupy your own tile", this);
                }
            }
            else
            {
                //TODO write logic for enemies.. IDK how it is going to work with multiplayer... probably rewrite the whole method.
            }
        }

        public void Build(TileInformation _tileToBuild, bool _isFromPlayer)
        {
            if (_isFromPlayer)
            {
                if (m_playerRecourses.TryTakeResources(_tileToBuild.recoursesToDevelop))
                {
                    Destroy(m_spawnedPrefab);
                    currentTile = _tileToBuild;
                    m_spawnedPrefab = GameObject.Instantiate(_tileToBuild.prefab, transform);
                    return;
                }
            }

            // Destroy(m_spawnedPrefab);
            // currentTile = _tileToBuild;
            // m_spawnedPrefab = GameObject.Instantiate(_tileToBuild.prefab, transform);
        }

        public void NeighbourCollapsed()
        {
            if (enthropy <= 1) return;
            enthropy--;
        }
    }
}