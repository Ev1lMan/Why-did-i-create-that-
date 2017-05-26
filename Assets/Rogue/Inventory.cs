using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	//Идея проста - каждый поднятый предмет хратится в отельной ячейке;
	//Также, отдельные ячейки будут помещать в себя только отдельно помеченные предметы. Как это сделать - хз, может что-то с as is;
	//Проблема в том, куда девать предмет - он должен пропасть с игрового поля, но не со сцены, ибо в таком случае он просто удаляется из игры и ссылки на него не будет :\
	//Префабами пользоваться не получится, ибо предмет толжен всегда сохранять свои параметры;
	//p.s. Иногда мне кажется, что на комментарии я трачу больше сил и времени, чем на кодинг :p
	//Должен ли этот класс наследовать класс игрока? А вообще его бы пихнуть в класс Actor, ибо у всех будет инвентарь, хотя отдельно удобнее.
	public GameObject slot0;
	//private GameObject currentobj;

	void Update(){
		
		RaycastHit2D rayhit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Vector2.zero), Input.mousePosition);
		if (rayhit.collider != null & Input.GetMouseButtonDown(0)) {
			if (rayhit.collider.gameObject.CompareTag ("Puckups")) {
				slot0 = rayhit.collider.gameObject;

				print ("Finally");
			} else {
				print ("Nope");
			}
		}

	}
}