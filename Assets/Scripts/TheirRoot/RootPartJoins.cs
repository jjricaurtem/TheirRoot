using UnityEngine;

namespace TheirRoot
{
    [CreateAssetMenu(fileName = "RootPartJoins", menuName = "TheirRoot/RootPartJoins", order = 0)]
    public class RootPartJoins : ScriptableObject
    {
        public bool NE, NW, E, SE, SW, W;
    }
}
