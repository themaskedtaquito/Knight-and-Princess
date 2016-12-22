using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private int timebank = 145;
    public Text timer;
    public GameObject timeUp;
    public GameObject knight;
    public GameObject princess;
	// Use this for initialization
	void Start () {

        InvokeRepeating("timeDown", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        if (timebank > 0)
        {
            if (timebank < 10)
            {
                timer.text = "0:0" + timebank;
            }
            else if (timebank < 60)
            {
                timer.text = "0:" + timebank;
            }
            else if (timebank < 70)
            {
                timer.text = "1:0" + (timebank-60);
            }
            else if (timebank < 120)
            {
                timer.text = "1:" + (timebank-60);
            }
            else if (timebank<130)
            {
                timer.text = "2:0" + (timebank - 120);
            }
            else
            {
                timer.text = "2:" + (timebank - 120);
            }
        }
        else
        {
            StartCoroutine("PrincessWin");
        }
	}

    void timeDown()
    {
        timebank -= 1;
    }

    IEnumerator PrincessWin()
    {
        knight.GetComponent<KnightControls>().enabled = false;
        princess.GetComponent<PrincessController>().enabled = false;
        timeUp.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("PrincessWin");
    }

    public IEnumerator KnightWin()
    {
        knight.GetComponent<KnightControls>().enabled = false;
        princess.GetComponent<PrincessController>().enabled = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("KnightWin");
    }
}
