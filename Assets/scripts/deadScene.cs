using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadScene : MonoBehaviour
{
    void Update()
    {
        PlayerPrefs.SetFloat("powerup", PlayerPrefs.GetFloat("powerup") - PlayerPrefs.GetInt("powerupThisLevel"));
        PlayerPrefs.SetInt("powerupThisLevel", 0);
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("level") + 1);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (Input.GetMouseButton(0))
            {
                 SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
            }
        }
    }
}