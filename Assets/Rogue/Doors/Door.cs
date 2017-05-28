using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Я ТУТ ЕБАЛСЯ ЧАСА 2. ЕЩЁ ЕБУСЬ, КАК ГУСЬ БЛЯТЬ. ГДЕЕЕ МОООЯЯЯ МНОГА ПОТОЧНОСТЬ. СУКИИИ.
//Хотя всё правильно, любая вызванная функция должна дать выхлоп перед продолжением главного цикла.
//БЛЯТЬ, АААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААААА ЯЯЯЯЯ ХООЧУ КРАСИИИВООО ЕБОШИТЬ, НЕ ХОЧУ ЗАПИХИВАТЬ В КЛАВНЫЙ ЦЫЫЫЫКЛЛЛ СУУУКИИИИ
public class Door : MonoBehaviour {
	public GameObject DoorConsole; //Не важно блять
	public bool IsOpen;
	public int OpenSpeed; //Ну тут кароч кадыров в секунду ...................
	public Sprite[] DoorSq = new Sprite[10]; //Удобства не завезли
	private Sprite _currentSprite;
	IEnumerator OpenProc(){
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
	}
		
	// Use this for initialization
	void Start () {
		if (IsOpen) {
			_currentSprite = DoorSq [9];
		}else{
			_currentSprite = DoorSq [0];
		}
		this.GetComponent<SpriteRenderer> ().sprite = _currentSprite;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			StartCoroutine ("OpenProc");
		}
	}
	}
