using UnityEngine;
using System.Collections;

public class Enemy : Actor {

	// Use this for initialization
	void Start () {
		Description = "That's your enemy, a great guy";
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Move (2,10);
		}
	
	}
}
