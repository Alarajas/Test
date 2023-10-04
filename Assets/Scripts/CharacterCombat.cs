using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField]
    private float attackRate;

    float attackCountdown = 0;


    public event Action OnAttack;
    private void Update()
    {
        attackCountdown -= Time.deltaTime;
    }

    public void Attack()
    {
        if(attackCountdown <= 0f)
        {
            attackCountdown = 1f / attackRate;
            // AttackLogika
            Debug.Log(transform.name + "is attacking its target");

            OnAttack.Invoke();
        }
    }

}
