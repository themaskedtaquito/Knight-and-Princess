using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("Begin");
	}
	
	// Update is called once per frame
	IEnumerator Begin()
    {
        yield return new WaitForSeconds(12);
        SceneManager.LoadScene("MainGame");
    }
}
