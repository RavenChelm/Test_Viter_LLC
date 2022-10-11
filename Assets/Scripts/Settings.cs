using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Settings : MonoBehaviour
{
    public AudioMixer am;
    public Game gm = new Game();
    public void AudioVolume(float sliderValue)
    {
        Game.current.InputVolume(sliderValue);
        am.SetFloat("Volume", Game.current.volumeSlide);
    }
}
