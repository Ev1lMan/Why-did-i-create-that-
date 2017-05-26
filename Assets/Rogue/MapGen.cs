using UnityEngine;
using System.Collections;

public class MapGen : MonoBehaviour {
	public GameObject Road;


	// Use this for initialization
	void Start () {
		//Creting Juntion points
		for(int i = 1;i<=10;i++){
			Instantiate (Road, new Vector3 (Random.Range (0, 10), Random.Range (0, 10),0), Quaternion.identity);


		}

		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
