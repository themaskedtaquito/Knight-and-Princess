using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour {
    public Button play;
    public Button end;
	// Use this for initialization
	void Start () {
        play.onClick.AddListener(Restart);
        end.onClick.AddListener(Quit);
    }
	
	// Update is called once per frame
	void Restart()
    {
        SceneManager.LoadScene("MainGame");
    }

    void Quit()
    {
        Application.Quit();
    }
}
