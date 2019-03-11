using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerState {

    private bool doubleJump;
    private float horizontalSpeed;
    private float acceleration;
    //private bool oneAttack;

    public override void StartAction(Player player)
    {
        base.StartAction(player);

        doubleJump = true;
        acceleration = 0.1f;

        Vector2 curV = player.GetComponent<Rigidbody2D>().velocity;
        if (Mathf.Abs(curV.x) > 1f)
            horizontalSpeed = Mathf.Abs(curV.x);
        else
            horizontalSpeed = 1f;

        player.PlayAnimation("Jump");
    }

    public override void EndAction(Player player)
    {
        base.EndAction(player);
    }

    // Update is called once per frame
    public override void Update (Player player) {
        base.Update(player);

        InputHandle(player);
        AutoDrop(player);
	}

    public override void InputHandle(Player player)
    {
        base.InputHandle(player);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //player.attackState.lastPlayerState = player.jumpState;
            Vector3 v = player.GetComponent<Rigidbody2D>().velocity;
            v.y = -1f;
            player.GetComponent<Rigidbody2D>().velocity = v;
            player.attackState.dirLeft = dirLeft;
            player.ChangeState(player.attackState);
            return;
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (!dirLeft)
            {
                dirLeft = true;
                player.ChangeDirection();
            }

            Vector2 curV = player.GetComponent<Rigidbody2D>().velocity;
            curV.x = -1 * horizontalSpeed;
            player.GetComponent<Rigidbody2D>().velocity = curV; 
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (dirLeft)
            {
                dirLeft = false;
                player.ChangeDirection();
            }

            Vector2 curV = player.GetComponent<Rigidbody2D>().velocity;
            curV.x = horizontalSpeed;
            player.GetComponent<Rigidbody2D>().velocity = curV;
        }

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (doubleJump)
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.jumpSpeed);
                doubleJump = false;
            }
        }
    }

    private void AutoDrop(Player player)
    {
        player.GetComponent<Rigidbody2D>().velocity -= new Vector2(0, acceleration);
    }
}
