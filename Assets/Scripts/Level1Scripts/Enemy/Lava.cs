using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {
	public Player player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}	
	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Player"))
		{
			player.Damage(2);
			player.Knockback(350, player.transform.position);

		}
	}
}
