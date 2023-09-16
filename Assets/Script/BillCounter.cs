using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GamePlayManager;

public class BillCounter : MonoBehaviour
{
    public Customer currentCustomer;

    public bool isOpen = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == enumTag.Player.ToString())
        {
            Debug.Log("player bill Item");
        }
    }
}
