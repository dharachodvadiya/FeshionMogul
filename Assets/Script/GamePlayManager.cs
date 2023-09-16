using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
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
}
