using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour {
public Sprite[] barrierStates;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	DamageBarrier();
	}

	void DamageBarrier() {
	int sprIndex = barrierStates.Length - 1;
	Debug.Log(sprIndex);
	SpriteRenderer barrierSprite = this.gameObject.GetComponent<SpriteRenderer>();
	barrierSprite.sprite = barrierStates[sprIndex];

	}
}
