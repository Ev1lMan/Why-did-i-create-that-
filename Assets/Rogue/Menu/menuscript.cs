using UnityEngine;

public class MenuScript : MonoBehaviour {

	void OnGUI()
	{
		const int ButtonWight = 160;
		const int ButtonHeight = 50;

		Rect buttonRect = new Rect (
			                  Screen.width / 2 - (ButtonWight / 2),
			                  Screen.height / 3 - (ButtonHeight / 2),
			                  ButtonWight,
			                  ButtonHeight
		                  );
		if(GUI.Button(buttonRect,"Начать игру"))
		{
			Application.LoadLevel("1");
		}
	}
		
}	
