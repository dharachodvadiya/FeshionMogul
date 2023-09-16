using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GamePlayManager;

public class Customer : MonoBehaviour
{
    public enumCarryItem currentDemandItem;

    public GameObject objMesh;
    public GameObject MainMesh;

    public BillCounter billCounter;

    bool IsMove = false;
    bool isReadyForPurchase = false;

    Vector3 spawnPos;
    bool isBack = false;

    private void OnEnable()
    {
        objMesh.SetActive(false);
        MainMesh.GetComponent<Renderer>().material.color = Color.white;
    }

    private void FixedUpdate()
    {
        if (IsMove)
        {
            transform.position = Vector3.Lerp(transform.position, billCounter.transform.position, Time.deltaTime * 1);

            if(Mathf.Abs(transform.position.magnitude - billCounter.transform.position.magnitude) < 0.03f)
            {
                IsMove = false;
                isReadyForPurchase = true;
                objMesh.SetActive(true);
                transform.position = billCounter.transform.position;
            }
        }

        if(isBack)
        {
            transform.position = Vector3.Lerp(transform.position, spawnPos, Time.deltaTime * 1);

            if (Mathf.Abs(transform.position.magnitude - spawnPos.magnitude) < 0.03f)
            {
                isBack = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void setData(enumCarryItem demandItem,BillCounter billCounter)
    {
        currentDemandItem = demandItem;
        this.billCounter = billCounter;

        switch(demandItem)
        {
            case enumCarryItem.Red:
                objMesh.GetComponent<Renderer>().material.color = Color.red;
                break;
            case enumCarryItem.Green:
                objMesh.GetComponent<Renderer>().material.color = Color.green;
                break;
            case enumCarryItem.Black:
                objMesh.GetComponent<Renderer>().material.color = Color.black;
                break;
            case enumCarryItem.Blue:
                objMesh.GetComponent<Renderer>().material.color = Color.blue;
                break;
        }
        spawnPos = transform.position;
        IsMove = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isReadyForPurchase)
        {
            if (collision.gameObject.tag == enumTag.Player.ToString())
            {
                GameObject itemInfo = collision.gameObject.GetComponent<Player>().removeItem(currentDemandItem);

                if (itemInfo != null)
                {
                    billCounter.giveItemToCustomer();
                    isReadyForPurchase = false;
                    
                    objMesh.SetActive(false);

                    switch (currentDemandItem)
                    {
                        case enumCarryItem.Red:
                            MainMesh.GetComponent<Renderer>().material.color = Color.red;
                            break;
                        case enumCarryItem.Green:
                            MainMesh.GetComponent<Renderer>().material.color = Color.green;
                            break;
                        case enumCarryItem.Black:
                            MainMesh.GetComponent<Renderer>().material.color = Color.black;
                            break;
                        case enumCarryItem.Blue:
                            MainMesh.GetComponent<Renderer>().material.color = Color.blue;
                            break;
                    }

                    Invoke("goBack", 0.3f);
                }
            }
        }
        
    }

    public void goBack()
    {
        isBack = true;
    }

}
