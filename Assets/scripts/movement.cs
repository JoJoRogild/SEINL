using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 3;
    Rigidbody2D rb;
    Vector3 moveInput;
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.MovePosition(transform.position + moveInput * speed * Time.deltaTime);
        setRotataion();
    }
    void setRotataion()
    {
        if (moveInput.x == 1 && moveInput.y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 135);
        }
        else if (moveInput.x == 1 && moveInput.y == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else if (moveInput.x == -1 && moveInput.y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 225);
        }
        else if (moveInput.x == -1 && moveInput.y == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 315);
        }
        else if (moveInput.x == 1 && moveInput.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (moveInput.x == -1 && moveInput.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (moveInput.x == 0 && moveInput.y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (moveInput.x == 0 && moveInput.y == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}