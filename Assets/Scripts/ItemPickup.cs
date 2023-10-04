using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{

    public Item item;
    public override void Interact()
    {
        base.Interact();
        PickUp(item);
    }

    public void PickUp(Item item)
    {
        Inventory.Instance.Add(item);
        Destroy(gameObject);

    }
}
