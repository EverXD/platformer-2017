using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour 
{
 public float maxSpeed = 3;
 public float speed = 50f;
 public float jumpPower = 10f;
 private bool secondJumpAvail = true;
 public bool grounded;

 private Rigidbody2D rb2d;

  void Start () 
  {
   rb2d = gameObject.GetComponent<Rigidbody2D>();
  }

  void Update () 
  {
  	if(Input.GetKeyDown(KeyCode.Space))
  	{
  		if(grounded == true)
  		{
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce(Vector2.up * jumpPower);
  			grounded = false;
  		}
  		else if(secondJumpAvail == true)
  		{
  			rb2d.velocity = Vector2.zero;
			rb2d.AddForce(Vector2.up * jumpPower);
  			secondJumpAvail = false;	
  		}
  	}

 }
   void FixedUpdate()
  { // få spelaren att röra sig

   if(Input.GetKey(KeyCode.A) == false)
   {
   rb2d.velocity = new Vector2 (maxSpeed * 0, rb2d.velocity.y);
   }

		if(Input.GetKey(KeyCode.D) == false)
   {
   rb2d.velocity = new Vector2 (maxSpeed * 0, rb2d.velocity.y);
   }

   float h = Input.GetAxis("Horizontal");

   rb2d.AddForce((Vector2.right * speed) * h);
    // Sätt en maxspeed 
   if(rb2d.velocity.x > maxSpeed)
   {
    rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
   }
   if(rb2d.velocity.x < -maxSpeed)
   {
    rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
   }
  }
  void OnCollisionEnter2D(Collision2D coll)
  {
  	if(coll.gameObject.tag == "Ground")
  	{
  		grounded = true;
		secondJumpAvail = true;
  	}
	if(coll.gameObject.tag == "Destroy")
	{
		Destroy(gameObject);
	}
  }

  }