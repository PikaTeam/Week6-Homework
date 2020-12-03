using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementForce = 5;
    public float jumpForce = 10;
    public float jumpForceEffectByMomentomRatio;
    public float maxMovementVelocity = 10;

    public ParticleSystem highJumpEffect;
    public ParticleSystem momentumJumpEffect;

    private Rigidbody2D rb2d;
    private PlayerHub playerHub;
    private Vector2 forceToAddAtFixedUpdate;
    void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
        this.playerHub = GetComponent<PlayerHub>();
        this.forceToAddAtFixedUpdate = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        ProjectSpriteMovingDirection();

        if (Input.GetKey("d"))
        {
            if (rb2d.velocity.x < maxMovementVelocity)
                this.forceToAddAtFixedUpdate.x = movementForce;
        } 
        else if (Input.GetKey("a"))
        {
            if (-rb2d.velocity.x < maxMovementVelocity)
                this.forceToAddAtFixedUpdate.x = -movementForce;
        }

        if (!playerHub.isGrounded)
        {
            this.forceToAddAtFixedUpdate.x /= 1.5f;
        }

        if (Input.GetKeyDown("w"))
        {
            Debug.Log(rb2d.velocity.y.ToString() + " / "+ playerHub.canMomentumJump);
            if (playerHub.isGrounded)
            {
                this.forceToAddAtFixedUpdate.y = jumpForce + (Mathf.Abs(this.rb2d.velocity.x) * jumpForceEffectByMomentomRatio);
            }
            else if (playerHub.canMomentumJump)
            {
                var yVelocity = Mathf.Abs(rb2d.velocity.y);
                
                rb2d.velocity = new Vector2(rb2d.velocity.x, yVelocity);
                this.forceToAddAtFixedUpdate.y = (Mathf.Abs(this.rb2d.velocity.x) * jumpForceEffectByMomentomRatio * 1.1f);
                var effect = Instantiate(momentumJumpEffect, transform.position, Quaternion.identity);
            }

            if (this.forceToAddAtFixedUpdate.y > jumpForce*2)
            {
                var effect =  Instantiate(highJumpEffect, transform.position, Quaternion.identity);
                var rot = effect.GetComponent<ParticleSystem>().emission.rateOverTime;
                rot.constant *= ( 3*(forceToAddAtFixedUpdate.y) / (jumpForce) );
                var emission = effect.GetComponent<ParticleSystem>().emission;
                emission.rateOverTime = rot;


                var solt = effect.GetComponent<ParticleSystem>().sizeOverLifetime;
                solt.yMultiplier *= ((forceToAddAtFixedUpdate.y) / (jumpForce));
            }

        }
    } 

    void FixedUpdate()
    {
        if (forceToAddAtFixedUpdate != Vector2.zero)
        {
            this.rb2d.AddForce(forceToAddAtFixedUpdate);
            forceToAddAtFixedUpdate = Vector2.zero;
        }
    }


    private void ProjectSpriteMovingDirection()
    {
        if (rb2d.velocity.x == 0)
            return;
        var spRenderer = GetComponent<SpriteRenderer>();
        spRenderer.flipX = (rb2d.velocity.x > 0); 
    }
}
