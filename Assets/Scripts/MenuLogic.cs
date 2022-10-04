using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLogic : MonoBehaviour
{
    public GameObject Settings;
    public Slider MusicSlider;
    public Slider VoiceSlider;
    public AudioSource MusicSource;
    

    private void Start()
    {
        MusicSource.volume = PlayerPrefs.GetFloat("music");
        MusicSlider.value = PlayerPrefs.GetFloat("music");
        VoiceSlider.value = PlayerPrefs.GetFloat("voice");
    }

    public void onExitButtonPress()
    {
        Application.Quit();
    }

    public void onBackButtonPress()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void onSettingsButtonPress()
    {

        Settings.SetActive(true);
    }

    public void onPlayButtonPress()
    {

        SceneManager.LoadScene("Selection");
    }

    public void onCloseButtonPress()
    {
        if (Settings.activeSelf) Settings.SetActive(false); 
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Settings.activeSelf) Settings.SetActive(false);
            else if (SceneManager.GetActiveScene().name == "Selection") SceneManager.LoadScene("MainMenu");
            else
            {
                Application.Quit();
                PlayerPrefs.Save();
            }
        }
    }

    public void onMazeButtonPress()
    {
        SceneManager.LoadScene("Maze");
    }

    public void onFiguresButtonPress()
    {

        SceneManager.LoadScene("Figures");
    }

    public void onCCButtonPress()
    {

        SceneManager.LoadScene("ColourSelection");
    }

    public void onMusicSliderChanged()
    {
        MusicSource.volume = MusicSlider.value;
        PlayerPrefs.SetFloat("music", MusicSlider.value);
    }
    public void onVoiceSliderChanged()
    {
       
        PlayerPrefs.SetFloat("voice", VoiceSlider.value);
    }
}
