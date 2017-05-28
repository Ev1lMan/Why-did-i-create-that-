using UnityEngine;
using System.Collections;
public class Inventory : MonoBehaviour {
	//Идея проста - каждый поднятый предмет хратится в отельной ячейке;
	//Также, отдельные ячейки будут помещать в себя только отдельно помеченные предметы. Как это сделать - хз, может что-то с as is;
	//Проблема в том, куда девать предмет - он должен пропасть с игрового поля, но не со сцены, ибо в таком случае он просто удаляется из игры и ссылки на него не будет :\
	//Префабами пользоваться не получится, ибо предмет толжен всегда сохранять свои параметры;
	//p.s. Иногда мне кажется, что на комментарии я трачу больше сил и времени, чем на кодинг :p
	//Должен ли этот класс наследовать класс игрока? А вообще его бы пихнуть в класс Actor, ибо у всех будет инвентарь, хотя отдельно удобнее.
	//-----Слоты персонажа
	public GameObject LHand;
	public GameObject lHandUI;
	public GameObject RHand;
	public GameObject rHandUI;
	public GameObject Center;
	public GameObject CenterUI;
	public Sprite[] HandsSprites = new Sprite[4]; //В таком порядке - Inactive - left[0] : right[1] || Active - left[2] : right[3]
	public string ActiveHand;
	//А как руку переключить? !!!НАДО ПЕРЕДЕЛАТЬ!!! Стоило бы сделать аккуратнее
	public int SwitchHands(string hand){
		if (hand == "L") {
			ActiveHand = "R";
			rHandUI.GetComponent<SpriteRenderer> ().sprite = HandsSprites [3];
			lHandUI.GetComponent<SpriteRenderer> ().sprite = HandsSprites [0];
		}
		if (hand == "R") {
			ActiveHand = "L";
			rHandUI.GetComponent<SpriteRenderer> ().sprite = HandsSprites [1];
			lHandUI.GetComponent<SpriteRenderer> ().sprite = HandsSprites [2];
		}
		return 1;
	}
	public int DropDatShit(GameObject _hand){
		if (_hand != null) {
			_hand.transform.SetPositionAndRotation (FindObjectOfType<Player> ().transform.position, Quaternion.identity);
			//_hand = null;
		} else {
			print ("You have nothing to drop");
		}
		return 1;
	}

	void Start(){
		ActiveHand = "L";
		lHandUI.GetComponent<SpriteRenderer> ().sprite = HandsSprites [2];
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Q)) {
			if (ActiveHand == "L") {
				DropDatShit (LHand);
				LHand = null;
			} else {
				DropDatShit (RHand);
				RHand = null;
			}
		}


		if (Input.GetKeyDown (KeyCode.X)) { //Тут мы просто меняем руки
			SwitchHands (ActiveHand);
			print ("You changed your active hand to " + ActiveHand);
		}

		// Создаём переменную rayhit, в которой хранится вся информация про объект,
		//который попал под луч рэйкаста
		RaycastHit2D rayhit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward, Mathf.Infinity); 
		if (rayhit.collider != null & Input.GetMouseButtonDown(0)) { 										//Тут делаем проверку rayhit на присутствие объекта в касте
			print ("You clicked on " + rayhit.collider.gameObject);
			if (rayhit.collider.gameObject.CompareTag ("Pickups")) { 										//Все предметы, которые можно поднять будут помечены тэгом "Pickups"
				//Проверка выбранной руки. Какую выбрали, такая и будет
				if (ActiveHand == "L") { 																	
					if (LHand == RHand) {RHand = null;}

					LHand = rayhit.collider.gameObject;
					rayhit.collider.gameObject.transform.SetPositionAndRotation (lHandUI.transform.position + Vector3.back, Quaternion.identity); 					//Запихивает пистоль на интерфейс 
					
				}
				if (ActiveHand == "R") {
					if (RHand == LHand) {LHand = null;}

					RHand = rayhit.collider.gameObject;
					rayhit.collider.gameObject.transform.SetPositionAndRotation (rHandUI.transform.position + Vector3.back, Quaternion.identity);

				}
			} 
			if(rayhit.collider.gameObject.CompareTag("UI")){
				if (ActiveHand == "R") {
					Center = RHand;
					RHand.gameObject.transform.SetPositionAndRotation (CenterUI.transform.position + Vector3.back, Quaternion.identity);
					RHand = null;
				}

			}

		}
	}
}
