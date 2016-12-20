using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour {
    public Button play;
	// Use this for initialization
	void Start () {
        play.onClick.AddListener(Restart);
    }
	
	// Update is called once per frame
	void Restart()
    {
        SceneManager.LoadScene("MainGame");
    }
}
