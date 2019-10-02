using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public int Health = 100;	
	public Player player;
	public float speed = 0.02f, changeDireCtion = -1;
	public Animator anim;
	Vector3 Move;
	public SoundManager sound;
	public pauseMenu pausep;
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		Move = this.transform.position;
		sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
		pausep = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<pauseMenu>();
	}
	void Update () {
		if (pausep.pause)
        {
            this.transform.position = this.transform.position;
 
        }if (pausep.pause == false)
        {
			Move.x += speed;		
			this.transform.position = Move;
			if(Health <= 0)
			{
				sound.Playsound("enemy_die");
				Destroy(gameObject);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col) {
		if(col.CompareTag("EMove"))
		{
			speed *= changeDireCtion;
			Vector3 Scale;
			Scale = transform.localScale;
			Scale.x *= -1;
			transform.localScale = Scale;
		}
	}
	void OnCollisionEnter2D(Collision2D col1) {
		if(col1.collider.CompareTag("Player"))
		{
			player.Damage(1);
			player.Knockback(400f, player.transform.position);
		}
	}	
	void Damage(int damage)	{
		sound.Playsound("ehu");
		Health -= damage;
	}
}
