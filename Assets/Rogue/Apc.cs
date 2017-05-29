using UnityEngine;
using System.Collections;

public class Apc : InteractiveObj {
	public Door Door;
	//Вообще это просто для теста, так что на эту вещь можно забить
	


	void Update () {
		if(Input.GetKeyDown(KeyCode.G)){
			Door.SendMessage ("OnClick");
		}
	}
}

