using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Spritechange : MonoBehaviour {

	//Всё что закомментированно уже не пригодится, наверное
	public Sprite[] DebugSprite= new Sprite[4]; 
	//public Sprite[] Clown= new Sprite[4]; 
	public Sprite[] Current = new Sprite[4];
	//public MenuManager MenuMan;
	public GameObject MenuObj;
	public int Skin; //Чисто дебаг, можно удалять
	//public Sprite[] Curr = new Sprite[4];

	//!!! Работа над спрайтами, которые рисуются над персонажем - маски!!!
	//! Для каждой маски приходится создавать новый игровой объект, ибо несклько SpriteRenderer'ов нельзя навесить на один объект !
	//Работа с поясом. У каждого пояса свои спрайты по направлениям. 
	public SpriteRenderer BeltRend;
	public SpriteRenderer GlassesRend;
	public Sprite[] BeltSprites = new Sprite[4];
	public Sprite[] GlassesSprite = new Sprite[4];




	void Start(){
		//Область инициализации и загрузки
		MenuObj = GameObject.FindGameObjectWithTag ("EditorOnly"); //Находим наш переносимый объект, на котором наш скрипт;
		//Если находим переносимый объект, то применяем
		if (MenuObj != null) { 
			Skin = MenuObj.GetComponent<MenuManager> ().Skin; //Чисто дебаг, можно под снос
			Current = MenuObj.GetComponent<MenuManager> ().CurrentSkin; //Применяем к массиву данные из массива перенесённого объекта, просто так менее затратнее, да и тот оъект можно будет удалить;
			print (Skin); //Чисто дэбаг, можно удалять
			Destroy(MenuObj);
		} else {
			Current = DebugSprite; //Ну а тут если не нашли
		}
		//Для масок
		BeltRend = this.transform.Find ("BeltLayer").GetComponent<SpriteRenderer> (); //Находим объект, на котором висит SpriteRenderer для пояса
		GlassesRend = this.transform.Find ("GlassesLayer").GetComponent<SpriteRenderer>();
	}

	void Update()  {
		//DontDestroyOnLoad (transform.gameObject);

		if (Input.GetKey (KeyCode.W)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = Current [0];
			BeltRend.sprite = BeltSprites [0];
			GlassesRend.sprite = GlassesSprite [0];
		}
		if (Input.GetKey (KeyCode.A)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = Current [1];
			BeltRend.sprite = BeltSprites [3];
			GlassesRend.sprite = GlassesSprite [3];
		}
		if (Input.GetKey (KeyCode.S)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = Current [2];
			BeltRend.sprite = BeltSprites [1];
			GlassesRend.sprite = GlassesSprite [1];
		}
		if (Input.GetKey (KeyCode.D)) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = Current [3];
			BeltRend.sprite = BeltSprites [2];
			GlassesRend.sprite = GlassesSprite [2];
		}
	}
}



