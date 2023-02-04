using TheirRoot;
using UnityEditor;
using UnityEngine;

namespace Scripts.Editor
{
    [CustomEditor(typeof(TileMap))]
    public class TileMapEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var tileMap = (TileMap)target;
            DrawDefaultInspector();

            if (GUILayout.Button("Build Map")) tileMap.BuildTileMap();
        }
    }
}