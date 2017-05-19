using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HearthBar : MonoBehaviour {

	public int currentHealth;
	public Sprite fullHeart;
	public Sprite emptyHeart;
	public GameObject heartObject;
	public int maxHealth;

	private bool didChange = false;
	private ArrayList hearts = new ArrayList();
	// Use this for initialization
	void Start () {

		for(int i = 0 ; i!=maxHealth ; i++){
			GameObject anHeart = Instantiate (heartObject);
			anHeart.transform.parent = gameObject.transform;
			anHeart.transform.localPosition = new Vector3 (i * 75, 0, 0); 
			hearts.Add (anHeart);
		}
		didChange = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (didChange) {
			didChange = false;
			Transform aTransform = this.gameObject.transform;
			for (int i = 0; i != aTransform.childCount; i++) {
				Transform aHeart = this.gameObject.transform.GetChild (i);
				aHeart.GetComponent<Image> ().sprite = i <= currentHealth ? fullHeart : emptyHeart;
			}
		}
	}


	public void modifyHealth(int quantity){
		currentHealth += quantity;
		currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
		didChange = true;
	}
}
