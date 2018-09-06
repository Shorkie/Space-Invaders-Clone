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
		[SerializeField] Sprite[] barrierStates;
		int arrayIndexNum;
		//Sound stuff
		[SerializeField] AudioClip[] barrierDamageFX;
		AudioSource audioSource;

		// Use this for initialization
		void Start ()
		{
			h = this.GetComponent<Health> ();
			audioSource = GetComponent<AudioSource>();
		}

		public void OnDamageTaken(float curHealthPoints, float prevHealthPoints, float DamageTaken)
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
			
			// Choose a random sound withing barrierDamageFX
			var ac = barrierDamageFX[Random.Range (0, barrierDamageFX.Length-1)];
			audioSource.clip = ac;
			audioSource.Play();
		}
	}
}