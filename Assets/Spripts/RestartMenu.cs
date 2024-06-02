using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public void Restart()
    {
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenu()
    {
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene("Menu");
    }
}
