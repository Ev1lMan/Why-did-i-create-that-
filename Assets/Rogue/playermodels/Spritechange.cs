using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spritechange : MonoBehaviour 
{
	public Sprite Clown= new Sprite[3]
	void Change1()
	{
		if (Input.GetKey (KeyCode.W)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("clown_up");
		}
		if (Input.GetKey (KeyCode.A)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("clown_left");
		}
		if (Input.GetKey (KeyCode.S)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("clown_down");
		}
		if (Input.GetKey (KeyCode.D)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("clown_right");
		}
	}
}