using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public GameObject customerPrefab;

    public List<GameObject> objCustomerList = new List<GameObject>();
    public enum enumCarryItem
    {
        Red,
        Green,
        Blue,
        Black
    }

    public enum enumTag
    {
        Player
    }

    public class ItemInfo
    {
        public enumCarryItem enumCarry;
        public int price;
        public GameObject itemPrefab;

        public ItemInfo(enumCarryItem enumCarry, int price, GameObject itemPrefab)
        {
            this.enumCarry = enumCarry;
            this.price = price;
            this.itemPrefab = itemPrefab;
        }
    }

    public void createCustomer(BillCounter billCounter)
    {
        GameObject objCust = poolCustomer();
        objCust.transform.position = billCounter.gameObject.transform.position;
        objCust.GetComponent<Customer>().setData((enumCarryItem)Random.Range(0, 4),billCounter);
        billCounter.setCustomer(objCust.GetComponent<Customer>());
    }

    public GameObject poolCustomer()
    {
        GameObject gameObject = null;
        for (int i = 0; i < objCustomerList.Count; i++)
        {
            if (!objCustomerList[i].activeInHierarchy)
            {
                gameObject = objCustomerList[i];
                break;
            }
        }
        if (gameObject == null)
        {
            gameObject = Instantiate(customerPrefab);
            objCustomerList.Add(gameObject);
        }
        gameObject.SetActive(true);
        return gameObject;
    }
}
