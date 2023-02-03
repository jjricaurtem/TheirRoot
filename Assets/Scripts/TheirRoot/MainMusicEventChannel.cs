using UnityEngine;
using UnityEngine.Events;

namespace TheirRoot
{
    [CreateAssetMenu(fileName = "MainMusicEventChannel", menuName = "TheirRoot/MainMusicEventChannel", order = 0)]
    public class MainMusicEventChannel : ScriptableObject
    {
        public UnityAction<AudioClip> onChangeMusic;
    }
}