using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fjendeAi : MonoBehaviour
{

    public float rotationSpeed;
    public Transform player;
    public Animator anim;//1 leftRight 2 rightLeft 3 UpDown 4 DownUp
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
    public LayerMask lm;
    private Rigidbody2D rb;
    public float chansingSpeed;
    private bool isAnim;
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
        rb = GetComponent<Rigidbody2D>();
        anim.SetBool("XorY", XORY);
        anim.SetBool("1or2", OneorTwo);
        State = state.patrol;
        transform.position = startingPoint;
    }

    void Update()
    {
        move();
        updateMesh();
    }
    void move()
    {
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
                RaycastHit2D middle = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 0)), 3f, lm);
                RaycastHit2D leftFar = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 75)), 3f, lm);
                RaycastHit2D leftMiddleFar = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 55)), 3f, lm);
                RaycastHit2D leftMiddle = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 35)), 3f, lm);
                RaycastHit2D left = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 20)), 3f, lm);
                RaycastHit2D rightFar = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, -75)), 3f, lm);
                RaycastHit2D right = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, -20)), 3f, lm);
                RaycastHit2D rightMiddle = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, -35)), 3f, lm);
                RaycastHit2D rightMiddleFar = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, -55)), 3f , lm);

                if (leftFar) { transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (leftMiddleFar) { transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (leftMiddle) {transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (left && !middle) {Debug.Log("left"); transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (rightFar) { transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (rightMiddleFar) { transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (rightMiddle) { transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (right && !middle) {Debug.Log("right"); transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (middle) { rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }

            }
            else if (State == state.attacking)
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
        if (coll.tag == "player" && GetComponent<PolygonCollider2D>().IsTouching(coll)) { State = state.hunting; anim.enabled = false; }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "player") { State = state.patrol; }
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