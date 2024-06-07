using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioSource AudioSource;
    public float masterVolume;
    public Scrollbar volume;

    private void Awake()
    {
        AudioSource.Play();

        masterVolume = PlayerPrefs.GetFloat("masterVolume", 1.0f);
        volume.value = masterVolume;
    }


    public void StartGame()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("Intro");
    }

    public void QuitGame()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void ChangeVolume()
    {
        masterVolume = volume.value;
        AudioSource.volume = masterVolume;
        PlayerPrefs.SetFloat("masterVolume", masterVolume);
        Debug.Log("Change Volume");
    }






}
