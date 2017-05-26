using UnityEngine;
using System.Collections;

public class Player : Actor {
	public int MoveSpeed = 1;
	public int[] Actions = new int[10];

	// Use this for initialization
	void Start () {
		Description = "That's you, an asshole";
		}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			Move (2,MoveSpeed);
		}
		if (Input.GetKey (KeyCode.A)) {
			Move (4,MoveSpeed);
		}
		if (Input.GetKey (KeyCode.S)) {
			Move (8, MoveSpeed);

		}
		if (Input.GetKey (KeyCode.D)) {
			Move (6,MoveSpeed);
		}	

		//RaycastHit2D RayHit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);


	}
}