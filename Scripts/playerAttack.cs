﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{



    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCooldown = 0.3f;

    public Collider2D attackTrigger;

    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    public void attack()
    {
        attacking = true;
        attackTimer = attackCooldown;
        attackTrigger.enabled = true;
    }

    void Update()
    {
        if(Input.GetKeyDown("a")&& !attacking)
        {
            attack();
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }

        anim.SetBool("attacking", attacking);
    }

    
}
