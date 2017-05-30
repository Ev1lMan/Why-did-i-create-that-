﻿using UnityEngine;
using System.Collections;
public class Inventory : MonoBehaviour {
	//Идея проста - каждый поднятый предмет хратится в отельной ячейке;
	//Также, отдельные ячейки будут помещать в себя только отдельно помеченные предметы. Как это сделать - хз, может что-то с as is;
	//Проблема в том, куда девать предмет - он должен пропасть с игрового поля, но не со сцены, ибо в таком случае он просто удаляется из игры и ссылки на него не будет :\
	//Префабами пользоваться не получится, ибо предмет толжен всегда сохранять свои параметры;
	//p.s. Иногда мне кажется, что на комментарии я трачу больше сил и времени, чем на кодинг :p
	//Должен ли этот класс наследовать класс игрока? А вообще его бы пихнуть в класс Actor, ибо у всех будет инвентарь, хотя отдельно удобнее.
	//-----Слоты персонажа
	public GameObject LHand, RHand; //Это наверное вряд ли нужно, хотя всё можно сюда перенести;
	public GameObject Pocket1, Pocket2;
	public GameObject Center;
	public GameObject EarL, EarR;
	public GameObject Shoes, Gloves, Hat, Glasses, Belt;
	public Interface Interface;
	public Spritechange SpriteChange;
	public Player Player;
	public Sprite[] BeltSprites = new Sprite[4]; //Текущие спрайты для маски пояса

	private int SetPosPar(GameObject _item, GameObject _invSlot){
		_item.transform.SetPositionAndRotation (_invSlot.transform.position + Vector3.back, Quaternion.identity);
		_item.transform.SetParent (_invSlot.transform);
		return 1;
	}

	public int toInventory(GameObject _item, GameObject _invSlot){
		//Пояс
		if (_invSlot == Interface.BeltUI && _item.GetComponent<Belt>()) {
			BeltSprites = _item.GetComponent<Belt> ().ItemSprites; 
			SpriteChange.BeltSprites = BeltSprites; //Отправляем массив с текущими спрайтами для отрисовки в СпрайтЧейнджер
			//_item.transform.SetPositionAndRotation (Interface.BeltUI.transform.position +Vector3.back, Quaternion.identity); //Заметка - Все объекты, которые помещяются в слоты интвентаря перемещаются ближе к камере
			//_item.transform.SetParent (Interface.BeltUI.transform);
			SetPosPar(_item,_invSlot);
			Belt = _item;
			Player.ClearHand (Player.ActiveHand);
			}

		if (_invSlot == Interface.GlassesUI && _item.GetComponent<Glasses> ()) {
			SpriteChange.GlassesSprite = _item.GetComponent<Glasses> ().ItemSprites;
			//_item.transform.SetPositionAndRotation (Interface.GlassesUI.transform.position +Vector3.back, Quaternion.identity);
			//_item.transform.SetParent (Interface.GlassesUI.transform);
			SetPosPar(_item,_invSlot);
			Glasses = _item;
			Player.ClearHand (Player.ActiveHand);
		}
			



		return 1;
	}

	void Start(){
		Interface = this.GetComponent<Interface> ();
		Player = this.GetComponent<Player> ();
		SpriteChange = this.GetComponent<Spritechange> ();

	}
	void Update(){
	
	
	
	}

		



}
