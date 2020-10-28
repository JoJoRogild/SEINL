using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oebne_doer : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("if enter");
        if(collision.transform.tag == "player")
        {
            anim.SetBool("åben", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("if exit");
        if (other.transform.tag == "player")
        {
            anim.SetBool("åben", false);
        }
    }
}
