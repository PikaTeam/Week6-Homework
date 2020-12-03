using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    [Tooltip("Push with this direction and speed")]
    [SerializeField] Vector2 thrust;

    // Start is called before the first frame update
    void Start()
    {
        var rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = (thrust);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
