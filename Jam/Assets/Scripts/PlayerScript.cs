using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : Creature
{
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Grounded = true;
    }

    void Update()
    {
        CheckForMovement();
        CheckForJump();
    }

    private void CheckForJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
            base.Jump();
        var hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1 << 8);
        if (hitInfo.collider != null && base.IsStandingStill)
            Grounded = true;
    }

    private void CheckForMovement()
    {
        var horizontalInput = Input.GetAxisRaw(Constants.Horizontal);
        base.Move(horizontalInput);
    }
}
