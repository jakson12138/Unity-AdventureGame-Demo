using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : PlayerState {

    public override void StartAction(Player player)
    {
        base.StartAction(player);

        player.PlayAnimation("Run");
        //Debug.Log("Run");
    }

    public override void EndAction(Player player)
    {
        base.EndAction(player);
    }

    public override void Update (Player player) {
        base.Update(player);

        InputHandle(player);
	}

    public override void InputHandle(Player player)
    {
        base.InputHandle(player);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (dirLeft)
            {
                //play animation
            }
            else
            {
                player.walkState.dirLeft = dirLeft;
                player.ChangeState(player.walkState);
                //player.GetComponent<Animator>().SetTrigger("runToWalk");
                return;
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (!dirLeft)
            {
                //play animation
            }
            else
            {
                player.walkState.dirLeft = dirLeft;
                player.ChangeState(player.walkState);
                //player.GetComponent<Animator>().SetTrigger("runToWalk");
                return;
            }
        }
        else
        {
            player.walkState.dirLeft = dirLeft;
            player.ChangeState(player.walkState);
            //player.GetComponent<Animator>().SetTrigger("runToWalk");
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.GetComponent<Rigidbody2D>().velocity += new Vector2(0, player.jumpSpeed);

            player.jumpState.dirLeft = dirLeft;
            player.ChangeState(player.jumpState);
            //player.GetComponent<Animator>().SetTrigger("runToJump");
            return;
        }
    }
}
