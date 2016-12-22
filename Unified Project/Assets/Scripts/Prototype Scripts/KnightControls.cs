using UnityEngine;
using System.Collections;
[System.Serializable]

public class Boundary
{
    public float xMin, xMax;
}

public class KnightControls : MonoBehaviour {
    public GameController gameController;
    public GameObject currentPlatform;
    public Transform groundCheck;
    public GameObject groundzero;
	public GameObject knight;
    public Boundary boundary;

    public float jumpForce = 500;
    public float moveForce = 200f;
    public float maxSpeed = 10;

    private Rigidbody2D rb;
    private Collider2D c;
    private bool grounded = true;
    private bool jump = false;

	private Animator KnightAnimator;
    public BoxCollider2D swordCollider;


//	private bool armed = false;

	bool facingLeft = true;
	// Use this for initialization
	void Start () {
		KnightAnimator = GetComponent<Animator> ();
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

		if (grounded == true) {
			KnightAnimator.SetBool ("Ground", true);
		} else {
			KnightAnimator.SetBool ("Ground", false);
		}


    }

    void FixedUpdate()
    {
        

        float direction = Input.GetAxis("Horizontal");

//		float h = direction * maxSpeed;

		rb.velocity = new Vector2 (direction * maxSpeed, rb.velocity.y);

		KnightAnimator.SetFloat ("Speed", rb.velocity.x); //if this doesn't work use h
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
			// play animation on key press, use state name
			// KnightAnimator.Play ("jump");
            jump = false;
        }
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            rb.transform.position.y,
             rb.transform.position.z
        );

		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.W)) {

            swordCollider.enabled = true;
            swordCollider.isTrigger = true;
            KnightAnimator.SetBool ("Armed", true);          
            knight.tag = "Sword";
            

        } else {
			KnightAnimator.SetBool ("Armed", false);
            knight.tag = "Player";
            swordCollider.enabled = false;
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

        if (col.gameObject.CompareTag("Slow"))
        {
            maxSpeed = 2;
            StartCoroutine("RestoreSpeed");
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("KnockDown"))
        {
            if (currentPlatform != groundzero)
            {
                c.isTrigger = true;
                maxSpeed = 3;
                StartCoroutine("RestoreSpeed");
            }
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("Player"))
        {
            gameController.StartCoroutine("KnightWin");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ground") && other.gameObject != currentPlatform)
        {          
                c.isTrigger = false;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            gameController.StartCoroutine("KnightWin");
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ground") && col.gameObject != currentPlatform)
        {
            currentPlatform = col.gameObject;
        }
    }

    IEnumerator RestoreSpeed()
    {
        // restore speed to normal after x seconds
        yield return new WaitForSeconds(2);
        maxSpeed = 10;
    }

}