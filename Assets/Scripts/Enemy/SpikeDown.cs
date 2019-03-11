using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDown : Spike {

    public override bool RayToPlayer()
    {
        int mask = 1 << LayerMask.NameToLayer("Player");
        bool hit = Physics2D.Raycast(transform.position, Vector2.down, attackRange, mask);

        return hit;
    }

    public override void Attack()
    {
        this.transform.position += new Vector3(0, -1 * speed, 0);
    }

}
