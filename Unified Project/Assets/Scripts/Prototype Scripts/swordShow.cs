using UnityEngine;
using System.Collections;

public class swordShow : MonoBehaviour {
    public float fireRate;
    private float nextFire;
    public GameObject sword;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.W))
		{
            if (Time.time > nextFire)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                sword.tag = "Sword";
            }

        }
		if (Input.GetKeyUp (KeyCode.LeftShift)||Input.GetKeyUp(KeyCode.W)) {
            if (Time.time > nextFire)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                sword.tag = "Untagged";
                nextFire = Time.time + fireRate;
            }
        }
	}
}
