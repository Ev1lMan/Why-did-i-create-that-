using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spritechange : MonoBehaviour 
{
	public Sprite[] sprites = new Sprite[4];

	void Change()
	{
		if (Input.GetKey (KeyCode.W)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = sprites [0];
		}
		if (Input.GetKey (KeyCode.A)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = sprites [1];
		}
		if (Input.GetKey (KeyCode.S)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = sprites [2];
		}
		if (Input.GetKey (KeyCode.D)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = sprites [3];
		}
	}
}