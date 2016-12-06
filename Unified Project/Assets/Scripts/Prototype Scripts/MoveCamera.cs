using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
    public GameObject knight;
    private float offset = 15.5f;
    private float diff;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update()
    {
        diff = transform.position.y - knight.transform.position.y;
        Debug.Log(diff);
        if(diff < 12|| diff>offset)
        {
            Vector3 move;
            move = new Vector3(0,(knight.transform.position.y + offset),0)-new Vector3(0,transform.position.y,0);
            move.Normalize();
            transform.position += move * Time.deltaTime*7;
        }
    }
}