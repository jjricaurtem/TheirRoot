using UnityEngine;
using UnityEngine.EventSystems;

namespace TheirRoot
{
    public class Tile : MonoBehaviour, IPointerClickHandler
    {
        public int col;
        public int row;
        public TileMap tileMap;
        public int status;
        public TileEvents tileEvents;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            var newStatus = status == 0 ? 1 : 0;
            tileEvents.StatusChange?.Invoke(newStatus);
            SetStatus(newStatus);
        }

        private void SetStatus(int newStatus)
        {
            if (status == newStatus) return;
            status = newStatus;
            _spriteRenderer.color = status == 0 ? Color.white : Color.red;
            Debug.Log($"Clicked on hex {name}");
        }

        public void Initialize(int rowNum, int colNum, TileMap parentTileMap)
        {
            name = $"Hex_{rowNum}_{colNum}";
            row = rowNum;
            col = colNum;
            tileMap = parentTileMap;
        }
    }
}