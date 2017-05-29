using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Я ТУТ ЕБАЛСЯ ЧАСА 2. ЕЩЁ ЕБУСЬ, КАК ГУСЬ БЛЯТЬ. ГДЕЕЕ МОООЯЯЯ МНОГА ПОТОЧНОСТЬ. СУКИИИ.
//Хотя всё правильно, любая вызванная функция должна дать выхлоп перед продолжением главного цикла.
//БЛЯТЬ, АААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААА ЯЯЯЯЯ ХООЧУ КРАСИИИВООО ЕБОШИТЬ, НЕ ХОЧУ ЗАПИХИВАТЬ В КЛАВНЫЙ ЦЫЫЫЫКЛЛЛ СУУУКИИИИ
//Новая технология поъехала - корутина, но я как-то не оч. СУКА ЗАЕБАЛСЯ Я
public class Door : MonoBehaviour {
	//Разобраться с этим месивом
	public AudioClip OpenSound;// Хуйня со звуком
	public GameObject DoorConsole; //Не важно блять
	public bool IsOpen;
	public bool toOpen;
	public int OpenSpeed; //Ну тут кароч кадров в секунду ...................
	public Sprite[] DoorSq = new Sprite[10]; //Удобства не завезли
	private Sprite _currentSprite;
	public bool toClose;
	private float _time;
	private int _curr;
	public BoxCollider2D[] DoorColl = new BoxCollider2D[3]; //Коллайдер двери, иначе не пройдёшь, но если убрать коллайдер, то нельзя будет кликнуть;
	public bool OnClick()
	{
		GetComponent<AudioSource>().PlayOneShot (OpenSound); // для проигрования хурмы(звука)
		if (IsOpen) {
			toClose = true;
			toOpen = false;
		} else {
			toClose = false;
			toOpen = true;
		}
		return true;
	}
/*	IEnumerator OpenProc(){
		print ("haha");
		bool _done = false;
		float _time = 0;
		int _curr = 3;
		//print ("Initial " + _time);
		while(!_done){
			_time += Time.deltaTime;
			//print (_time);
			if (_time >= 0.5) {
				this.GetComponent<SpriteRenderer> ().sprite = DoorSq [_curr];
				//print ("Got " + _time + " | " + _curr);
				_curr += 1;
				_time = 0;
			}
			if (_curr >= 8) {
				_done = true;
				//print ("Done");

			}
		}
		yield return null;
	}*/
		
	// Use this for initialization
	void Start () {
		DoorColl = this.GetComponents<BoxCollider2D> ();
		_time = 0;
		_curr = 3;
		toOpen = false;
		IsOpen = false;
		toClose = false;
		if (IsOpen) {
			_currentSprite = DoorSq [9];
			DoorColl [0].enabled = false;
			DoorColl [1].enabled = true;
			DoorColl [2].enabled = true;
		}else{
			_currentSprite = DoorSq [0];
			DoorColl [0].enabled = true;
			DoorColl [1].enabled = false;
			DoorColl [2].enabled = false;

		}
		this.GetComponent<SpriteRenderer> ().sprite = _currentSprite;
	}

	// Update is called once per frame
	void Update (){
		//ГОООООСПАААДЕЕЕЕ, КАКАЯ УБОГАЯ РЕАЛИЦАЗИЦАЯ, ПОЖАЛУЙСТА, ПЕРЕПИШИТЕ ЭТО КТО-НИБУДЬ В НОРМАЛЬНУЮ ФОРМУ, ЧТОБ ЭТО БЫЛА ФУНКЦИЯ, А НЕ ХУЙНЯ БЛЯТЬ
		//bool _done;
		//float _time;
		//int _curr;
		//ЛУЧШЕ НЕ СМОТРЕТЬ СЮДА, ЭТО ПРОСТО ЕБАНЫЙ ПОЗОР БЛЯТЬ! А ЧТО Я МОГУ СДЕЛАТЬ? Я БЛЯТЬ НЕ МОГУ С КОРУТИНАМИ РАЗОБРАТЬСЯ, ХОТЬ БЛЯТЬ ОТДЕЛЬНЫЙ ПОТОК ЗАПУСКАЙ СУКА
		//-----Открытие двери------//
		if(toOpen && !IsOpen){
			_time += Time.deltaTime;
			this.GetComponent<SpriteRenderer> ().sprite = DoorSq[_curr];
			if (_time >= 0.2f) {
				_curr += 1;
				_time = 0;
			}
			if (_curr >= 9) {
				toOpen = false;
				IsOpen = true;
				_curr = 9;
				_time = 0;
				DoorColl [0].enabled = false;
				DoorColl [1].enabled = true;
				DoorColl [2].enabled = true;
			}
		}
		//--------Закрытие двери---------//
		if (toClose && IsOpen) {
			_time += Time.deltaTime;
			this.GetComponent<SpriteRenderer> ().sprite = DoorSq [_curr];
			if (_time >= 0.2f) {
				_curr -= 1;
				_time = 0;
			}
			if (_curr <= -1) {
				toClose = false;
				IsOpen = false;
				_curr = 3;
				_time = 0;
				DoorColl [0].enabled = true;
				DoorColl [1].enabled = false;
				DoorColl [2].enabled = false;
			}

		}
	}
}