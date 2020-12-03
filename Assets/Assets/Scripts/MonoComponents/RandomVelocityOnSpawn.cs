using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVelocityOnSpawn : MonoBehaviour
{

    public Vector2 min, max;

    // Start is called before the first frame update
    void Start()
    {
        var rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
    }

}
