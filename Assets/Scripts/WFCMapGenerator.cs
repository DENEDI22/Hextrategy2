using System;
using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class WFCMapGenerator : MonoBehaviour
    {
        //[SerializeField] private List<TileInformation> tileset; may be used for capital-independent map generation
        [SerializeField] private Tile[] allTilesOnTheMap;

        private void OnValidate()
        {
            allTilesOnTheMap = FindObjectsOfType<Tile>();
        }

        private void Start()
        {
            allTilesOnTheMap.ToList().ForEach(tile => tile.TryFindNeighbours());
            GenerateTiles();
        }

        private void GenerateTiles()
        {
            Tile nextTile = FindLowestEnthropy();
            while (nextTile!=null)
            {
                List<TileInformation> possibleCollapsionResult;
                List<Tile> generatedNeighbours = nextTile.neighbours.FindAll(tile => tile.enthropy == 0);
                possibleCollapsionResult = generatedNeighbours[0].currentTile.allowedNeighbours;
                if (generatedNeighbours.Count > 1)
                {
                    for (int i = 1; i < generatedNeighbours.Count; i++)
                    {
                        List<TileInformation> tmp = possibleCollapsionResult.Intersect(generatedNeighbours[i].currentTile.allowedNeighbours).ToList();
                        possibleCollapsionResult = tmp;
                    }
                }
                nextTile.CollapseInto(possibleCollapsionResult[Random.Range(0, possibleCollapsionResult.Count)]);
                nextTile = FindLowestEnthropy();
            }
        }

        private Tile FindLowestEnthropy()
        {
            List<Tile> nonGeneratedTiles = allTilesOnTheMap.ToList().FindAll(tile => tile.isCollapsed == false);
            if (nonGeneratedTiles.Count == 0)
            {
                return null;
            }
            int minEnthropy = nonGeneratedTiles.Min(tile => tile.enthropy);
            Tile[] minEnthropyTile = nonGeneratedTiles.FindAll(tile => tile.enthropy == minEnthropy).ToArray();
            return minEnthropyTile.Length == 1
                ? minEnthropyTile[0]
                : minEnthropyTile[Random.Range(0, minEnthropyTile.Length)];
        }
    }
}