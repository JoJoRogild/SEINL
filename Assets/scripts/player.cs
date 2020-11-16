using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    public int lastScene = 6;

    public void deadboy()
    {
        PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(2);
    }

    public void winner()
    {
        if (SceneManager.GetActiveScene().buildIndex == lastScene)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(3);
        }
    }
}
