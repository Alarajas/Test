using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    public override void Interact()
    {
        base.Interact();
        CharacterCombat combatManager = Player.Instance.characterCombat;
        combatManager.Attack();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
