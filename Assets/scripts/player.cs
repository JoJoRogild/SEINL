using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    public GameObject spritemasker;
    public AudioSource dead22;
    private int lastScene = 1;

    public void deadboy()
    {
        if (dead22.isPlaying == false) { dead22.Play(); Invoke("dead", 1.33f); spritemasker.transform.localScale = new Vector3(0, 0, 0); }
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
