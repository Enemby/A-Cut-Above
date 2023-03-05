using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class fuckincoolmusicmanager : MonoBehaviour
{
    //smoothly transition music from scene to scene
    public int levelIndex;
    public AudioClip[] mySoundIndex;
    public AudioClip[] gameplayMusic;
    public int myGameplayIndex;
    public AudioSource myAudioSource;
    public float masterVolume;
    public virtual void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        myAudioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        }
    }

    public virtual void Update()
    {
        levelIndex = Application.loadedLevel;
        if (mySoundIndex[0] != null)
        {
            GameplayMusicLogic();
            PlayMusic();
        }
    }

    public virtual void PlayMusic()//If there's not a track playing, play a track.
    {
        if (this.myAudioSource.isPlaying == false)
        {
            if (this.levelIndex < 2)
            {
                this.myAudioSource.clip = this.mySoundIndex[this.levelIndex];
            }
            else
            {
                this.myGameplayIndex = this.myGameplayIndex + 1;
            }
            this.myAudioSource.Play();
        }
        else
        {
            if (this.levelIndex < 2)
            {
                if (!(this.myAudioSource.clip.name == this.mySoundIndex[this.levelIndex].name))
                {
                    this.myAudioSource.volume = ((float) this.myAudioSource.volume) * 0.9f;
                    if (this.myAudioSource.volume < 0.1f)
                    {
                        this.myAudioSource.clip = this.mySoundIndex[this.levelIndex];
                        this.myAudioSource.volume = 1;
                        this.myAudioSource.Play();
                    }
                }
            }
            else
            {
                if (!(this.myAudioSource.clip.name == this.gameplayMusic[this.myGameplayIndex].name))
                {
                    this.myAudioSource.volume = ((float) this.myAudioSource.volume) * 0.9f;
                    if (this.myAudioSource.volume < 0.1f)
                    {
                        this.myAudioSource.clip = this.gameplayMusic[this.myGameplayIndex];
                        this.myAudioSource.volume = 1;
                        this.myAudioSource.Play();
                    }
                }
            }
        }
    }

    public virtual void GameplayMusicLogic()
    {
        if (this.myGameplayIndex > (this.gameplayMusic.Length - 1))
        {
            this.myGameplayIndex = 0;
        }
    }
}