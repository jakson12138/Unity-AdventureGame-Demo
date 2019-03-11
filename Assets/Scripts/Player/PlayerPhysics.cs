using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour {

    private Player player;

    private void Start()
    {
        player = this.gameObject.GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((player.playerState == player.jumpState || player.playerState == player.attackState) && OnGround())
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            player.idleState.dirLeft = player.jumpState.dirLeft;
            player.ChangeState(player.idleState);
        }
    }

    public bool OnGround()
    {
        float distance = player.GetComponent<BoxCollider2D>().size.y / 2 + 0.1f;

        int mask = 1 << LayerMask.NameToLayer("Tilemap");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance, mask);

        //Debug.Log(hit.collider);
        //Debug.Log(distance);

        return hit;
    }
}
