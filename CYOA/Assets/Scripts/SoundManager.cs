using UnityEngine;

// ReSharper disable InconsistentNaming
/// <summary>
/// A class for managing the sounds of the game.
/// </summary>
public class SoundManager : MonoBehaviour 
{
    public static SoundManager I;

    public float Volume = 1f;

    // General
    public AudioClip StartRoom;
    public AudioClip EndRoom;

    // First Room
    public AudioClip T;
    public AudioClip F;
    
    // Second Room
    public AudioClip TT;
    public AudioClip TF;
    public AudioClip FF;
    public AudioClip FT;

    // Third Room
    public AudioClip TTT;
    public AudioClip TFT;
    public AudioClip TTF;
    public AudioClip TFF;
    public AudioClip FFF;
    public AudioClip FFT;
    public AudioClip FTF;
    public AudioClip FTT;

    /// <summary>
    /// Stuff that happens when the game starts.
    /// </summary>
    void Start()
    {
        I = this;
    }

    float GetVolume(AudioClip clip)
    {
        switch (clip.name)
        {
            case "FF":
                return 0.5f;
                break;

            case "TFT":
                return Volume * 1.2f;
                break;

            default:
                return Volume;
                break;
        }
    }

    /// <summary>
    /// Plays the given sound clip
    /// </summary>
    /// <param name="clip"></param>
    public void Play(AudioClip clip)
    {
        if (clip == null) return;

        Debug.Log(clip.name);
        audio.Stop();
        audio.PlayOneShot(clip, GetVolume(clip));
    }
}
