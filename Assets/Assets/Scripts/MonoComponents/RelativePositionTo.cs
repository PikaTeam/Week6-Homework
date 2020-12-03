using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativePositionTo : MonoBehaviour
{

    public Transform relativeTo;
    public Vector3 position;
    public bool freezeX, freezeY, freezeZ;

    private Vector3 origin;

    void Start()
    {
        origin = transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        float newX = (freezeX)? origin.x : relativeTo.position.x + position.x;
        float newY = (freezeY) ? origin.y : relativeTo.position.y + position.y;
        float newZ = (freezeX) ? origin.z : relativeTo.position.z + position.z;
        transform.position = new Vector3(newX, newY, newZ);
    }
}
