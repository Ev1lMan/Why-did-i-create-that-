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
	public string ActiveHand;
	//А как руку переключить?
	public int SwitchHands(string hand){
		if (hand == "L") {
			ActiveHand = "R";
		}
		if (hand == "R") {
			ActiveHand = "L";
		}
		return 1;
	}

	void Start(){
		ActiveHand = "L";
		Debug.DrawRay (Camera.main.ScreenToWorldPoint (Vector2.zero), Input.mousePosition);
	}

	void Update(){


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
					if (LHand = RHand) {RHand = null;}

					LHand = rayhit.collider.gameObject;
					rayhit.collider.gameObject.transform.SetPositionAndRotation (lHandUI.transform.position + Vector3.back, Quaternion.identity); 					//Запихивает пистоль на интерфейс 
					
				}
				if (ActiveHand == "R") {
					if (RHand = LHand) {LHand = null;}

					RHand = rayhit.collider.gameObject;
					rayhit.collider.gameObject.transform.SetPositionAndRotation (rHandUI.transform.position + Vector3.back, Quaternion.identity);

				}



				print ("Finally");
			} 
		}

	}
}