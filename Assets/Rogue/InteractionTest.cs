using UnityEngine;
using System.Collections;

public class InteractionTest : MonoBehaviour {
	public int CallMove (float X, float MouseY){
		float Y = Screen.height - MouseY;
		GUI.TextArea (Rect.MinMaxRect (X, Y,X+100,Y+50), "GoodJobe");
		return 1;
	}




	void OnGUI(){
	}

}

