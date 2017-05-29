using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
// Меню кароч, его пиздец можно улучшить, кастомные буттоны позже замучу
public class Menu : MonoBehaviour {
	//Сюда загружаются спрайты. Лучше будет вынести в отдельный файл с удобной структурой, там же можно и с файловой системой попробовать взаимодействие
	public Sprite[] Humanm= new Sprite[4];
	public Sprite[] Clown= new Sprite[4]; 
	bool isShowMenu,isShowMenuOptions,isShowMenuChoise;
	public MenuManager MenuMan; //Отельный скрипт, который будет переносить данные в игровую сцену

	void Start () {
		MenuMan.Skin = 0;
		isShowMenu = true;
		isShowMenuOptions = false;
		isShowMenuChoise = false;
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
			if (GUILayout.Button ("Выбрать клоуна", GUILayout.Height (50))) {

				MenuMan.Skin = 1;
				MenuMan.CurrentSkin = Clown; //В том скрипте есть массив, который позже применяется к игроку
				
			} else if (GUILayout.Button ("Выбрать Человека", GUILayout.Height (50))) {
				MenuMan.Skin = 2;
				MenuMan.CurrentSkin = Humanm;
			}

			if(GUILayout.Button("Начать игру",GUILayout.Height (50)))
				{
					SceneManager.LoadScene(1);
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
	