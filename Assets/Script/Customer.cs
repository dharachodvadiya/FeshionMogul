using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GamePlayManager;

public class Customer : MonoBehaviour
{
    public enumCarryItem currentDemandItem;

    public GameObject objMesh;

    public BillCounter billCounter;

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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == enumTag.Player.ToString())
        {
            GameObject itemInfo = collision.gameObject.GetComponent<Player>().removeItem(currentDemandItem);

            if(itemInfo != null)
            {
                billCounter.giveItemToCustomer();
            }
        }
    }
}
