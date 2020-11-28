using System.Collections;
using UnityEngine;

public class fjendeAi : MonoBehaviour
{

    public int fdgNumber;
    public LayerMask lmstart;
    public GameObject fuckDaGovernment;
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
    private bool can = false;

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
                if (OneorTwo == true)
                {
                    if (movinBack == false && canMove == true)
                    {
                        float x = Mathf.Floor(transform.position.x * 10) / 10;
                        x = transform.position.x - x;
                        x *= 10;
                        if (Mathf.Floor(transform.position.x) == startingPoint.x && Mathf.Floor(x) == startingPoint.x) { movinBack = true; canMove = false; }
                        transform.position = Vector3.MoveTowards(transform.position, startingPoint, patrolingSpeed * Time.deltaTime);
                    }
                    else if (movinBack == true && canMove == true)
                    {
                        if (Mathf.Floor(transform.position.x) == finishingPoint.x) { movinBack = false; canMove = false; }
                        transform.position = Vector3.MoveTowards(transform.position, finishingPoint, patrolingSpeed * Time.deltaTime);
                    }
                    else
                    {
                        if (movinBack == true)
                        {
                            anim.SetBool("leftRight", true);
                        }
                        else
                        {
                            anim.SetBool("rightLeft", true);
                        }
                    }
                }
                else
                {
                    if (movinBack == false && canMove == true)
                    {
                        if (transform.position.x == startingPoint.x) { movinBack = true; canMove = false; }
                        transform.position = Vector3.MoveTowards(transform.position, startingPoint, patrolingSpeed * Time.deltaTime);
                    }
                    else if (movinBack == true && canMove == true)
                    {
                        float x = Mathf.Floor(transform.position.x * 10) / 10;
                        if (x == finishingPoint.x) { movinBack = false; canMove = false; }
                        transform.position = Vector3.MoveTowards(transform.position, finishingPoint, patrolingSpeed * Time.deltaTime);
                    }
                    else
                    {
                        if (movinBack == true)
                        {
                            anim.SetBool("rightLeft", true);
                        }
                        else
                        {
                            anim.SetBool("leftRight", true);
                        }
                    }
                }
            }
            else if (State == state.hunting)
            {

                RaycastHit2D middle = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 0)), 10, lm);
                RaycastHit2D leftFar = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 92)), 10, lm);
                RaycastHit2D leftMiddleFar = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 75)), 10, lm);
                RaycastHit2D leftMiddle = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 56)), 10, lm);
                RaycastHit2D left = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 20)), 10, lm);
                RaycastHit2D leftAlittleSomethin = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 40)), 10, lm);
                RaycastHit2D rightFar = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, -92)), 10, lm);
                RaycastHit2D right = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, -20)), 10, lm);
                RaycastHit2D rightALittleSomthin = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, -40)), 10, lm);
                RaycastHit2D rightMiddle = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, -56)), 10, lm);
                RaycastHit2D rightMiddleFar = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, -75)), 10, lm);


                if (leftFar) { transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (leftMiddleFar) { Debug.Log("idk"); transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (leftMiddle) {transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (left && !middle) {transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (rightFar) { transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (rightMiddleFar) { transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (rightMiddle) { transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (right && !middle) {transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (middle) { rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }

            }
            else if (State == state.returning)
            {
                if(GameObject.Find("fuckDaGovernment(Clone)" + fdgNumber) == null) { GameObject idkfdg = Instantiate(fuckDaGovernment, startingPoint, Quaternion.identity); idkfdg.name = "fuckDaGovernment(Clone)" + fdgNumber; }
                else
                {
                    RaycastHit2D middle = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 0)), Mathf.Infinity, lmstart);
                    Debug.DrawRay(transform.position, new Vector2(180, 0), Color.green);
                    if (!middle) { transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime); }
                    else { rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                }
            }
        }
        else//working with Y
        {
            if (State == state.patrol)
            {
                if (OneorTwo == true)
                {
                    if (movinBack == false && canMove == true)
                    {
                        float y = Mathf.Floor(transform.position.y * 10) / 10;
                        if (y == finishingPoint.y) { movinBack = false; canMove = false; }
                        transform.position = Vector3.MoveTowards(transform.position, finishingPoint, patrolingSpeed * Time.deltaTime);
                    }
                    else if (movinBack == true && canMove == true)
                    {
                        if (Mathf.Floor(transform.position.y) == finishingPoint.y) { movinBack = false; canMove = false; }
                        transform.position = Vector3.MoveTowards(transform.position, finishingPoint, patrolingSpeed * Time.deltaTime);
                    }
                    else
                    {
                        if (movinBack == true)
                        {
                            anim.SetBool("DownUp", true);
                        }
                        else
                        {
                            anim.SetBool("UpDown", true);
                        }
                    }
                }
                else
                {
                    if (movinBack == false && canMove == true)
                    {
                        float y = Mathf.Floor(transform.position.y * 10) / 10;
                        if (y == startingPoint.y) { movinBack = true; canMove = false; }
                        transform.position = Vector3.MoveTowards(transform.position, startingPoint, patrolingSpeed * Time.deltaTime);
                    }
                    else if (movinBack == true && canMove == true)
                    {
                        float y = Mathf.Floor(transform.position.y * 10) / 10;
                        if (y == finishingPoint.y) { movinBack = false; canMove = false; }
                        transform.position = Vector3.MoveTowards(transform.position, finishingPoint, patrolingSpeed * Time.deltaTime);
                    }
                    else
                    {
                        if (movinBack == true)
                        {
                            anim.SetBool("UpDown", true);
                        }
                        else
                        {
                            anim.SetBool("DownUp", true);
                        }
                    }
                }
            }
            else if (State == state.hunting)
            {
                RaycastHit2D middle = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 0)), 4f, lm);
                RaycastHit2D leftFar = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 75)), 4f, lm);
                RaycastHit2D leftMiddleFar = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 55)), 4f, lm);
                RaycastHit2D leftMiddle = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 35)), 4f, lm);
                RaycastHit2D left = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 20)), 4f, lm);
                RaycastHit2D rightFar = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, -75)), 4f, lm);
                RaycastHit2D right = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, -20)), 3f, lm);
                RaycastHit2D rightMiddle = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, -35)), 4f, lm);
                RaycastHit2D rightMiddleFar = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, -55)), 4f, lm);

                if (leftFar) { transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (leftMiddleFar) { transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (leftMiddle) { transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (left && !middle) { transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (rightFar) { transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (rightMiddleFar) { transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (rightMiddle) { transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (right && !middle) { transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime); rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else if (middle) { rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                else { rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }

            }
            else if (State == state.returning)
            {
                if (GameObject.Find("fuckDaGovernment(Clone)") == null) { Instantiate(fuckDaGovernment, startingPoint, Quaternion.identity); }
                else
                {
                    RaycastHit2D middle = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2(180, 0)), Mathf.Infinity, lmstart);
                    Debug.DrawRay(transform.position, new Vector2(180, 0), Color.green);
                    if (!middle) { transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime); }
                    else { rb.MovePosition(transform.position + transform.right * Time.deltaTime * chansingSpeed); }
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "player" && GetComponent<PolygonCollider2D>().IsTouching(coll)) { State = state.hunting; anim.enabled = false; can = false; }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "player") { State = state.returning; can = true; }
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
    public void setFalse()
    {
        anim.SetBool("leftRight", false);
        anim.SetBool("rightLeft", false);
        anim.SetBool("UpDown", false);
        anim.SetBool("DownUp", false);
        canMove = true;
        startingrotation += 180;
    }
    public void setState()
    {
        if(State != state.returning || can == false) { return; }
        State = state.patrol;
        transform.position = startingPoint;
        canMove = true;
        anim.enabled = true;
        can = false;
        if (XORY == false && OneorTwo == true)
        {
            movinBack = true;
            anim.SetBool("leftRight", true);
        }
        else if (XORY == false && OneorTwo == false) 
        {
            movinBack = true;
            anim.SetBool("rightLeft", true);
        }
        else if (XORY == true && OneorTwo == true)
        {
            movinBack = false;
            anim.SetBool("DownUp", true);
        }
        else if (XORY == true && OneorTwo == false)
        {
            movinBack = true;
            anim.SetBool("UpDown", true);
        }
    }
}