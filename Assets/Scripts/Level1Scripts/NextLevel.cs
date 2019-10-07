using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
	public int Levelload = 2;
	public GameMaster gm;
    public SoundManager sound;
	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("gamecontrol").GetComponent<GameMaster>();		
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Player"))
		{
			savescore();
			gm.inputtext.text = ("Press N to next level");
		}
	}
	private void OnTriggerStay2D(Collider2D col)
	{
		if(col.CompareTag("Player"))
		{
			if(Input.GetKey(KeyCode.N))
			{
				sound.Playsound("nlevel");
				savescore();
				gm.inputtext.text = ("Press N to next level");
				SceneManager.LoadScene(Levelload);
			}
		}
	}
	private void OnTriggerExit2D(Collider2D col)
	{
		if(col.CompareTag("Player"))
		{
			gm.inputtext.text = ("");
		}
	}
	void savescore()
	{
		PlayerPrefs.SetInt("point", gm.point);
	}
	
}
