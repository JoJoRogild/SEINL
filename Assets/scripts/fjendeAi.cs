﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fjendeAi : MonoBehaviour
{

    public float rotationSpeed;
    public Transform player;
    public Animator anim;//1 leftRight 2 rightLeft 3 UpDown 4 DownUp
    bool isAnim = false;
    public bool OneorTwo = true;
    private bool canMove = true;
    public float startingrotation = 0;
    private bool movinBack = false;
    public float patrolingSpeed = 10.0f;
    public Vector3 startingPoint;
    public Vector3 finishingPoint;
    public bool XORY;
    public Material mat;
    public GameObject meshStuff;
    enum state
    {
        patrol,
        idle,
        suspicicous,
        hunting,
        attacking,
        returning      
    }
    state State = new state();
    void Start()
    {
        anim.SetBool("XorY", XORY);
        anim.SetBool("1or2", OneorTwo);
        State = state.patrol;
        transform.position = startingPoint;
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, startingrotation);
        move();
        updateMesh();
    }
    void move()
    {
        if (isAnim == true) { return; }
        if (XORY == false)//working with X
        {
            if (State == state.patrol)
            {
                if (movinBack == false && canMove == true)
                {
                    if (transform.position.x == startingPoint.x) { movinBack = true; canMove = false; }
                    transform.position = Vector3.MoveTowards(transform.position, startingPoint, patrolingSpeed * Time.deltaTime);
                }
                else if (movinBack == true && canMove == true)
                {
                    if (transform.position.x == finishingPoint.x) { movinBack = false; canMove = false; }
                    transform.position = Vector3.MoveTowards(transform.position, finishingPoint, patrolingSpeed * Time.deltaTime);
                }
                else
                {
                    if (OneorTwo == true)
                    {
                        if (movinBack == true)
                        {
                            anim.SetBool("leftRight", true);
                            isAnim = true;
                        }
                        else
                        {
                            anim.SetBool("rightLeft", true);
                            isAnim = true;
                        }
                    }
                    else
                    {
                        if (movinBack == true)
                        {
                            anim.SetBool("rightLeft", true);
                            isAnim = true;
                        }
                        else
                        {
                            anim.SetBool("leftRight", true);
                            isAnim = true;
                        }
                    }
                }
            }
            else if (State == state.hunting)
            {
                if (player.position.y > transform.position.y)
                {
                    Debug.Log("u're r hunting the fucking player on the Up axis");
                    transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                }
                else
                {
                    Debug.Log("u're r hunting the fucking player on the Down axis");
                    transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
                }
            }
            else if(State == state.attacking)
            {
                Debug.Log("u're r attacking the fucking player");
            }
        }
        else//working with Y
        {
            Debug.Log(State);
            if (State == state.patrol)
            {
                if (movinBack == false && canMove == true)
                {
                    if (transform.position.y == startingPoint.y) { movinBack = true; canMove = false; }
                    transform.position = Vector3.MoveTowards(transform.position, startingPoint, patrolingSpeed * Time.deltaTime);
                }
                else if (movinBack == true && canMove == true)
                {
                    if (transform.position.y == finishingPoint.y) { movinBack = false; canMove = false; }
                    transform.position = Vector3.MoveTowards(transform.position, finishingPoint, patrolingSpeed * Time.deltaTime);
                }
                else
                {
                    if (OneorTwo == true)
                    {
                        if (movinBack == true)
                        {
                            anim.SetBool("DownUp", true);
                            isAnim = true;
                        }
                        else
                        {
                            anim.SetBool("UpDown", true);
                            isAnim = true;
                        }
                    }
                    else
                    {
                        if (movinBack == true)
                        {
                            anim.SetBool("UpDown", true);
                            isAnim = true;
                        }
                        else
                        {
                            anim.SetBool("DownUp", true);
                            isAnim = true;
                        }
                    }
                }
            }
            else if (State == state.hunting)
            {
                Debug.Log("u're r hunting the fucking player");
            }
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "player" && GetComponent<BoxCollider2D>().IsTouching(coll)) { State = state.attacking; }
        else if (coll.tag == "player" && GetComponent<PolygonCollider2D>().IsTouching(coll)) { State = state.hunting; }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "player" && !GetComponent<PolygonCollider2D>().IsTouching(coll)) { State = state.patrol; }
        else if (coll.tag == "player" && !GetComponent<BoxCollider2D>().IsTouching(coll)) { State = state.hunting; }
    }
    void updateMesh()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[4];

        vertices[0] = new Vector3(-1, 0.2f);
        vertices[1] = new Vector3(-1, 1);
        vertices[2] = new Vector3(4.5f, 3.1f);
        vertices[3] = new Vector3(4.5f, -1.9f);

        mesh.vertices = vertices;
        mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
        meshStuff.GetComponent<MeshRenderer>().material = mat;
        meshStuff.GetComponent<MeshFilter>().mesh = mesh;
    }
    void setFalse()
    {
        anim.SetBool("leftRight", false);
        anim.SetBool("rightLeft", false);
        anim.SetBool("UpDown", false);
        anim.SetBool("DownUp", false);
        isAnim = false;
        canMove = true;
        startingrotation += 180;
    }
}