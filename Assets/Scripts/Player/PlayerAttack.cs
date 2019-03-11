using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public float damage;
    public GameObject prefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Attack(float scale, Player player, float _range)
    {
        GameObject star = GameObject.Instantiate(prefab);
        star.transform.position = player.transform.position;
        star.transform.localScale = new Vector3(scale, scale, 1f);

        star.AddComponent<Star>();
        star.GetComponent<Star>().dirLeft = player.playerState.dirLeft;
        star.GetComponent<Star>().range = _range;
    }
}
