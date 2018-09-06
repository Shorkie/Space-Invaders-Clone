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
<<<<<<< HEAD

=======
>>>>>>> fdz
		public float healthPoints { get; protected set; }
		bool _isDead;
		public bool isDead { get { return _isDead; } protected set { _isDead = value; } }
		
		[Space]
		public bool destroyOnDeath = true;
		[SerializeField] GameObject spawnOnDeath;
		public AudioClip hurtSound;

		AudioSource audioSource;

		//Destroy game object timer
    	public float destroyIn;
    	public float destroyCountdown;

		// [System.Serializable]
		// public class UnityEventFloat : UnityEvent<float> {}// maybe onDamageTakenCouldUseThis

		[System.Serializable]
		public class UnityEventGameObject : UnityEvent<GameObject> {}// maybe onDamageTakenCouldUseThis

		[Space]
		public UnityEvent onDamageTaken;
		public UnityEvent onDeath;
		public UnityEventGameObject onDeathPrefabInstantiated;

		void Awake ()
		{
			healthPoints = _maxHealth;
			audioSource = GetComponent<AudioSource>();
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

			if ( onDamageTaken != null )
			{
				if ( audioSource != null && hurtSound != null )
				{
					audioSource.clip = hurtSound;
					audioSource.Play();
				}
			 	onDamageTaken.Invoke();
			}

			if (healthPoints <= 0)
			{
				Die ();
			}
		}

		void Die ()
		{
<<<<<<< HEAD
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
=======
			if ( isDead )
			{
				return;
			}

			isDead = true;

			if ( onDeath != null )
			{
			 	onDeath.Invoke();
			}
			
			if (spawnOnDeath != null)
			{
				var go = Instantiate(spawnOnDeath);
				go.transform.position = this.transform.position;

				if ( onDeathPrefabInstantiated != null )
				{
					onDeathPrefabInstantiated.Invoke(go);
				}
			}

			if (destroyOnDeath)
			{
				Destroy(this.gameObject);
			}
>>>>>>> fdz
		}
	}
}