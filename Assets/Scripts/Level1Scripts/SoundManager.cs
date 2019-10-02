using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioClip coin, sword, enemy_die, pdead, nlevel, walk, jump, ehu, pause;
	public AudioSource ads;
	// Use this for initialization
	void Start () {
		coin = Resources.Load<AudioClip>("mario_coin");
		sword = Resources.Load<AudioClip>("Sword");
		enemy_die = Resources.Load<AudioClip>("Enemy_die");
		pdead = Resources.Load<AudioClip>("mario_death");
		nlevel = Resources.Load<AudioClip>("mario_here_we_go");
		jump = Resources.Load<AudioClip>("mario_jump");
		ehu = Resources.Load<AudioClip>("mario_hurt");
		pause = Resources.Load<AudioClip>("mario_pause");
		ads = GetComponent<AudioSource>();
	}
	public void Playsound(string clip)
	{
		switch (clip)
		{
			case "coin":
				ads.clip = coin;
				ads.PlayOneShot(coin, 0.5f);
				break;
			case "sword":
				ads.clip = sword;
				ads.PlayOneShot(sword, 0.5f);
				break;
			case "enemy_die":
				ads.clip = enemy_die;
				ads.PlayOneShot(enemy_die, 0.5f);
				break;
			case "nlevel":
				ads.clip = nlevel;
				ads.PlayOneShot(nlevel, 0.8f);
				break;
			case "jump":
				ads.clip = jump;
				ads.PlayOneShot(jump, 0.7f);
				break;
			case "ehu":
				ads.clip = ehu;
				ads.PlayOneShot(ehu, 0.5f);
				break;
			case "pause":
				ads.clip = pause;
				ads.PlayOneShot(pause, 1);
				break;
		}
	}
}
