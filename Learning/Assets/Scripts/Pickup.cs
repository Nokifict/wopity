using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	Animator anim;

	void Awake ()
	{
		anim = GetComponent <Animator> ();
		// Create a boolean that is true if either of the input axes is non-zero.
	}

	void pickingscore ()
	{
		bool pickingcoin = true;
		// Tell the animator whether or not the player is walking.
		if(pickingcoin == true)
		{
			anim.SetTrigger ("IsPickingCoin");
		}
	}

}
