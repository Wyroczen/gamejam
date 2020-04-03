using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oni : Creature
{



    protected override void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Grounded = true;
    }

    protected override void Update()
    {
        throw new System.NotImplementedException();
    }

    public override void Attack()
    {
        base.Attack();
    }



}
