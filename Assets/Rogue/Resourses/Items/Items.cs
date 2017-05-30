using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Items : MonoBehaviour {
	public Sprite[] ItemSprites = new Sprite[4]; //Отвечает за спрайты, которые будут отображаться над персонажем. В порядке: Вверх[0], Вниз[1], Вправо[2], Влево[3]

}
