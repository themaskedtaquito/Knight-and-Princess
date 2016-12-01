using UnityEngine;
using System.Collections;

public class PrincessController : MonoBehaviour {

	public float speed;

	public GameObject block;
	public GameObject slow;
	public GameObject knockdown;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

//	private Rigidbody2D rb2d;

	void Start(){
//		rb2d = GetComponent<Rigidbody2D> ();

	}
	void Update() {
		float h = speed * Input.GetAxis("Mouse ScrollWheel");
		transform.Translate(h, 0, 0);

		if (Input.GetMouseButton (0) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (slow, shotSpawn.position, shotSpawn.rotation);
		}

		if (Input.GetMouseButton (1) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Vector3 screenPoint = Input.mousePosition;
			screenPoint.z = 20.0f; //distance of the plane from the camera
			screenPoint = Camera.main.ScreenToWorldPoint(screenPoint);
			Instantiate (block, screenPoint, shotSpawn.rotation);
			Debug.Log("mouse: " + Camera.main.ScreenToWorldPoint(screenPoint));
		}



		if (Input.GetMouseButton (2) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (knockdown, shotSpawn.position, shotSpawn.rotation);
		}
		

//		float moveH = Input.GetAxis ("Mouse ScrollWheel");
//
//		Vector2 movement = new Vector2 (moveH, 0);
//		rb2d.AddForce (movement * speed);
	}
}
