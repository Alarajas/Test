using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/Coin")]
public class Coin : Item
{
    public int scoreValue = 5;

    public override void Use()
    {
        base.Use();
        //Puntuazioa igo
    }
}
