using UnityEngine;

public class MainMusicAudio : MonoBehaviour
{
    public MainMusicEventChannel mainMusicEventChannel;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() => mainMusicEventChannel.onChangeMusic += ReproduceClip;
    private void OnDisable() => mainMusicEventChannel.onChangeMusic -= ReproduceClip;

    private void ReproduceClip(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.time = 0f;
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}