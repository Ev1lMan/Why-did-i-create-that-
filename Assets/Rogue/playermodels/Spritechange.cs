using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spritechange : MonoBehaviour {

	public Sprite[] Clown= new Sprite[4]; 

	void Update()  {
		if (Input.GetKey (KeyCode.W)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = Clown [0];
		}
		if (Input.GetKey (KeyCode.A)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = Clown [3];
		}
		if (Input.GetKey (KeyCode.S)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = Clown [2];
		}
		if (Input.GetKey (KeyCode.D)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = Clown [1];
		}
	}
}