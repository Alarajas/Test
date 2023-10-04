using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/HealthPotion")]
public class HealthPotion : Item
{
    public int healthGained;

    public override void Use()
    {
        base.Use();
        Debug.Log("Health Potion Use()");
        //GameManager.GainHealth(healthGained);
    }
}
