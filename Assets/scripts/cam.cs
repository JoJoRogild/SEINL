using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public bool isCam = true;
    public Transform player;

    void Update()
    {
        if (isCam == true) { transform.position = new Vector3(player.position.x, player.position.y, -10); }
        else { transform.position = new Vector3(player.position.x, player.position.y, player.position.z); }
    }
}
