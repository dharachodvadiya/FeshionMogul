using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GamePlayManager;

public class Stole : MonoBehaviour
{

    public enumCarryItem carryItem;
    public int price = 10;

    public GameObject ItemPrefab;

    private ItemInfo itemInfo;
    private Player currPlayer;

    public GameObject objTouch;

    private void Start()
    {
        itemInfo = new ItemInfo(carryItem, price, ItemPrefab);
        objTouch.SetActive(false);
    }

    public ItemInfo getItem()
    {
        return itemInfo;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == enumTag.Player.ToString())
        {
            //Debug.Log("player carry Item");
            objTouch.SetActive(true);

            currPlayer = other.GetComponent<Player>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == enumTag.Player.ToString())
        {
            //Debug.Log("player carry Item");
            objTouch.SetActive(false);
            currPlayer = null;
        }
    }

    public void btnCarryClick()
    {
        //Debug.Log("btnClick");
        if(currPlayer != null)
        {
            currPlayer.addItem(itemInfo);

        }
    }
}
