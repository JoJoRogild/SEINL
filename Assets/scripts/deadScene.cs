using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadScene : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("level") + 1);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            PlayerPrefs.SetFloat("powerup", 16);
            if (Input.GetMouseButton(0))
            {
                 SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
            }
        }
    }
}