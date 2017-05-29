using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
	public int Skin = 0; //Чисто дебаг, можно убирать
	public Sprite[] CurrentSkin = new Sprite[4]; //Этот массив задаётся в меню


	void Awake(){
		DontDestroyOnLoad (this);
	}
}
