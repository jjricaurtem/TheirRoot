using UnityEngine;

namespace TheirRoot
{
    public class TileMap : MonoBehaviour
    {
        public Tile tilePrefab;
        public int rows = 8;
        public int cols = 8;
        public Tile[][] HexMatrix { get; } = new Tile[20][];

        public void buildTileMap()
        {
            //_hexMatrix[1][0] = null;
            var parentPosition = transform.position;
            var bottomDownCorner =
                new Vector3(parentPosition.x + 0.5f - rows / 2f, 0, parentPosition.z + 0.5f - cols / 2f);
            var evenRowStyle = Vector3.zero;
            var oddRowStyle = new Vector3(0.5f, 0, 0);
            var evenRow = true;
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
        }
    }
}