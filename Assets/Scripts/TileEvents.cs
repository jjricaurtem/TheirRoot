using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "TileEvents", menuName = "TheirRoot/TileEvents", order = 0)]
public class TileEvents : ScriptableObject
{
    public UnityAction<int> StatusChange;
}