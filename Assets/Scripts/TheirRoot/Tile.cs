using UnityEngine;
using UnityEngine.EventSystems;

namespace TheirRoot
{
    public class Tile : MonoBehaviour, IPointerClickHandler, IPointerUpHandler
    {
        public int col;
        public int row;
        public TileMap tileMap;
        public int status;
        public TileEvents tileEvents;
        [SerializeField] private GameObject tileVisualGo;
        public IItem Item { get; set; }


        public void OnPointerClick(PointerEventData eventData)
        {
            var newStatus = status == 0 ? 1 : 0;
            tileEvents.OnTileClick?.Invoke(this);
            SetStatus(newStatus);
        }

        private void SetStatus(int newStatus)
        {
            if (status == newStatus) return;
            status = newStatus;
            Debug.Log($"Clicked on hex {name}");
        }

        public void Initialize(int rowNum, int colNum, TileMap parentTileMap)
        {
            name = $"Hex_{rowNum}_{colNum}";
            row = rowNum;
            col = colNum;
            tileMap = parentTileMap;
        }

        public void ToggleVisualHex() => tileVisualGo.SetActive(!tileVisualGo.activeSelf);

        public void OnPointerUp(PointerEventData eventData)
        {
            tileEvents.OnTileHover?.Invoke(this);
        }
    }
}