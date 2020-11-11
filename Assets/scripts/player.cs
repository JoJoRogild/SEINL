using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    
    public void deadboy()
    {
        PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(2);
    }
}
