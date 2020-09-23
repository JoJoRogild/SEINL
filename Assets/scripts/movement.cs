using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public int speed;

    void Start()
    {
        Debug.Log("test");
    }

    void Update()
    {

        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 pos = transform.position;
            pos.x = pos.x + -speed * Time.deltaTime;
            transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 pos = transform.position;
            pos.x = pos.x + speed * Time.deltaTime;
            transform.position = pos;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 pos = transform.position;
            pos.y = pos.y + speed * Time.deltaTime;
            transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 pos = transform.position;
            pos.y = pos.y + -speed * Time.deltaTime;
            transform.position = pos;
        }
    }
}
