using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform followThis;
    public float maxDistanceDelta = 5f;
    public bool freezeZ = true;

    private float frozenZpos;
    private float maxY;

    void Start()
    {
        if (freezeZ)
            frozenZpos = transform.position.z;

        maxY = transform.position.y;
    }       

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(0,0, frozenZpos) + (Vector3)Vector2.MoveTowards(transform.position, followThis.position, maxDistanceDelta *Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f * Time.deltaTime, frozenZpos);
        if (followThis.transform.position.y > maxY)
        {
            transform.position = new Vector3(0, 0, frozenZpos) + (Vector3)Vector2.MoveTowards(transform.position, followThis.position, maxDistanceDelta * Time.deltaTime);
            maxY = transform.position.y;
        }
    }
}
