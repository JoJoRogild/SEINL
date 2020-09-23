using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class døråben : MonoBehaviour
{
    public GameObject player;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x + 30)
        {
            if (player.transform.position.x > transform.position.x - 30)

                Debug.Log("åben");
        }
    }
}
