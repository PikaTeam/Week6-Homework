using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityTowardsAtSpawn : MonoBehaviour
{
    public Transform towards;
    public float minSpeed, maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        float speed = Random.Range(minSpeed, maxSpeed);
        var rb2d = GetComponent<Rigidbody2D>();
        var generalDirection = Vector2.MoveTowards(transform.position, towards.position, speed);
        rb2d.velocity =  (Vector3)generalDirection- transform.position;
    }
}
