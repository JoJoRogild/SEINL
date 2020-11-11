using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaksine_pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "player")
        {
            PlayerPrefs.SetInt("Vaksiner", PlayerPrefs.GetInt("Vaksiner") + 1);
        }
    }
}