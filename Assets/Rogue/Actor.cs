using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

	public AudioClip[] StepSound = new AudioClip[10];
	public bool stepping = false;
	public float WaitTime;
	public string Description; //Ну тут кароч чо - опять ооп, каждый будет генерировать своё описание и позже записывать это значение для своего класса
	public int Move(int Dir, int Speed){	//Движения, ЭТА ЖИ БЛЯТЬ ООП, ДРУГИМ МОБАМ ВПИСЫВАТЬ ЭТО НЕ НАДО УЖЕЕЕЕЕ ЕЕЕЕЕЕААААА

		WaitTime = 0.2f;
		Update();
			this.GetComponent<Rigidbody2D> ().freezeRotation = true;
			if (Dir == 2) {
				//this.transform.Translate (Vector2.up * Speed * Time.deltaTime);
				this.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 10);
			}
			if (Dir == 4) {
				//this.transform.Translate (Vector2.left * Speed * Time.deltaTime);
				this.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 10);
			}
			if (Dir == 6) {
				//this.transform.Translate (Vector2.right * Speed * Time.deltaTime);
				this.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 10);
			}
			if (Dir == 8) {
				//this.transform.Translate (Vector2.down * Speed * Time.deltaTime);
				this.GetComponent<Rigidbody2D> ().AddForce (Vector2.down * 10);
			}
		return 1;
	}


	IEnumerator footfall() //ХУЙНЯ С ЕЛДАКОМ БЛЯТЬ
	{
			stepping = true;
		this.GetComponent<AudioSource>().PlayOneShot (StepSound[Random.Range(0,StepSound.Length)]);
			yield return new WaitForSeconds (WaitTime);
			stepping = false;
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
		if (!stepping) {
			StartCoroutine (footfall ());
		}
	}


}

