using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : PlayerState {

    //private float walkTime;
    //private float walkToRunTime;
    //private float lastTime;

    private float acceleration1 = 0.25f;
    private float acceleration2 = 1f;
    private float acceleration3 = 0.1f;
    private float speedWalkToRun = 3f;

    public override void StartAction(Player player)
    {
        base.StartAction(player);

        //walkTime = 0f;
        //lastTime = Time.time;
        //walkToRunTime = 0.5f;

        player.PlayAnimation("Walk");
    }

    public override void EndAction(Player player)
    {
        base.EndAction(player);
    }

    // Update is called once per frame
    public override void Update (Player player) {
        base.Update(player);

        //walkTime += Time.time - lastTime;
        //lastTime = Time.time;

        InputHandle(player);
	}

    public override void InputHandle(Player player)
    {
        base.InputHandle(player);

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (dirLeft)
            {
                player.GetComponent<Rigidbody2D>().velocity += new Vector2(-1 * acceleration1, 0);

                Vector2 curV = player.GetComponent<Rigidbody2D>().velocity;
                if (curV.x <= -1 * speedWalkToRun)
                {
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * speedWalkToRun, 0);

                    player.runState.dirLeft = dirLeft;
                    player.ChangeState(player.runState);
                    //player.GetComponent<Animator>().SetTrigger("walkToRun");
                    return;
                }
            }
            else
            {
                //walkTime = 0;
                player.GetComponent<Rigidbody2D>().velocity += new Vector2(-1 * acceleration2, 0);

                Vector2 curV = player.GetComponent<Rigidbody2D>().velocity;
                if(curV.x <= 0f)
                {
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    player.ChangeState(player.idleState);
                    //player.GetComponent<Animator>().SetTrigger("walkToIdle");
                    return;
                }
            }
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (!dirLeft)
            {
                player.GetComponent<Rigidbody2D>().velocity += new Vector2(acceleration1, 0);

                Vector2 curV = player.GetComponent<Rigidbody2D>().velocity;
                if (curV.x >= speedWalkToRun)
                {
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(speedWalkToRun, 0);

                    player.runState.dirLeft = dirLeft;
                    player.ChangeState(player.runState);
                    //player.GetComponent<Animator>().SetTrigger("walkToRun");
                    return;
                }
            }
            else
            {
                //walkTime = 0;
                player.GetComponent<Rigidbody2D>().velocity += new Vector2(acceleration2, 0);

                Vector2 curV = player.GetComponent<Rigidbody2D>().velocity;
                if (curV.x >= 0f)
                {
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    player.ChangeState(player.idleState);
                    //player.GetComponent<Animator>().SetTrigger("walkToIdle");
                    return;
                }
            }
        }
        else
        {
            if (dirLeft)
            {
                player.GetComponent<Rigidbody2D>().velocity += new Vector2(acceleration3, 0);

                Vector2 curV = player.GetComponent<Rigidbody2D>().velocity;
                if (curV.x >= 0f)
                {
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    player.ChangeState(player.idleState);
                    //player.GetComponent<Animator>().SetTrigger("walkToIdle");
                    return;
                }
            }
            else
            {
                player.GetComponent<Rigidbody2D>().velocity += new Vector2(-1 * acceleration3, 0);

                Vector2 curV = player.GetComponent<Rigidbody2D>().velocity;
                if (curV.x <= 0f)
                {
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    player.ChangeState(player.idleState);
                    //player.GetComponent<Animator>().SetTrigger("walkToIdle");
                    return;
                }
            }
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.GetComponent<Rigidbody2D>().velocity += new Vector2(0, player.jumpSpeed);

            player.jumpState.dirLeft = dirLeft;
            player.ChangeState(player.jumpState);
            //player.GetComponent<Animator>().SetTrigger("walkToJump");
            return;
        }
    }
}
