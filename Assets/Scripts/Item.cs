using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/Items")]
public class Item : ScriptableObject
{
    public new string name = "New item";
    public Sprite icon = null;
    public bool showInInventory = true;

    public virtual void Use()
    {
        Debug.Log("Parent use method executed");
    }
}
