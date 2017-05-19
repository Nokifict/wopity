using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_controller : MonoBehaviour {

	public float speed;
	public int points;
	public Text countText;
	public Text wintext;
	public Text pickup_points;

	private Rigidbody rb;
	private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		wintext.text = "";
		pickup_points.text = "";
		//anim = GetComponents <Animator> ();

	}


	// Cette fonction s'éxécute toujours en premier ( éléments prioritaires à éxécuter)
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float movevertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, movevertical);

		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);

			count = count + points;
			SetCountText ();
		}

	}

	void SetCountText ()
	{ 
		countText.text = "Score : " + count.ToString () + " pts";
		pickup_points.text = "+ " + points;

		if (count >= 100) 
		{
			wintext.text = "VICTORY!";
		}
	}
}