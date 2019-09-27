using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healUI : MonoBehaviour {
	public Sprite[] Healsprite;
	public Player player;
	public Image heartUI;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		heartUI.sprite = Healsprite[player.ourHeal];
	}
}
