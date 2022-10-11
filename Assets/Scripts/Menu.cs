using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    [SerializeField] GameObject VictoryScreen;
    [SerializeField] GameObject FailScreen;
    [SerializeField] GameObject VolumeScreen;
    [SerializeField] GameObject Volumebutton;
    [SerializeField] Slider slider;

    public AudioMixer am;
    private Game gm = new Game();
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject content4;
    [SerializeField] private GameObject content6;

    float time = 0;
    bool victoryPhase1 = false;
    bool victoryPhase2 = false;

    private void Awake()
    {

        am.SetFloat("Volume", Game.current.volumeSlide);
        SaveLoad.Load();
        if (SaveLoad.savedGames != null)
            slider.value = SaveLoad.savedGames[0].volumeSlide;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
        am.SetFloat("Volume", Game.current.volumeSlide);
        victoryPhase1 = false;
        victoryPhase2 = false;
        time = 0;
    }
    public void OnVictoryScreen()
    {
        OffAnotherMenu();
        VictoryScreen.SetActive(true);
    }
    public void OnFailScreen()
    {
        OffAnotherMenu();
        FailScreen.SetActive(true);
    }
    public void OnVolumeScreen()
    {
        OffAnotherMenu();
        VolumeScreen.SetActive(true);
    }
    public void OffAnotherMenu()
    {
        VictoryScreen.SetActive(false);
        FailScreen.SetActive(false);
        VolumeScreen.SetActive(false);
    }

    public void Determinate(string number)
    {
        if (number != "5")
        {
            OnFailScreen();
        }
        else
        {
            OnVictoryScreen();
            victoryPhase1 = true;
        }

    }
    IEnumerator startDeterminate(string number)
    {
        victoryPhase1 = true;
        yield return new WaitForSeconds(1f);
        Determinate(number);
    }
    private void Update()
    {
        if (victoryPhase1 == true)
        {
            Debug.Log("ll");
            sinAnimat();
        }
    }
    public void sinAnimat()
    {
        var time = +Time.deltaTime;
        float sin = Mathf.Cos(time);
        var widht = content.transform.localScale.x;
        var height = content.transform.localScale.y;
        content.GetComponent<RectTransform>().localScale = new Vector3(widht * sin / 1.2f, height * sin / 1.2f, 1);
        content4.GetComponent<RectTransform>().localScale = new Vector3(widht * sin / 1.2f, height * sin / 1.2f, 1);
        content6.GetComponent<RectTransform>().localScale = new Vector3(widht * sin / 1.2f, height * sin / 1.2f, 1);

    }
}
