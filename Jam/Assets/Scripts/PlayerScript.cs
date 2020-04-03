using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : Creature
{
    protected override void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Grounded = true;
    }

    protected override void Update()
    {
        CheckForMovement();
        CheckForJump();
        CheckForAttack();
        CheckForBuild();
    }

    private void CheckForJump()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
            base.Jump();
        var hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1 << 8);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Grodunded:" + Grounded);
            Debug.Log("Velocity:" + Rigidbody.velocity.y);
            Debug.Log("Colider:" + hitInfo == null ? "hitinfo is null" : hitInfo.collider == null ? "collider is null" : hitInfo.collider.name);
        }

        if (base.IsStandingStill)
            Grounded = true;
    }

    private void CheckForAttack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            base.Attack();
        }
    }

    private void CheckForMovement()
    {
        var horizontalInput = Input.GetAxisRaw(Constants.Horizontal);
        Animator.SetFloat("Move", Math.Abs(horizontalInput));
        base.Move(horizontalInput);
    }

    private void CheckForBuild()
    {
        if (Input.GetKeyDown(KeyCode.B))
            BuildGate();
        if (Input.GetKeyDown(KeyCode.N))
            BuildLantern();
    }

    private void BuildLantern()
    {
        throw new NotImplementedException();
    }

    private void BuildGate()
    {
        throw new NotImplementedException();
    }
}
