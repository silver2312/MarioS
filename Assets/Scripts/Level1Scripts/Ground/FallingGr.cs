using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGr : MonoBehaviour {
	public Rigidbody2D g2;
	public float timedelay = 0.5f;
	// Use this for initialization
	void Start () {
		g2 = gameObject.GetComponent<Rigidbody2D>();
	}
	
	private void OnCollisionEnter2D(Collision2D col) {
		if(col.collider.CompareTag("Player"))
		{
			StartCoroutine(fall());
		}
	}
	IEnumerator fall()
	{
		yield return new WaitForSeconds(timedelay);
		g2.bodyType = RigidbodyType2D.Dynamic;
		yield return 0;
	}
}
