using TheirRoot;
using UnityEditor;
using UnityEngine;

namespace Scripts.Editor
{
    [CustomEditor(typeof(Tile))]
    public class TileEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var tile = (Tile)target;
            DrawDefaultInspector();

            if (GUILayout.Button("Toggle Visual")) tile.ToggleVisualHex();
        }
    }
}