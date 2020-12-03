using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHub : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGrounded = false;
    public bool canMomentumJump = false;
    public LayerMask groundLayer;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        bool isTouchingGround = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0, -0.6f), 0.2f, groundLayer);
        isGrounded = isTouchingGround && rb2d.velocity.y < 0.1;
        bool isNearGroundF = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0, -0.85f), 0.4f, groundLayer);
        if (isNearGroundF && rb2d.velocity.y < -1)
            canMomentumJump = true;
        else canMomentumJump = false;


        Debug.Log("is GROUNDED: "+ isGrounded);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere((Vector2)transform.position + new Vector2(0, -0.85f), 0.4f);
    }

}
