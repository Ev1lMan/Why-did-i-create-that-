using UnityEngine;
using System.Collections;

public class Player : Actor {
	public int MoveSpeed = 5;
	public Interface Interface;
	public Inventory Inventory;
	public string ActiveHand;
	public GameObject HandLeft;
	public GameObject HandRight;
	public GameObject _handInUse;
	//Стандартная процедура !!!кладения!!! предмета в руку. Пёс
	//Мне кажется, или стоит переписать этот бред с текстовой переменной для активной руки. Заменить её на геймобджект, наверное. Где-то внизу уже применянется данный способ. Надо будет попробовать
	public int ToHands (GameObject _item){
		if (ActiveHand == "L") {
			_item.transform.SetPositionAndRotation (Interface.HandLeftUI.transform.position + Vector3.back, Quaternion.identity);
			HandLeft = _item;
			_item.gameObject.transform.SetParent (Interface.HandLeftUI.transform); //Чтоб объект двигался вместе с UI
			if (HandLeft == HandRight) {
				HandRight = null;
			}
		}
		if (ActiveHand == "R") {
			_item.transform.SetPositionAndRotation (Interface.HandRightUI.transform.position + Vector3.back, Quaternion.identity);
			HandRight = _item;
			_item.gameObject.transform.SetParent (Interface.HandRightUI.transform);//UI
			if (HandLeft == HandRight) {
				HandLeft = null;

			}
		}
			return 1;
	}
	//DROP DAT SHIIT ON DA FLOOR YEAH
	public int DropFromHands(string _hand){
		if (_handInUse != null) {
			_handInUse.transform.SetPositionAndRotation (this.transform.position, Quaternion.identity);
			_handInUse.transform.parent = null;
			ClearHand (_hand);
		} else {
			print ("You have nothing to drop");
		}
		return 1;

		/*GameObject _hand; -----ПОД УДАЛЕНИЕ ---------
		if (ActiveHand == "L") {
			_hand = HandLeft;
			HandLeft = null;
		} else {
			_hand = HandRight;
			HandRight = null;
		}
		if (_hand == null) {
			print ("You have nothing to drop");
		} else {
			_hand.transform.SetPositionAndRotation (this.transform.position, Quaternion.identity);
			_hand.transform.parent = null; //Очищаем парент
		}*/

	}
	//Как руки-то переключить? ГДЕ КНОООПКАААААААААА????????
	public int SwitchHands(string hand){
		if (hand == "L") {
			ActiveHand = "R";
		}
		if (hand == "R") {
			ActiveHand = "L";
		}
		return 1;
	}
	//Очистка референсов в слотах рук. Так-то можно соеденить с DropFromHands, только учесть то, что эта функция нужна будет в чистом виде :) 
	public int ClearHand(string _hand){
		_handInUse = null;
		if (_hand == "L") {
			HandLeft = null;
		} else {
			HandRight = null;
		}
		return 1;
	}




	// Use this for initialization
	void Start () {
		Interface = this.GetComponent<Interface> (); //Пускай сам ищет блять, я чё блять, должен руками всё ставить блять? Да ахуеешь блять! А если блять чо там где, то вот хуй, понял?
		Inventory = this.GetComponent<Inventory> (); //ОПЯТЬ ЖЕ СУКА ИЩИ САМ БЛЯЯЯЯЯЯТЬ, Я НЕ ХОЧУ ЭТОГА ДЕЛАТЬ!
		ActiveHand = "L";
		Description = "That's you, an asshole";
		}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			Move (2,MoveSpeed);
		}
		if (Input.GetKey (KeyCode.A)) {
			Move (4,MoveSpeed);
		}
		if (Input.GetKey (KeyCode.S)) {
			Move (8, MoveSpeed);

		}
		if (Input.GetKey (KeyCode.D)) {
			Move (6,MoveSpeed);
		}	
		//Попробуем перенести всё дерьмо сюда
		if (Input.GetKeyDown (KeyCode.X)) {
			SwitchHands (ActiveHand);
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			DropFromHands (ActiveHand);
		}
		//Это пиздец некрасива. Или красива. Если некрасива - нада переделать. Если красива - нада использовать кое-где... где?
		if (ActiveHand == "L") {
			_handInUse = HandLeft;
		} else {
			_handInUse = HandRight;
		}

// Ну эт пиздец
//Тут, видимо, будет происходить (а наверное уже происходит) обработка кликом и выборка метода
//Блять, в юнити не самый скудный инструментарий, а всё вот так происходит, видимо из-за моего слабоумия (D) P.s. После армии я вообще перестану соображать :(
//Загляни в интерфейс, это тот ещё пиздец
//У всех объектов, которые могут быть использованны, будет функция OnClick(). Наверное так будет удобно(если нет, предложи свой вариант). Через эту функцию будет реализовыватся алгоритм работы этого объекта
//Фунция вызывается через SendMessage("имя функции - OnClick()")
		RaycastHit2D _rayhit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward, Mathf.Infinity);
		if (Input.GetMouseButtonDown (0) && _rayhit.collider != null) {
			//Проверяем есть ли что-нибудь в руке. Если нет, то преносим персонажу
			if (_handInUse == null) {
				if (_rayhit.collider.gameObject.CompareTag ("Pickups")) {
					if (_handInUse == null){
						if(_rayhit.collider.transform.parent == null){
							print("Clear to proceed");

						}else{
							print (_rayhit.collider.gameObject.transform.parent);
						}
						ToHands (_rayhit.collider.gameObject);



					} else {
						print ("No way");
					}

				
				
				}
			
			
			} else {
				//А тут если в руке что-то есть
				//Тут будет отправка данных о персонаже? и предмете, который был в руке. Дальше это будет обрабатываться предметом. Например: если использовать отвёртку на двери, то откручивается крышечка обслуживания
				print(_rayhit.collider + " " +_handInUse);
				/*if (_rayhit.collider.gameObject.CompareTag("Player")) {
					print ("You clicked on yourself with " + _handInUse);

				}*/
				//Обработка инвентаря. Если кликаем на интерфейс инвентаря, то отправляем всё на обработку в класс инвентаря
				if (_rayhit.collider.gameObject.CompareTag("UI")) {
					Inventory.toInventory (_handInUse, _rayhit.collider.gameObject);
				} 
			}
				



			if (_rayhit.collider.gameObject.CompareTag ("Door")) {
				print ("Door");
				_rayhit.collider.SendMessage ("OnClick");

			}
		} 

		if (Input.GetMouseButtonDown (1) && _rayhit.collider !=null) {
			print (_rayhit.collider);
			print (_rayhit.collider.gameObject.GetComponent(typeof(Wearable)));
			//Component Dbg = _rayhit.collider.gameObject.GetComponent(typeof(Belt)) as Items;
			//print (Dbg);
		}
	}
}