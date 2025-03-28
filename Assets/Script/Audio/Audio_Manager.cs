using UnityEngine;
// Quản lý âm thanh trong Level1 và Level2
public class Audio_Manager : MonoBehaviour
{

    public AudioSource musicAudioSource;
    public AudioClip shootClip; // tiếng bắn súng
    public AudioClip collideClip; // tiếng va chạm
    public AudioClip meteoriteClip; // tiếng thiên thạch rơi

    public void PlaySfx(AudioClip clip)
    {
        if (clip != null)
        {
            musicAudioSource.PlayOneShot(clip); // Phát âm thanh mà không ghi đè
        }
    }
}
