using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public enum BGMusic
{
    Title,
    Level,
    GameOver
}
public enum Sound
{
    Explosion1,
    Explosion2
}

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    public static AudioController controller;

    //////
    // Change the names of the songs you want here //
    /////
    static string TITLE_MUSIC_NAME = "Title";
    static string LEVEL_MUSIC_NAME = "Level";
    static string GAMEOVER_MUSIC_NAME = "GameOver";

    AudioSource audioSource;

    AudioClip titleMusic, levelMusic, gameOverMusic;
    AudioClip explosion1Sound, explosion2Sound;

    AudioClip temp;

    void Awake()
    {
        if (controller == null)
        {
            controller = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;

        titleMusic = Resources.Load<AudioClip>("Audio/Background/" + TITLE_MUSIC_NAME);
        levelMusic = Resources.Load<AudioClip>("Audio/Background/" + LEVEL_MUSIC_NAME);
        gameOverMusic = Resources.Load<AudioClip>("Audio/Background/" + GAMEOVER_MUSIC_NAME);
        explosion1Sound = Resources.Load<AudioClip>("Audio/Explosion1");
        explosion2Sound = Resources.Load<AudioClip>("Audio/Explosion2");
        PlaySong(BGMusic.Title);
    }

    public void PlaySong(BGMusic musicType)
    {
        switch (musicType)
        {
            case BGMusic.Title:
                temp = titleMusic;
                break;
            case BGMusic.Level:
                temp = levelMusic;
                break;
            case BGMusic.GameOver:
                temp = gameOverMusic;
                break;
        }

        audioSource.Stop();
        audioSource.clip = temp;
        audioSource.Play();
    }

    public void PlaySound(Sound s)
    {
        switch (s)
        {
            case Sound.Explosion1:
                temp = explosion1Sound;
                break;
            case Sound.Explosion2:
                temp = explosion2Sound;
                break;
        }
        audioSource.PlayOneShot(temp);
    }
}
