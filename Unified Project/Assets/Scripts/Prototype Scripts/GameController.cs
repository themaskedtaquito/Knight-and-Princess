using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private int timebank = 150;
    public Text timer;
    public GameObject timeUp;
    public GameObject knight;
	// Use this for initialization
	void Start () {

        InvokeRepeating("timeDown", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        if (timebank > 0)
        {
            timer.text = timebank + " seconds remaining";
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
        timeUp.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("PrincessWin");
    }

    public void KnightWin()
    {
        SceneManager.LoadScene("KnightWin");
    }
}
