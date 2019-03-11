using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public enum SpikeType
{
    Letf,
    Right,
    Up,
    Down
}
*/

public class Spike : MonoBehaviour {

    //private SpikeType spikeType;
    protected float attackRange;
    protected float speed;
    private int attackCount;
    private int destroyCount;
    public bool canAttack;

    public Spike()
    {
        attackRange = 10f;
        speed = 0.1f;
        attackCount = 0;
        destroyCount = 100;
        canAttack = false;
    }

    public virtual bool RayToPlayer()
    {
        return false;
    }

    public virtual void Attack()
    {
        
    }

    private void Update()
    {
        if (!canAttack)
        {
            canAttack = RayToPlayer();
        }
        else
        {
            Attack();
            attackCount++;
            if(attackCount >= destroyCount)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
