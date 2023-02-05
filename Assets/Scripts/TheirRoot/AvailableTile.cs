using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TheirRoot
{
    public class AvailableTile : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TileMap tileMap;
        [SerializeField] private TileEvents tileEvents;
        private Sprite _emptyImage;
        private Image _image;
        private RootPartSo _rootPartSo;
        private List<Tile> _possibleTiles = new();
        [SerializeField] private RootPart rootPartPrefab;
        public bool IsEmpty { get; private set; } = true;
        
        private void Awake()
        {
            _image = GetComponent<Image>();
            _emptyImage = _image.sprite;
            IsEmpty = true;
            tileEvents.OnTileClick += OnTileClick;
        }

        private void OnDestroy()
        {
            tileEvents.OnTileClick -= OnTileClick;
        }

        private void OnTileClick(Tile tile)
        {
            if (_possibleTiles.Count <= 0) return;
            if (!_possibleTiles.Contains(tile)) return;

            var rootPart = Instantiate(rootPartPrefab, tile.transform);
            rootPart.rootPartSo = _rootPartSo;
            rootPart.myRootSpriteRenderer.sprite = _rootPartSo.rootSprite;
                    
            tile.Item = rootPart;
            rootPart.transform.localRotation = Quaternion.identity;
            rootPart.currentTile = tile;
            
            foreach (var possibleTile in _possibleTiles)
            {
                possibleTile.ToggleVisualHex();
            }
            _possibleTiles.Clear();

            FillTile(null);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _possibleTiles.Clear();
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                FillTile(null);
            }
            else if (eventData.button == PointerEventData.InputButton.Left)
            {
                _possibleTiles = tileMap.GetPossibleTiles(_rootPartSo);
                foreach (var possibleTile in _possibleTiles)
                {
                    possibleTile.ToggleVisualHex();
                }
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