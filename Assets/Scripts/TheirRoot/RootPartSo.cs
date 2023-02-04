using UnityEngine;

namespace TheirRoot
{
    [CreateAssetMenu(fileName = "RootPartSo", menuName = "TheirRoot/RootPartSo", order = 0)]
    public class RootPartSo : ScriptableObject
    {
        public bool NE, NW, E, SE, SW, W;
        public Sprite rootSprite;
    }
}
