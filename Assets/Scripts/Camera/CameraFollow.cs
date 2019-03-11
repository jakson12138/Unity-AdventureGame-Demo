using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject follow;
    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = follow.transform.position;
    }

    private void Update()
    {
        Vector3 curPosition = follow.transform.position;

        Vector3 v = curPosition - lastPosition;
        this.transform.position += new Vector3(v.x, 0, 0);

        lastPosition = follow.transform.position;
    }
}
