using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject spriteMasker;
    public float speed = 3;
    Rigidbody2D rb;
    Vector3 moveInput;
    void Start()
    {
        if (PlayerPrefs.GetFloat("powerup") == 0) { PlayerPrefs.SetFloat("powerup", 16); }
        spriteMasker.transform.localScale = new Vector3(PlayerPrefs.GetFloat("powerup"), PlayerPrefs.GetFloat("powerup"), 0);
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
    private void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.tag);
        if (coll.collider.tag == "win")
        {
            GetComponent<player>().winner();
        }
        else if (coll.gameObject.tag == "briller")
        {
            PlayerPrefs.SetFloat("powerup" ,spriteMasker.transform.localScale.x + 1);
            spriteMasker.transform.localScale = new Vector3(spriteMasker.transform.localScale.x + 1, spriteMasker.transform.localScale.y + 1, spriteMasker.transform.localScale.z);
            Destroy(coll.gameObject);
        }
    }
}