using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{    
    public float speed=50f,maxspeed=3,jumpPow=220f, maxjump = 4;
    public Rigidbody2D r2;
    public bool grounded = true,faceright = true,doubleJump=false;
    public Animator anim;
    public int ourHeal;
    public int maxHeal = 5;
    public GameMaster gm;
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("gamecontrol").GetComponent<GameMaster>();
        ourHeal = maxHeal;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded",grounded);
        anim.SetFloat("Speed",Mathf.Abs(r2.velocity.x));
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(grounded)
            {
                grounded=false;
                doubleJump=true;
                r2.AddForce(Vector2.up*jumpPow);
            }
            else
            {
                if(doubleJump)
                {
                    doubleJump = false;
                    r2.velocity= new Vector2(r2.velocity.x,0);
                    r2.AddForce(Vector2.up*jumpPow*0.5f);
                }
            }
        }
    }

    void FixedUpdate()
    {
        float h =Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right)*speed*h);
        if(r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed,r2.velocity.y);
        if(r2.velocity.x <- maxspeed)
            r2.velocity = new Vector2(-maxspeed,r2.velocity.y);
        if(r2.velocity.y > maxjump)
            r2.velocity = new Vector2(r2.velocity.x,maxjump);
        if(r2.velocity.y <- maxjump)
            r2.velocity = new Vector2(r2.velocity.x,-maxjump);
        if(h>0 && !faceright)
        {
            Flip();
        }
        if(h<0 && faceright)
        {
            Flip();
        }
        if(grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x*0.7f,r2.velocity.y);
        }
        if(ourHeal <= 0)
        {
            Dead();
        }
    }
    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    public void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if(PlayerPrefs.GetInt("highcore") < gm.point)
            PlayerPrefs.SetInt("highcore", gm.point);
    }
    public void Damage(int dmg)
    {
        ourHeal -= dmg;
    }
    public void Knockback(float Knockpow, Vector2 Knockdir)
    {
        r2.velocity = Vector2.zero;
        r2.AddForce(new Vector2(Knockdir.x * -100, Knockdir.y * Knockpow));
    }
    void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("coins"))
        {
            Destroy(col.gameObject);
            gm.point += 100;
        }
    }
}