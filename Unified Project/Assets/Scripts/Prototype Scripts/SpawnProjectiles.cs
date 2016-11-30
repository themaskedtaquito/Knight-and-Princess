using UnityEngine;
using System.Collections;

public class SpawnProjectiles : MonoBehaviour {
    public GameObject Slower;
    public GameObject Knockdown;

    private int interval;

	// Use this for initialization
	void Start () {
        interval = Random.Range(2, 6);
        InvokeRepeating("SpawnProjectile", 1, interval);
	}
	
	// Update is called once per frame
	void Update () {	    
	}

    void SpawnProjectile()
    {
        int SpawnChance = Random.Range(0, 2);
        if (SpawnChance > 0)
        {
            int SpawnType = Random.Range(0, 2);
            if (SpawnType > 0)
            {
                Instantiate(Knockdown, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(Slower, transform.position, Quaternion.identity);
            }
        }
    }
}
