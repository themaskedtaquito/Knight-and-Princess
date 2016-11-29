using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed;

	void Start(){
		rb2d = GetComponent<Rigidbody2D> ();

		rb2d.velocity = (transform.up * -1) * speed;
	}
}
