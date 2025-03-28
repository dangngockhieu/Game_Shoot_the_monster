using UnityEngine;
// Quản ls âm thanh trong Scene Victory
public class Audio_Victory : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioClip musicClip;

    void Start()
    {
        // Gọi Coroutine để phát âm thanh sau 1 giây
        StartCoroutine(PlayVictoryMusicWithDelay(1f)); // Delay 1 giây
    }
    System.Collections.IEnumerator PlayVictoryMusicWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Delay
        musicAudioSource.clip = musicClip;
        musicAudioSource.PlayOneShot(musicClip); // Phát âm thanh
    }
}
