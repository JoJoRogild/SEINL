using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    bool negativ = false;
    bool start = true;
    float intialRotate;
    bool canRotate = true;
    bool rotateRight = false;
    bool rotateLeft = false;
    Vector2 move;
    public float speed = 3;
    Rigidbody2D rb;
    Vector3 moveInput;
    public Animator anim;
    public enum movementState
    {
        left,
        right,
        backwards,
        forwards
    }
    movementState state;
    movementState stateLastFrame;
    void Start()
    {
        state = movementState.forwards;
        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(speed - 0.25f, speed + 0.25f);
    }
    void Update()
    {
        rb.freezeRotation = true;
        //Debug.Log(state);
        states();
        moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + moveInput * speed * Time.deltaTime);

        if (rotateLeft == true)
        {
            intialRotate = transform.localRotation.z;
            transform.Rotate(Vector3.forward * 90 * Time.deltaTime);
        }
        else if (rotateRight == true)
        {
            intialRotate = transform.localRotation.z;
            transform.Rotate(-Vector3.forward * 90 * Time.deltaTime);
        }
        rb.freezeRotation = false;
    }
    void LateUpdate()
    {
        if (start == true)
        {
            state = movementState.left;
        }
        //Debug.Log(transform.eulerAngles.z);
        stateLastFrame = state;
        if (transform.eulerAngles.z > 170 && transform.eulerAngles.z < 190 && rotateLeft == false && rotateRight == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (transform.eulerAngles.z > 80 && transform.eulerAngles.z < 100 && rotateLeft == false && rotateRight == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (transform.eulerAngles.z > 350 && rotateLeft == false && rotateRight == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (transform.eulerAngles.z < 10 && rotateLeft == false && rotateRight == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (transform.eulerAngles.z > 259 && transform.eulerAngles.z < 290 && rotateLeft == false && rotateRight == false)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else
        {
            transform.eulerAngles = transform.eulerAngles;
        }

        /*
        if (rotateLeft == false && rotateRight == false)
        {

        float round = Mathf.Floor(transform.eulerAngles.z) / 10;
        round = Mathf.Floor(round) * 10;

        transform.eulerAngles = new Vector3(0, 0, round);
        } */
    }

    void states()
    {/*
        if (canRotate == false)
        {
            return;
        }*/
        if (start == true)
        {
            start = false;
            return;
        }
        //changeds the state
        if (moveInput.x < 0)
        {
            state = movementState.left;
        }
        else if (moveInput.x > 0)
        {
            state = movementState.right;
        }
        else if (moveInput.y < 0)
        {
            state = movementState.backwards;
        }
        else if (moveInput.y > 0)
        {
            state = movementState.forwards;
        }
        //Debug.Log(state + " state");
        //Debug.Log(state + " state last frame");

        if (state == movementState.left && stateLastFrame == movementState.forwards)
        {
            //anim.Play("forwardToLeft");
            //rotateLeft90();
            //transform.Rotate(-Vector3.forward * 10 * Time.deltaTime);
            //anim.SetFloat("Blend2", -1.5f);
            //Debug.Log("state 1");
        }
        else if (state == movementState.left && stateLastFrame == movementState.backwards)
        {
            //rotateLeft90();
            //anim.Play("BackToLeft");
            //anim.SetFloat("Blend2", -0.5f);
        }
        else if (state == movementState.forwards && stateLastFrame == movementState.left)
        {
            //rotateRight90();
            //anim.Play("LeftToForward");
            //anim.SetFloat("Blend2", -3f);
        }
        else if (state == movementState.forwards && stateLastFrame == movementState.right)
        {
            //rotateLeft90();
            // anim.Play("RightToForward");
            //anim.SetFloat("Blend2", -4f);
        }
        else if (state == movementState.right && stateLastFrame == movementState.forwards)
        {
            //rotateRight90();
            //anim.Play("forwardToRight");
            //anim.SetFloat("Blend2", -2f);
        }
        else if (state == movementState.backwards && stateLastFrame == movementState.right)
        {
            //rotateRight90();
            //anim.Play("RightToBack");
            //anim.SetFloat("Blend2", -3.5f);
        }
        else if (state == movementState.backwards && stateLastFrame == movementState.left)
        {
            //rotateLeft90();
            //anim.Play("LeftToBack");
            //anim.SetFloat("Blend2", -2.5f);
        }
        else if (state == movementState.right && stateLastFrame == movementState.backwards)
        {
            //rotateLeft90();
            //anim.Play("BackToRight");
            //anim.SetFloat("Blend2", -1f);
        }
        else if (state == movementState.right && stateLastFrame == movementState.left)
        {
            //anim.SetFloat("Blend2", -6f);
            /*
            for(float i = 0;i <= 0.5f; i += 0.1f)
            {
                anim.SetFloat("Blend2", -6 - i);
            }*/
            //rotateLeft180();
        }
        else if (state == movementState.left && stateLastFrame == movementState.right)
        {
            //anim.SetFloat("Blend2", -5.5f);
            //rotateLeft180();
        }
        else if (state == movementState.backwards && stateLastFrame == movementState.forwards)
        {
            //anim.SetFloat("Blend2", -5f);
            //rotateLeft180();
        }
        else if (state == movementState.forwards && stateLastFrame == movementState.backwards)
        {
            //anim.SetFloat("Blend2", -4.5f);
            //rotateLeft180();
        }

    }
    /*
    void rotateLeft90()
    {
        //Debug.Log("ROTATELEFT90");
        Invoke("resetList", 1);
        float intialRotate = transform.localRotation.z;
        canRotate = false;
        rotateLeft = true;
        rotateRight = false;
        //transform.Rotate(-Vector3.forward * 40 * Time.deltaTime);
    }
    void rotateRight90()
    {
        //Debug.Log("ROTATERIGHT90");
        Invoke("resetList", 1);
        canRotate = false;
        rotateLeft = false;
        rotateRight = true;
    }
    void rotateLeft180()
    {
        //Debug.Log("ROTATELEFT180");
        Invoke("resetList", 2);
        canRotate = false;
        rotateLeft = true;
        rotateRight = false;
    }
    void rotateRight180()
    {
        //Debug.Log("ROTATERIGH180");
        Invoke("resetList", 2);
        canRotate = false;
        rotateLeft = false;
        rotateRight = true;
    }
    void resetList()
    {
        //Debug.Log("reset list");
        canRotate = false;
        rotateLeft = false;
        rotateRight = false;
    }*/

}

