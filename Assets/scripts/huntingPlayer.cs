using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huntingPlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject enemy;
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "player") { Player.GetComponent<player>().deadboy();}
        else if (coll.tag == "fuckDaGovernment" && GetComponent<BoxCollider2D>().IsTouching(coll)) { Destroy(GameObject.Find("fuckDaGovernment(Clone)")); enemy.GetComponent<fjendeAi>().setFalse(); enemy.GetComponent<fjendeAi>().setState(); }
    }
}
