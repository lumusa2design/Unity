using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicaPlay : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private int firstPlayInt;
    public Slider volumeSlider;
    public GameObject ObjectMusic;

    private float MusicVolume;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {


        ObjectMusic = GameObject.FindWithTag("GameMusic");
        audioSource = ObjectMusic.GetComponent<AudioSource>();

        MusicVolume = PlayerPrefs.GetFloat("volumen");
        audioSource.volume = MusicVolume;
        volumeSlider.value = MusicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volumen", MusicVolume);
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, MusicVolume);
    }

    private void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void VolumeUpdater(float volume)
    {
        MusicVolume = volume;
    }

    public void UpdateSound()
    {
        audioSource.volume = volumeSlider.value;
    }
}
