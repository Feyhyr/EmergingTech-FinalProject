using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeChange : MonoBehaviour
{
    private float clickValueSFX;
    public float increment;
    public Slider incrementorSfxSlider;
    private float maxSliderValueSFX;
    private float minSliderValueSFX;
    private float limit;

    private float clickValueMusic;
    public Slider incrementorMusicSlider;
    private float maxSliderValueMusic;
    private float minSliderValueMusic;

    AudioManager audioM;
    MusicManager musicM;

    public const string prefSFXvalue = "prefSFXvalue";
    public const string prefMusicValue = "prefMusicValue";

    private void Awake()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start()
    {
        clickValueSFX = PlayerPrefs.GetFloat(prefSFXvalue, 1f);
        incrementorSfxSlider.value = clickValueSFX;
        audioM.audio.volume = incrementorSfxSlider.value;

        clickValueMusic = PlayerPrefs.GetFloat(prefMusicValue, 1f);
        incrementorMusicSlider.value = clickValueMusic;
        musicM.audio.volume = incrementorMusicSlider.value;

        gameObject.SetActive(false);

        maxSliderValueSFX = incrementorSfxSlider.maxValue;
        minSliderValueSFX = incrementorSfxSlider.minValue;

        maxSliderValueMusic = incrementorMusicSlider.maxValue;
        minSliderValueMusic = incrementorMusicSlider.minValue;
    }

    private void Update()
    {
        incrementorSfxSlider.value = clickValueSFX;
        audioM.audio.volume = incrementorSfxSlider.value;

        incrementorMusicSlider.value = clickValueMusic;
        musicM.audio.volume = incrementorMusicSlider.value;
    }

    public void SFXIncreaseByOne()
    {
        if (clickValueSFX < maxSliderValueSFX)
        {
            limit = maxSliderValueSFX - increment;
            if (clickValueSFX < limit)
            {
                clickValueSFX = clickValueSFX + increment;
            }
            else
            {
                clickValueSFX = maxSliderValueSFX;
            }
        }
        PlayerPrefs.SetFloat(prefSFXvalue, clickValueSFX);
    }

    public void SFXDecreaseByOne()
    {
        if (clickValueSFX > minSliderValueSFX)
        {
            if (clickValueSFX > increment)
            {
                clickValueSFX = clickValueSFX - increment;
            }
            else
            {
                clickValueSFX = minSliderValueSFX;
            }
        }
        PlayerPrefs.SetFloat(prefSFXvalue, clickValueSFX);
    }

    public void MusicIncreaseByOne()
    {
        if (clickValueMusic < maxSliderValueMusic)
        {
            limit = maxSliderValueMusic - increment;
            if (clickValueMusic < limit)
            {
                clickValueMusic = clickValueMusic + increment;
            }
            else
            {
                clickValueMusic = maxSliderValueMusic;
            }
        }
        PlayerPrefs.SetFloat(prefMusicValue, clickValueMusic);
    }

    public void MusicDecreaseByOne()
    {
        if (clickValueMusic > minSliderValueMusic)
        {
            if (clickValueMusic > increment)
            {
                clickValueMusic = clickValueMusic - increment;
            }
            else
            {
                clickValueMusic = minSliderValueMusic;
            }
        }
        PlayerPrefs.SetFloat(prefMusicValue, clickValueMusic);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenuScene")
        {
            audioM = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            musicM = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        }
    }
}
