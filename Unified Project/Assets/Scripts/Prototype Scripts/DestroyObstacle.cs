using UnityEngine;
using System.Collections;

public class DestroyObstacle : MonoBehaviour {
    public int hp;
    public bool trap = false; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.CompareTag("Sword")){
            hp -= 1;
            if(hp == 0)
            {
                Destroy(gameObject);
                if (trap)
                {
                    Debug.Log(other.gameObject.GetComponentInParent<Collider2D>().isTrigger);
                    other.gameObject.transform.parent.GetComponent<Collider2D>().isTrigger = true;
                    Debug.Log(other.gameObject.GetComponentInParent<Collider2D>().isTrigger);
                }
            }
        }
    }
}
