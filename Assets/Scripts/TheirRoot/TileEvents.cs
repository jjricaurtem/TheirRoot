using UnityEngine;
using UnityEngine.Events;

namespace TheirRoot
{
    [CreateAssetMenu(fileName = "TileEvents", menuName = "TheirRoot/TileEvents", order = 0)]
    public class TileEvents : ScriptableObject
    {
        public UnityAction<Tile> OnTileClick;
        public UnityAction<Tile> OnTileHover;
    }
}