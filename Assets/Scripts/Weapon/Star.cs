using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    private float speed;
    private float damage;
    public float range;
    public bool dirLeft;

    private float distance;

	// Use this for initialization
	void Start () {
        distance = 0f;
        speed = 0.1f;
        damage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (dirLeft)
        {
            this.transform.position += new Vector3(-1 * speed, 0, 0);
        }
        else
        {
            this.transform.position += new Vector3(speed, 0, 0);
        }

        distance += speed;

        if(distance >= range)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

}
