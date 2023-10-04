using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public int space = 10;
    public List<Item> items = new List<Item>();


    public void Add(Item item)
    {
        if(item.showInInventory)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room");
                return;
            }
            items.Add(item);
            GameObject.Find("Canvas").GetComponent<InventoryUI>().UpdateUI();
        }
    }


    public void Remove(Item item)
    {
        items.Remove(item);
    }
}