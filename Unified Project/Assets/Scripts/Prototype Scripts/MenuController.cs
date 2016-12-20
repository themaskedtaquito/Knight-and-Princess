using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public Button start;
    public Button controls;
    public Button quit;
    public GameObject controls1;
    public GameObject controls2;
	// Use this for initialization
	void Start () {
        start.onClick.AddListener(StartGame);
        controls.onClick.AddListener(DisplayControls);
        quit.onClick.AddListener(Quit);
    }
	
	// Update is called once per frame
	void StartGame () {
        SceneManager.LoadScene("Narrative");
    }
    void Quit()
    {
        Application.Quit();
    }
    void DisplayControls()
    {
        controls1.SetActive(true);
        controls2.SetActive(true);
    }
}
