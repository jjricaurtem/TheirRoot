using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TheirRoot
{
    public class AvailableTile : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TileMap tileMap;
        private Sprite _emptyImage;
        private Image _image;
        private RootPartSo _rootPartSo;
        public bool IsEmpty { get; private set; } = true;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _emptyImage = _image.sprite;
            IsEmpty = true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                FillTile(null);
            }
            else if (eventData.button == PointerEventData.InputButton.Left)
            {
                
            }
        }

        public void FillTile(RootPartSo newRootPartSo)
        {
            if (newRootPartSo is null)
            {
                _image.sprite = _emptyImage;
                IsEmpty = true;
            }
            else
            {
                _image.sprite = newRootPartSo.rootSprite;
                IsEmpty = false;
            }

            _rootPartSo = newRootPartSo;
        }
    }
}