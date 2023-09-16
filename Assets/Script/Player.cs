using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GamePlayManager;

public class Player : StateMachine
{

    public GameObject objPlayer;         
    public float MovementSpeed { get; private set; } = 3f;
    public float JumpForce { get; private set; } = 5f;
    public float LookRotationDampFactor { get; private set; } = 7f;
    public InputReader InputReader { get; set; }    //input system refeence

    [HideInInspector]
    public Vector3 PlayerLookDirection = Vector3.forward;   //current direction of player

    public BehaviourManager behaviourManager;

    public bool IsCarry = false;

    public List<ItemInfo> itemList = new List<ItemInfo>();

    public Transform stackParent;

    Dictionary<enumCarryItem, bool> dicHasItem = new Dictionary<enumCarryItem, bool>();
    Dictionary<enumCarryItem, List<GameObject>> poolItemList = new Dictionary<enumCarryItem, List<GameObject>>();

    public List<GameObject> itemStack = new List<GameObject>();

    private void Start()
    {
        InputReader = GetComponent<InputReader>();
        SwitchState(new PlayerMoveState(this));
        setIsCarry(false);
        dicHasItem.Add(enumCarryItem.Red, false);
        dicHasItem.Add(enumCarryItem.Green, false);
        dicHasItem.Add(enumCarryItem.Blue, false);
        dicHasItem.Add(enumCarryItem.Black, false);
    }

    public void setIsCarry(bool isCarry)
    {
        IsCarry = isCarry;
        behaviourManager.setIsCarry(IsCarry);
    }


    public void addItem(ItemInfo item)
    {
        itemList.Add(item);

        dicHasItem[item.enumCarry] = true;

        if (itemList.Count >0)
        {
            setIsCarry(true);
        }
        else
        {
            setIsCarry(false);
        }

        GameObject objItem = poolItem(item);
        itemStack.Add(objItem);

        resetStack();
    }

    public ItemInfo removeItem(ItemInfo item)
    {
        ItemInfo rItem = null;
        if(dicHasItem[item.enumCarry])
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].enumCarry == item.enumCarry)
                {
                    rItem = itemList[i];
                    itemList.RemoveAt(i);
                    break;
                }
            }
            bool isremoveItemAvailable = false;
            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].enumCarry == item.enumCarry)
                {
                    isremoveItemAvailable = true;
                    break;
                }
            }

            if (!isremoveItemAvailable)
            {
                dicHasItem[item.enumCarry] = false;
            }
        }

        for (int i = 0; i < poolItemList[item.enumCarry].Count; i++)
        {
            if (!poolItemList[item.enumCarry][i].activeInHierarchy)
            {
                poolItemList[item.enumCarry][i].SetActive(false);
                break;
            }
        }

        for (int i = 0; i < itemStack.Count; i++)
        {
            if(!itemStack[i].activeInHierarchy)
            {
                itemStack.RemoveAt(i);
                break;
            }
        }
        resetStack();
        return rItem;
    }

    public GameObject poolItem(ItemInfo item)
    {
        GameObject gameObject = null;
        if(poolItemList.ContainsKey(item.enumCarry))
        {
            for (int i = 0; i < poolItemList[item.enumCarry].Count; i++)
            {
                if(!poolItemList[item.enumCarry][i].activeInHierarchy)
                {
                    gameObject = poolItemList[item.enumCarry][i];
                    break;
                }
            }
            if(gameObject == null)
            {
                gameObject = Instantiate(item.itemPrefab, stackParent);
                poolItemList[item.enumCarry].Add(gameObject); 
            }
        }
        else
        {
            gameObject = Instantiate(item.itemPrefab, stackParent);

            List<GameObject> objList = new List<GameObject>();
            objList.Add(gameObject);
            poolItemList.Add(item.enumCarry, objList);
        }
        gameObject.SetActive(true);
        return gameObject;
    }

    public void resetStack()
    {
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < itemStack.Count; i++)
        {
            itemStack[i].transform.localPosition = pos;
            pos.y += 0.05f;
        }
    }
}
