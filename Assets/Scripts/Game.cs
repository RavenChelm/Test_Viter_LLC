using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game
{
    public static Game current;
    public float volumeSlide = 0;

    public Game()
    {
        volumeSlide = 0;
        current = this;
    }
    public void InputVolume(float value)
    {
        volumeSlide = value;
        SaveLoad.Save();
    }

}