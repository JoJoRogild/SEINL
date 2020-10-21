using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fjendeAi : MonoBehaviour
{

    public float patrolingSpeed = 10.0f;
    public Vector3 startingPoint;
    public Vector3 finishingPoint;
    public bool XORY;
    public Material mat;
    public GameObject meshStuff;
    public float speed;
    private Rigidbody2D rb;
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
        State = state.patrol;
        transform.position = startingPoint;
    }

    void Update()
    {
        if(XORY == false)//working with X
        {
            if (State == state.patrol)
            {
                finishingPoint = new Vector3(finishingPoint.x, transform.position.y);
                transform.position = Vector3.MoveTowards(transform.position, finishingPoint, patrolingSpeed * Time.deltaTime);
            }
        }
        else//working with Y
        {

        }
        updateMesh();
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "player")
        {
            Debug.Log("You hit da fucking player");
        }
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
}
