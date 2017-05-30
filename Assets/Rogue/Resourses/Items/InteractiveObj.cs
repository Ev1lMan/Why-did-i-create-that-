using UnityEngine;
using System.Collections;

public class InteractiveObj : MonoBehaviour {
	public string Description;
	public bool Enabled = false;
	public int Use(){
		if (!Enabled) {
			Enabled = true;
			} else {
			Enabled = false;
			}
		return 1;
		}
	public int ShowDesc(){
		print (Description);
		return 1;
	}

	//Все наследники будут откликаться на это. Удобно. Прикинь. Да да, ооп.
	void OnMouseOver(){
		if(Input.GetMouseButtonDown(1)){
			ShowDesc ();
		}
		if (Input.GetMouseButtonDown (0)) {
			Use ();
		}
			

	}
}
