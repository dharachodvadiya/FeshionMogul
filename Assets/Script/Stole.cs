using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GamePlayManager;

public class Stole : MonoBehaviour
{

    public enumCarryItem carryItem;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == enumTag.Player.ToString())
        {
            Debug.Log("player carry Item");
        }
    }
}
