using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour {
	//Класс интерфейса. Отвечает за отображение иконок слотов снаряжения
	//Я хз чо делать
	public GameObject HandLeftUI;
	public GameObject HandRightUI;
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
