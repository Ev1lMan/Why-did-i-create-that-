using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Я ТУТ ЕБАЛСЯ ЧАСА 2. ЕЩЁ ЕБУСЬ, КАК ГУСЬ БЛЯТЬ. ГДЕЕЕ МОООЯЯЯ МНОГА ПОТОЧНОСТЬ. СУКИИИ.
//Хотя всё правильно, любая вызванная функция должна дать выхлоп перед продолжением главного цикла.
//БЛЯТЬ, АААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААА ЯЯЯЯЯ ХООЧУ КРАСИИИВООО ЕБОШИТЬ, НЕ ХОЧУ ЗАПИХИВАТЬ В КЛАВНЫЙ ЦЫЫЫЫКЛЛЛ СУУУКИИИИ
//Новая технология поъехала - корутина, но я как-то не оч. СУКА ЗАЕБАЛСЯ Я
public class Door : MonoBehaviour {
	//Разобраться с этим месивом
	public GameObject DoorConsole; //Не важно блять
	public bool IsOpen;
	public bool toOpen;
	public int OpenSpeed; //Ну тут кароч кадров в секунду ...................
	public Sprite[] DoorSq = new Sprite[10]; //Удобства не завезли
	private Sprite _currentSprite;
	private float _time;
	private int _curr;
	public bool OpenDoor(bool _wat){
		if (_wat) {
			toOpen = true;
			return true;
		} else {
			return false;
			toOpen = false;
		}
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
		OpenDoor (false);
		_time = 0;
		_curr = 3;
		toOpen = false;
		if (IsOpen) {
			_currentSprite = DoorSq [9];
		}else{
			_currentSprite = DoorSq [0];
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
		if(toOpen){
			_time += Time.deltaTime;
			//_curr = 3;
			this.GetComponent<SpriteRenderer> ().sprite = DoorSq[_curr];
			if (_time >= 0.2f) {
				_curr += 1;
				_time = 0;
			}
			if (_curr >= 9) {
				toOpen = false;
				IsOpen = true;
			}







		}
	}
}