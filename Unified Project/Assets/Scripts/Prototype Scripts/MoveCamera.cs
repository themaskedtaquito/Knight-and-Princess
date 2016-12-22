using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
    public GameObject knight;
    private float offset = 25.5f;
    private float diff;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update()
    {
        diff = transform.position.y - knight.transform.position.y;
        if(diff < 17|| diff>offset)
        {
            if (transform.position.y < 156|| diff > 30)
            {
                Vector3 move;
                move = new Vector3(0, (knight.transform.position.y + offset), 0) - new Vector3(0, transform.position.y, 0);
                move.Normalize();
                if (move.y > 0)
                {
                    transform.position += move * Time.deltaTime * 8;
                }
                else {
                    transform.position += move * Time.deltaTime * 14;
                }
            }
        }
    }
}