using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour {
	//Класс интерфейса. Отвечает за отображение иконок слотов снаряжения
	//БЛЯТЬ, ЮНИТИ ДАЁТ НОРМАЛЬНЫЙ GUI, С ОБРАБОТЧИКОМ СОБЫТИЙ И ПРОЧЕЙ ХУЕТОЙ, НЕТ БЛЯТЬ, НЕ ХОЧУ, ХОЧУ ГАВНО ЖРАТЬ
	//Хотя мне так удобнее, либо просто так легче, либо я не разобрался с нормальный GUI, либо, что кстати вытекает из предыдущего пункта, моё слабоумие (D)
	public GameObject HandLeftUI,HandRightUI;
	public GameObject BeltUI;
	public Sprite[] HandsIcons = new Sprite[4]; //Inactive: left[0] right[1] || Active: left[2] right[3]
	public Player Player;

	void Start(){
		Player = this.GetComponent<Player> ();
	}

	void Update(){
		if (Player.ActiveHand == "L") {
			HandLeftUI.GetComponent<SpriteRenderer> ().sprite = HandsIcons [2]; //Левая рука активна
			HandRightUI.GetComponent<SpriteRenderer> ().sprite = HandsIcons [1];
		}else{
			HandLeftUI.GetComponent<SpriteRenderer> ().sprite = HandsIcons [0]; 
			HandRightUI.GetComponent<SpriteRenderer> ().sprite = HandsIcons [3]; //Правая рука активна
		}

	}
}
