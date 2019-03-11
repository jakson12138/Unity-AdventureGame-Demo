using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    private Vector3 velocity;
    private float dropAcceleration;
    private float lifeTime;

    private void Start()
    {
        lifeTime = 3f;
        dropAcceleration = 0.001f;
        StartCoroutine("WaitToDie");
    }

    public void SetVelocity(Vector3 v)
    {
        velocity = v;
    }

    // Update is called once per frame
    void Update () {

        this.transform.position += velocity;
        velocity.y -= dropAcceleration;

	}

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(lifeTime);
        Die();
    }

    private void Die()
    {
        Destroy(this.gameObject);
        //Debug.Log("Die");
    } 
}
