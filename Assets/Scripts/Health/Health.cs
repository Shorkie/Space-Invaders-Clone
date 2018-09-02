using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Name
{
	public class Health : MonoBehaviour
	{
		[SerializeField] float _maxHealth = 10;
		public float maxHealth { get { return _maxHealth; } protected set { _maxHealth = value; } }

		public float healthPoints { get; protected set; }

		//Destroy game object timer
    	public float destroyIn;
    	public float destroyCountdown;

		// [System.Serializable]
		// public class UnityEventFloat : UnityEvent<float> {}

		// public UnityEventFloat onDamageTaken;
		// public UnityEvent onDeath;

		void Awake ()
		{
			healthPoints = _maxHealth;
		}

		void Start()
		{
			//Setting the timer
			destroyCountdown = destroyIn;
		}

		void Update()
		{
			//Countdown on
			if (healthPoints <= 0)
			{
			//Disabling collider
			this.gameObject.GetComponent<Collider2D>().enabled = false;
			//Countdown 
			destroyCountdown -= Time.deltaTime;
			//Destroy it
			if (destroyCountdown < 0f)
			{
				DestroyGameObject();
			}
			}
		}

		public void TakeDamage (float value)
		{
			if (value < 0)
			{
				return;
			}

			healthPoints -= value;

			// if ( onDamageTaken != null )
			// 	onDamageTaken.Invoke(healthPoints);

			if (healthPoints <= 0)
			{
				Die ();
			}
		}

		void Die ()
		{
			// TODO: Spawn effects

			// if ( onDeath != null )
			// 	onDeath.Invoke();
			//Barrier death effect
			if (this.gameObject.tag == "barrier")
			{
				Debug.Log("Destroyed barrier");
				//Barrier destruction
				AudioSource b = this.gameObject.GetComponent<AudioSource> ();
				var bSounds = this.GetComponent<BarrierScript> ();
				//Select the last sound in the array 
				b.clip = bSounds.barrierDamageFX[5];
				//Play explosion sound
				b.Play ();
			}
		}

		void DestroyGameObject()
		{
			Destroy(gameObject);
		}
	}
}