using UnityEngine;
using System.Collections;

public class Apc : InteractiveObj {
	public GameObject Lamp;
	// Use this for initialization
	void Start () {
		Description = "This is what it is, Area power control1l d:";
	}
	
	// Update is called once per frame
	void Update () {
		if (Enabled) {
			Lamp.SetActive (true);
		} else {
			Lamp.SetActive (false);
		}
	
	}
}


