using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "MainMusicEventChannel", menuName = "TheirRoot/MainMusicEventChannel", order = 0)]
public class MainMusicEventChannel : ScriptableObject
{
    public UnityAction<AudioClip> onChangeMusic;
}