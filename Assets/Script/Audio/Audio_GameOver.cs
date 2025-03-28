using UnityEngine;
// Quản lý âm thanh trong Scene GameOver
public class Audio_GameOver : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioClip musicClip; // Biến chứa âm thanh phát ra khi GameOver 

    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }
}
