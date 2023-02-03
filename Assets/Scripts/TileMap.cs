using UnityEngine;

public class TileMap : MonoBehaviour
{
    public Tile tilePrefab;
    public int rows = 8;
    public int cols = 8;
    private readonly Tile[][] _hexMatrix = new Tile[20][];

    // Start is called before the first frame update
    private void Start()
    {
        BuildBoard();
    }

    private void BuildBoard()
    {
        var parentPosition = transform.position;
        var bottomDownCorner = new Vector2(parentPosition.x + 0.5f - rows / 2f, parentPosition.y + 0.5f - cols / 2f);
        var evenRowStyle = Vector2.zero;
        var oddRowStyle = new Vector2(0.5f, 0);
        var evenRow = true;
        for (var rowNum = 0; rowNum < rows; rowNum++)
        {
            _hexMatrix[rowNum] = new Tile[cols];
            var rowStyle = evenRow ? evenRowStyle : oddRowStyle;
            for (var colNum = 0; colNum < cols; colNum++)
            {
                var hex = Instantiate(tilePrefab, transform);
                hex.transform.position = new Vector3(bottomDownCorner.x + colNum + rowStyle.x,
                    bottomDownCorner.y + rowNum + rowStyle.y, 0);
                hex.Initialize(rowNum, colNum, this);
                _hexMatrix[rowNum][colNum] = hex;
            }

            evenRow = !evenRow;
        }
    }
}