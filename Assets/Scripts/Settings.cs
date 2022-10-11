using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
public class Settings : MonoBehaviour
{
    [SerializeField] TMP_Text VolumeText;
    public AudioMixer am;
    public Game gm = new Game();
    public void AudioVolume(float sliderValue)
    {
        Game.current.InputVolume(sliderValue);
        float value = sliderValue * 0.05f;
        if (value <= 0.05)
            value = -50;
        am.SetFloat("Volume", value);
        VolumeText.SetText("Звук:" + Mathf.Round(sliderValue).ToString() + "%");
    }
}
