﻿using UnityEngine;
using System.Collections;

public class KnightControls : MonoBehaviour {
    public GameObject currentPlatform;
    public Transform groundCheck;

	public GameObject sword;

    public float jumpForce = 500;
    public float moveForce = 200f;
    public float maxSpeed = 7;

    private Rigidbody2D rb;
    private Collider2D c;
    private bool grounded = true;
    private bool jump = false;

//	private bool armed = false;

	bool facingLeft = true;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        c = GetComponent<Collider2D>();
	}

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump = true;
        }

		if (Input.GetKeyDown(KeyCode.S))
		{
//			armed = true;
			sword.tag = "Sword";
		}
		if (Input.GetKeyUp (KeyCode.S)) {
//			armed = false;
			sword.tag = "Untagged";
		}

    }

    void FixedUpdate()
    {
        float direction = Input.GetAxis("Horizontal");

		rb.velocity = new Vector2 (direction * maxSpeed, rb.velocity.y);

		if (direction < 0 && !facingLeft) {
			Flip ();
		} else if (direction > 0 && facingLeft) {
			Flip ();
		}

//        if (rb.velocity.x * direction < maxSpeed)
//        {
//            rb.AddForce(Vector2.right * direction * moveForce);
//        }
//        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
//        {
//            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y); //.Sign() returns either 1 or -1
//        }
        if (jump == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }


    }
		
	void Flip(){
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ground") && col.gameObject != currentPlatform)
        {
            currentPlatform = col.gameObject;
        }

        if (col.gameObject.CompareTag("Slow"))
        {
            maxSpeed = 0.3f;
            StartCoroutine("RestoreSpeed");
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("KnockDown"))
        {
            c.isTrigger = true;
            Destroy(col.gameObject);
        }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ground") && other.gameObject != currentPlatform)
        {
            c.isTrigger = false;
        }
    }

    IEnumerator RestoreSpeed()
    {
        // restore speed to normal after x seconds
        yield return new WaitForSeconds(3);
        maxSpeed = 7;
    }
}
