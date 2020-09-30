using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class åben_x : MonoBehaviour
{
    public bool åben_dør;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("åben", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision.transform.tag);
        if (collision.transform.tag == "player")
        {
            Debug.Log("åben plz");
            åben_dør = true;
            anim.SetBool("åben", true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("luk plz");
        åben_dør = false;
    }
}
