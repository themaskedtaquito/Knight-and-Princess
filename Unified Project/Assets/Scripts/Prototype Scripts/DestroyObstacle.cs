using UnityEngine;
using System.Collections;

public class DestroyObstacle : MonoBehaviour {
    public int hp;
    public bool trap = false;
    public PrincessController p; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.CompareTag("Sword")){
            Debug.Log("attack");
            hp -= 1;
            if(hp == 0)
            {
                Destroy(gameObject);
                if (trap)
                {
                    other.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                }
            }
        }
    }
}
