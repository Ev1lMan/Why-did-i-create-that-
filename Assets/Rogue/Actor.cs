using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {
	public string Description; //Ну тут кароч чо - опять ооп, каждый будет генерировать своё описание и позже записывать это значение для своего класса
	public int Move(int Dir, int Speed){	//Движения, ЭТА ЖИ БЛЯТЬ ООП, ДРУГИМ МОБАМ ВПИСЫВАТЬ ЭТО НЕ НАДО УЖЕЕЕЕЕ ЕЕЕЕЕЕААААА
		if (Dir == 2) {
			this.transform.Translate (Vector2.up * Speed * Time.deltaTime);
		}
		if (Dir == 4) {
			this.transform.Translate (Vector2.left * Speed * Time.deltaTime);
		}
		if (Dir == 6) {
			this.transform.Translate (Vector2.right * Speed * Time.deltaTime);
		}
		if (Dir == 8) {
			this.transform.Translate (Vector2.down * Speed * Time.deltaTime);
		}
		return 1;
	}

	public int ShowDesc(){
		Debug.Log(Description);
		return 1;
	}
		// Use this for initialization
	void Start () {
		Description = "You got this wrong way";
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}

