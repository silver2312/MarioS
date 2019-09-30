using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {
	public int point = 0;
	public int highscore = 0;
	public Text pointtext;
	public Text highscoretext;
	public Text inputtext;
	// Use this for initialization
	void Start () {
		highscoretext.text = ("HighScore: "+ PlayerPrefs.GetInt("highscore"));
		highscore = PlayerPrefs.GetInt("highcore", 0);
		if(PlayerPrefs.HasKey("point"))
		{
			Scene ActiveScreen = SceneManager.GetActiveScene();
			if(ActiveScreen.buildIndex == 0)
			{
				PlayerPrefs.DeleteKey("point");
				point = 0;
			}else
			{
				point = PlayerPrefs.GetInt("point");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		pointtext.text = ("Points: " + point);
	}
}
