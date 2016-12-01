using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {
    public GameObject knight;
    private float offset;

	// Use this for initialization
	void Start () {
        offset = transform.position.y - knight.transform.position.y;
	}
	
	// Update is called once per frame
	public void movePlatform() {
        if (transform.position.y < 85                )
        {
            Vector3 temp = transform.position;
            temp.y = knight.transform.position.y + offset;
            transform.position = temp;
            //transform.position = Vector3.Lerp(transform.position, temp, .2f);
        }
	}
}