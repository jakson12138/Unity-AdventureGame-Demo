using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState {

    public override void StartAction(Player player)
    {
        base.StartAction(player);

        player.PlayAnimation("Idle");
    }

    public override void EndAction(Player player)
    {
        base.EndAction(player);
    }

    // Update is called once per frame
    public override void Update (Player player) {
        base.Update(player);

        InputHandle(player);
        //player.GetComponent<Animator>().Play(1);
    }

    public override void InputHandle(Player player)
    {
        base.InputHandle(player);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.attackState.dirLeft = dirLeft;
            player.ChangeState(player.attackState);
            return;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //player.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.1f, 0);

            if (!dirLeft)
            {
                dirLeft = true;
                player.ChangeDirection();
            }
            player.walkState.dirLeft = dirLeft;
            player.ChangeState(player.walkState);
            //player.GetComponent<Animator>().SetTrigger("idleToWalk");
            return;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //player.GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, 0);

            if (dirLeft)
            {
                dirLeft = false;
                player.ChangeDirection();
            }
            player.walkState.dirLeft = dirLeft;
            player.ChangeState(player.walkState);
            //player.GetComponent<Animator>().SetTrigger("idleToWalk");
            return;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.jumpSpeed);
            player.ChangeState(player.jumpState);
            //player.GetComponent<Animator>().SetTrigger("idleToJump");
            return;
        }
    }
}
