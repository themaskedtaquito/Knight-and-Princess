using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrincessController : MonoBehaviour {

	public float speed;
    public float fireRate;
    private float nextFire;
    public Transform shotSpawn;

    public GameObject block;
    public GameObject knockblock;
	public GameObject slow;
    public GameObject knockdown;

    public Button slowButton;
    public Button knockdownButton;
    public Button knockcharges;
    public Button charges;

    private GameObject CurrentShot;
    private GameObject blockType;

    private int blockCharges = 5;
    private int knockblockCharges = 3;
    private bool charging = false;

//	private Rigidbody2D rb2d;

	void Start(){
        //		rb2d = GetComponent<Rigidbody2D> ();
        CurrentShot = slow;
        slowButton.image.color = new Color(0, 176, 9);
        slowButton.onClick.AddListener(ToggleProjectiles);
        knockdownButton.onClick.AddListener(ToggleProjectiles);
    }
	void Update() {
		float h = speed * Input.GetAxis("Mouse ScrollWheel");
		transform.Translate(h, 0, 0);

		if (Input.GetMouseButton (0) && Time.time > nextFire) { //need to add conditional so that it does not fire if click is on UI button
			nextFire = Time.time + fireRate;
			Instantiate (CurrentShot, shotSpawn.position, shotSpawn.rotation);
		}

		if (Input.GetMouseButtonDown (1) && blockCharges>0) {
			
            if(blockType == block)
            {
                if (blockCharges > 0)
                {
                    PlaceBlock();
                    blockCharges -= 1;
                }
            }
        }

        if(blockCharges<5 &&  charging == false)
        {
            StartCoroutine("RestoreCharges");
        }

        if (Input.GetMouseButtonDown(2))
        {
            ToggleProjectiles();
        }	

//		float moveH = Input.GetAxis ("Mouse ScrollWheel");
//
//		Vector2 movement = new Vector2 (moveH, 0);
//		rb2d.AddForce (movement * speed);
	}

    void ToggleProjectiles()
    {
        if (CurrentShot == slow)
        {
            slowButton.image.color = new Color(255,255,255);
            knockdownButton.image.color = new Color(0, 176, 9);
            CurrentShot = knockdown;
            fireRate = 1.0f;
        }
        else
        {
            knockdownButton.image.color = new Color(255, 255, 255);
            slowButton.image.color = new Color(0, 176, 9);
            CurrentShot = slow;
            fireRate = 0.5f;
        }
    }

    void PlaceBlock()
    {
        nextFire = Time.time + fireRate;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Instantiate(blockType, hit.point, Quaternion.identity);
        }
        blockCharges -= 1;
        charges.GetComponentInChildren<Text>().text = blockCharges.ToString();
    }

    IEnumerator RestoreCharges(chargetype)
    {
        charging = true;
        yield return new WaitForSeconds(5);
        chargetype += 1;
        charges.GetComponentInChildren<Text>().text = blockCharges.ToString();
        charging = false;
    }
}
