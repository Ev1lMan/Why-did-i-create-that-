using UnityEngine;
using System.Collections;

public class Player : Actor {
	public int MoveSpeed = 5;
	public Interface Interface;
	public Inventory Inventory;
	public string ActiveHand;
	public GameObject HandLeft;
	public GameObject HandRight;
	private GameObject _handInUse;
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
	public int DropFromHands(){
		GameObject _hand;
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
		}
		return 1;
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
			DropFromHands ();
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
			if (_rayhit.collider.gameObject.CompareTag ("Pickups")) {
				if (_handInUse == null) {
					ToHands (_rayhit.collider.gameObject);
				} else {
					print ("No way");
				}	
			}
			if (_rayhit.collider.gameObject.CompareTag ("Door")) {
				print ("Door");
				_rayhit.collider.SendMessage ("OnClick");

			}
		} 
	}
}