using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// Меню кароч, его пиздец можно улучшить, кастомные буттоны позже замучу
public class Menu : MonoBehaviour {

	bool isShowMenu,isShowMenuOptions,isShowMenuChoise;

	void Start () {
		isShowMenu = true;
		isShowMenuOptions = false;
		isShowMenuChoise = false;
	}
	void Update () {
	}
	void OnGUI() {
		if (isShowMenu) {
			GUILayout.BeginArea (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
			GUILayout.BeginVertical ();
			if (GUILayout.Button ("Начать игру", GUILayout.Height (50))) {
				isShowMenu = false;
				isShowMenuChoise = true;
			}
			GUILayout.FlexibleSpace ();
			if (GUILayout.Button ("Настройки", GUILayout.Height (50))) {
				isShowMenu = false;
				isShowMenuOptions = true;
			}
			GUILayout.FlexibleSpace ();
			if (GUILayout.Button ("Выход", GUILayout.Height (50))) {
				Application.Quit ();
			}
			GUILayout.EndVertical ();
			GUILayout.EndArea ();
		} else if (isShowMenuChoise) 
			{
				GUILayout.BeginArea(new Rect(Screen.width/2-50,Screen.height/2-50,200,200));
				GUILayout.BeginVertical();
			if(GUILayout.Button("Начать игру",GUILayout.Height (50)))
				{
					Application.LoadLevel(1);
				}

			}
		else if(isShowMenuOptions)
		{
			GUILayout.BeginArea(new Rect(Screen.width/2-50,Screen.height/2-50,200,200));
			GUILayout.BeginVertical();
			if(GUILayout.Button("Меню",GUILayout.Width(80),GUILayout.Height(50)))
			{
				isShowMenuOptions = false;
				isShowMenu = true;
			}

		}
	}

}
	