﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrincessController : MonoBehaviour {

	public float speed;
    public float fireRate;
    private float nextFire;
    public Transform shotSpawn;
    public GameController gameControls;

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
    private bool charging2 = false;

    //	private Rigidbody2D rb2d;

    void Start(){
//        rb2d = GetComponent<Rigidbody2D> ();
        CurrentShot = slow;
        blockType = block;
        slowButton.image.color = new Color(0, 176, 9);
        charges.image.color = new Color(0, 176, 9);
        slowButton.onClick.AddListener(ToggleProjectiles);
        knockdownButton.onClick.AddListener(ToggleProjectiles);
        charges.onClick.AddListener(ToggleBlocks);
        knockcharges.onClick.AddListener(ToggleBlocks);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (blockType == block)
            {
                if (blockCharges > 0)
                {
                    PlaceBlock();
                    blockCharges -= 1;
                    charges.GetComponentInChildren<Text>().text = blockCharges.ToString();
                }
            }
            else
            {
                if (knockblockCharges > 0)
                {
                    PlaceBlock();
                    knockblockCharges -= 1;
                    knockcharges.GetComponentInChildren<Text>().text = knockblockCharges.ToString();
                }
            }
        }
        if (Input.GetMouseButtonDown(2))
        {
            ToggleProjectiles();
        }

        if (blockCharges < 5 && charging == false)
        {
            StartCoroutine("RestoreCharges");
        }
        if (knockblockCharges < 3 && charging2 == false)
        {
            StartCoroutine("RestoreTrapCharges");
        }
    }

	void FixedUpdate() {
		float h = speed * Input.GetAxis("Mouse ScrollWheel");
		transform.Translate(h, 0, 0);

		if (Input.GetMouseButton (0) && Time.time > nextFire) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.layer != 5)
                {
                    Debug.Log(hit.collider.gameObject.layer);
                    nextFire = Time.time + fireRate;
                    Instantiate(CurrentShot, shotSpawn.position, shotSpawn.rotation);
                }
            }            
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

    void ToggleBlocks()
    {
        if (blockType == block)
        {
            charges.image.color = new Color(255, 255, 255);
            knockcharges.image.color = new Color(0, 176, 9);
            blockType = knockblock;
        }
        else
        {
            knockcharges.image.color = new Color(255, 255, 255);
            charges.image.color = new Color(0, 176, 9);
            blockType = block;
        }
    }

    void PlaceBlock() //to need make it so that blocks can't be placed overlapping
    {
            nextFire = Time.time + fireRate;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(blockType, hit.point, Quaternion.identity);
            }     
    }

    IEnumerator RestoreCharges()
    {
        charging = true;
        yield return new WaitForSeconds(5);
		blockCharges += 1;
        charges.GetComponentInChildren<Text>().text = blockCharges.ToString();
        charging = false;
    }

    IEnumerator RestoreTrapCharges()
    {
        charging2 = true;
        yield return new WaitForSeconds(5);
        knockblockCharges += 1;
        knockcharges.GetComponentInChildren<Text>().text = knockblockCharges.ToString();
        charging2 = false;
    }
}
