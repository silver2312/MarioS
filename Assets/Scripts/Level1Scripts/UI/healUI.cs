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
		if (player.ourHeal > 5)
            player.ourHeal = 5; 
        if (player.ourHeal < 0)
            player.ourHeal = 0;
		heartUI.sprite = Healsprite[player.ourHeal];
	}
}
