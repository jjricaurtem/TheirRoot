using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheirRoot
{
    public class TileMap : MonoBehaviour
    {
        public Tile tilePrefab;
        public int rows = 8;
        public int cols = 8;
        public RootPart initialRootPartPrefab;
        public Tile[][] HexMatrix { get; private set; }
        private Tile startTile { get; set; }

        public void RebuildTileMap()
        {
            // Clear
            for (var rowNum = 0; rowNum < rows; rowNum++)
            for (var colNum = 0; colNum < cols; colNum++)
                Destroy(HexMatrix[rowNum][colNum]);

            BuildTileMap();
        }

        public Dictionary<Direction, Tile> GetNeighbours(Tile tile)
        {
            var neighbours = new Dictionary<Direction, Tile>();
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                var offset = DirectionValues.GetOffSet(direction);
                var neighbourRow = tile.row + offset[0];
                var neighbourCol = tile.col + offset[1];

                if (neighbourRow < 0 || neighbourRow >= rows) continue;
                if (neighbourCol < 0 || neighbourCol >= cols) continue;

                var neighbourTile = HexMatrix[neighbourRow][neighbourCol];
                neighbours.Add(direction, neighbourTile);
            }

            return neighbours;
        }

        public void BuildTileMap()
        {
            var parentPosition = transform.position;
            var bottomDownCorner =
                new Vector3(parentPosition.x + 0.5f - rows / 2f, 0, parentPosition.z + 0.5f - cols / 2f);
            var evenRowStyle = Vector3.zero;
            var oddRowStyle = new Vector3(0.5f, 0, 0);
            var evenRow = true;
            HexMatrix = new Tile[rows][];
            for (var rowNum = 0; rowNum < rows; rowNum++)
            {
                HexMatrix[rowNum] = new Tile[cols];
                var rowStyle = evenRow ? evenRowStyle : oddRowStyle;
                for (var colNum = 0; colNum < cols; colNum++)
                {
                    var hex = Instantiate(tilePrefab, transform);
                    hex.transform.localPosition = new Vector3(bottomDownCorner.x + colNum + rowStyle.x,
                        0, bottomDownCorner.z + rowNum + rowStyle.z);
                    hex.Initialize(rowNum, colNum, this);
                    HexMatrix[rowNum][colNum] = hex;
                }

                evenRow = !evenRow;
            }

            AddFirstRoot();
        }

        private void AddFirstRoot()
        {
            startTile = HexMatrix[0][0];
            var rootPart = Instantiate(initialRootPartPrefab, startTile.transform);
            startTile.Item = rootPart;
            rootPart.transform.localRotation = Quaternion.identity;
            rootPart.currentTile = startTile;
        }


        private void GetAllFreeJointTiles(Direction parentDirection, Tile currentTile,
            List<KeyValuePair<Direction, Tile>> freeJoinTiles)
        {
            var item = currentTile.Item;
            var inverseParentDirection = DirectionValues.GetInverseDirection(parentDirection);
            if (item is not null && item.GetType() == typeof(RootPart))
            {
                var rootPart = (RootPart)item;
                var neighbours = GetNeighbours(rootPart.currentTile);

                if (rootPart.rootPartSo.NW && neighbours.TryGetValue(Direction.NorthWest, out var tileNW))
                    GetAllFreeJointTiles(DirectionValues.GetInverseDirection(Direction.NorthWest), tileNW,
                        freeJoinTiles);
                if (rootPart.rootPartSo.NE && neighbours.TryGetValue(Direction.NorthEast, out var tileNE))
                    GetAllFreeJointTiles(DirectionValues.GetInverseDirection(Direction.NorthEast), tileNE,
                        freeJoinTiles);
                if (rootPart.rootPartSo.E && neighbours.TryGetValue(Direction.East, out var tileE))
                    GetAllFreeJointTiles(DirectionValues.GetInverseDirection(Direction.East), tileE, freeJoinTiles);
                if (rootPart.rootPartSo.SE && neighbours.TryGetValue(Direction.SouthEast, out var tileSE))
                    GetAllFreeJointTiles(DirectionValues.GetInverseDirection(Direction.SouthEast), tileSE,
                        freeJoinTiles);
                if (rootPart.rootPartSo.SW && neighbours.TryGetValue(Direction.SouthWest, out var tileSW))
                    GetAllFreeJointTiles(DirectionValues.GetInverseDirection(Direction.SouthWest), tileSW,
                        freeJoinTiles);
                if (rootPart.rootPartSo.W && neighbours.TryGetValue(Direction.West, out var tileW))
                    GetAllFreeJointTiles(DirectionValues.GetInverseDirection(Direction.West), tileW, freeJoinTiles);
            }

            freeJoinTiles.Add(KeyValuePair.Create(inverseParentDirection, currentTile));
        }

        public List<KeyValuePair<Direction, Tile>> GetPossibleTiles(RootPartSo rootPartSo)
        {
            var results = new List<KeyValuePair<Direction, Tile>>();
            GetAllFreeJointTiles(Direction.NorthEast, startTile, results);
            
            
            return results;
        }
    }
}