using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class BarrierScript : MonoBehaviour
	{
		Health h;
		public Sprite[] barrierStates;
		public int arrayIndexNum;
		// Use this for initialization
		void Start ()
		{
			h = this.GetComponent<Health> ();

		}

		// Update is called once per frame
		void Update ()
		{
			DamageBarrier ();
		}

		void DamageBarrier ()
		{
			arrayIndexNum = (int)h.healthPoints;
			SpriteRenderer barrierSprite = this.gameObject.GetComponent<SpriteRenderer> ();
			barrierSprite.sprite = barrierStates[arrayIndexNum];
			Debug.Log(h.healthPoints);

		}
	}
}