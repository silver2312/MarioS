using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {
	public GameObject pauseUI;
	private bool pause = false;
	// Use this for initialization
	void Start () {
		pauseUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			pause = !pause;
		}
		if(pause)
		{
			pauseUI.SetActive(true);
			Time.timeScale = 0;
		}
		if(pause==false)
		{
			pauseUI.SetActive(false);
			Time.timeScale = 1;
		}
	}
	public void resume()
	{
		pause = false;
	}
	public void restrat()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void quit() {
		Application.Quit();
	}
}
