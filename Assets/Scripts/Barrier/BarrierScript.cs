using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class BarrierScript : MonoBehaviour
	{
		//Health stuff
		Health h;
		//Sprite stuff
		public Sprite[] barrierStates;
		public int arrayIndexNum;
		//Sound stuff
		public AudioSource audioSource;
		public AudioClip[] barrierDamageFX;

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
			arrayIndexNum = (int) h.healthPoints;
			SpriteRenderer barrierSprite = this.gameObject.GetComponent<SpriteRenderer> ();
			if (h.healthPoints > 0)
			{
			barrierSprite.sprite = barrierStates[arrayIndexNum];
			}
			else
			{
			//First sprite = Explosion
			barrierSprite.sprite = barrierStates[0];
			}
			
			Debug.Log (h.healthPoints);

		}
	}
}