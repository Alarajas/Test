using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    Button removeButtom;
    [SerializeField]
    Image icon;

    Item item;


    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;

    }


    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
    }


    public void Use()
    {
        if(item != null)
        {
            item.Use();
        }
    }

    public void RemoveFromInventory()
    {
        Inventory.Instance.Remove(item);
    }
}
