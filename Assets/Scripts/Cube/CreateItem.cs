using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour {

    public GameObject prefab;
    private float speed;

    private void Start()
    {
        speed = 0.15f;
    }

    public void ItemCreate(int number)
    {
        float angle = Random.Range(0, 360f);
        float rotation = 360f / number;

        for(int i = 0;i < number; i++)
        {
            GameObject item = GameObject.Instantiate(prefab);
            item.transform.position = this.transform.position;
            Vector3 velocity = new Vector3(speed * Mathf.Cos(angle), speed * Mathf.Sin(angle), 0);

            item.AddComponent<Item>();
            item.GetComponent<Item>().SetVelocity(velocity);

            angle += rotation;
        }
    }
}
