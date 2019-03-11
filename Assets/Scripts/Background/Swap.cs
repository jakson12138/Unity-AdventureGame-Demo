using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour {

    public GameObject[] backgrounds;
    private int left;
    private int size;
    public GameObject target;
    private Vector3 lastPosition;
    private float moveX;
    private float moveToSwap;

	// Use this for initialization
	void Start () {
        lastPosition = target.transform.position;
        left = 0;
        moveX = 0;
        size = backgrounds.Length;
        moveToSwap = 19f;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 move = target.transform.position - lastPosition;
        moveX += move.x;

        if(moveX > moveToSwap)
        {
            SwapBackground(1);
        }
        else if(moveX < -1 * moveToSwap)
        {
            SwapBackground(0);
        }

        lastPosition = target.transform.position;
	}

    private void SwapBackground(int swapType)
    {
        if(swapType == 1)
        {
            backgrounds[left].transform.position += new Vector3(size * moveToSwap, 0, 0);
            left = (left + 1) % size;
        }
        else
        {
            int right = left == 0 ? size - 1 : left - 1;
            backgrounds[right].transform.position += new Vector3(-1 * size * moveToSwap, 0, 0);
            left = right;
        }

        moveX = 0f;
    }
}
