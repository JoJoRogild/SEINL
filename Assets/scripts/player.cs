using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    public AudioSource dead22;
    public int lastScene = 6;

    public void deadboy()
    {
        if (dead22.isPlaying == false) { dead22.Play(); Invoke("dead", 1.33f); }
    }

    void dead()
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
