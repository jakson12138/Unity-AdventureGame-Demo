using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
        playerPhysics = this.GetComponent<PlayerPhysics>();

        idleState = new IdleState();
        jumpState = new JumpState();
        runState = new RunState();
        walkState = new WalkState();
        attackState = new AttackState();

        playerState = jumpState;

        playerState.StartAction(this);
    }
	
	// Update is called once per frame
	void Update () {

        playerState.Update(this);

        //Debug.Log(playerState);
        //Debug.Log(this.GetComponent<Rigidbody2D>().velocity);
	}

    public void ChangeState(PlayerState ps)
    {
        playerState.EndAction(this);
        ps.lastPlayerState = playerState;
        playerState = ps;
        playerState.StartAction(this);
    }

    public void PlayAnimation(string stateName)
    {
        this.GetComponent<Animator>().Play(stateName);
    }

    public void ChangeDirection()
    {
        this.GetComponent<SpriteRenderer>().flipX = playerState.dirLeft;
    }

    public PlayerState playerState;

    public PlayerState idleState;
    public PlayerState jumpState;
    public PlayerState runState;
    public PlayerState walkState;
    public PlayerState attackState;

    public float jumpSpeed = 4f;

    private PlayerPhysics playerPhysics;
}
