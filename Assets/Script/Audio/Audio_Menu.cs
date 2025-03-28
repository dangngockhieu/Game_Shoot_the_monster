using UnityEngine;
// Quản lý âm thanh nhạc nền trong menu
public class Audio_Menu : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioClip musicClip;

    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }
}
