using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GamePlayManager;

public class BillCounter : MonoBehaviour
{
    public Customer currentCustomer;

    public bool isOpen = true;

    public GamePlayManager gamePlayManager;

    private void Start()
    {
        gamePlayManager = FindAnyObjectByType<GamePlayManager>();

        StartCoroutine(coroutineCreateCustomer());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == enumTag.Player.ToString())
        {
           // Debug.Log("player bill Item");
        }
    }

    public void giveItemToCustomer()
    {
        isOpen = true;
        currentCustomer.gameObject.SetActive(false);
        currentCustomer = null;

        StartCoroutine(coroutineCreateCustomer());
    }

    public void setCustomer(Customer customer)
    {
        this.currentCustomer = customer;
        isOpen = false;
    }

    IEnumerator coroutineCreateCustomer()
    {
        yield return new WaitForSeconds(2f);
        gamePlayManager.createCustomer(this);
    }
}
