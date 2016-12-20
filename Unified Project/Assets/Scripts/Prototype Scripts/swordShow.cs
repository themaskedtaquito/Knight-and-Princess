using UnityEngine;
using System.Collections;

public class swordShow : MonoBehaviour {

	public GameObject sword;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.RightShift))
		{
			gameObject.GetComponent<Renderer>().enabled = true;
			sword.tag = "Sword";

		}
		if (Input.GetKeyUp (KeyCode.LeftShift)||Input.GetKeyUp(KeyCode.RightShift)) {

			gameObject.GetComponent<Renderer>().enabled = false;
			sword.tag = "Untagged";
		}
	}
}
