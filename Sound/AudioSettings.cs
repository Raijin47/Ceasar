using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixer;
    [SerializeField] private AudioMixer mixera;
    [SerializeField] private Toggle toggleMusic;
    [SerializeField] private Slider sliderMusic;

    private void Start()
    {
        toggleMusic.isOn = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        sliderMusic.value = PlayerPrefs.GetFloat("MusicVolume", 0);
    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
            mixer.audioMixer.SetFloat("Music", 0);
        else
            mixer.audioMixer.SetFloat("Music", -80);

        PlayerPrefs.SetInt("MusicEnabled", enabled ? 1 : 0);
    }

    public void ChangeVolume(float volume)
    {
        mixer.audioMixer.SetFloat("Music", volume);

        PlayerPrefs.SetFloat("MusicVolume", volume);
    }  
}