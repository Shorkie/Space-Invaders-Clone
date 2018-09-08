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
		bool _isDead;
		public bool isDead { get { return _isDead; } protected set { _isDead = value; } }
		
		[Space]
		public bool destroyOnDeath = true;
		[SerializeField] GameObject spawnOnDeath;
		public AudioClip hurtSound;

		AudioSource audioSource;

		[System.Serializable]
		public class UnityEventFloatX3 : UnityEvent<float, float, float> {}// maybe onDamageTakenCouldUseThis

		[System.Serializable]
		public class UnityEventGameObject : UnityEvent<GameObject> {}// maybe onDamageTakenCouldUseThis

		[Space]
		[Tooltip("curHealthPoints, prevHealthPoints, damageTaken")]
		/// <summary>
		/// curHealthPoints, prevHealthPoints, damageTaken
		/// </summary>
		public UnityEventFloatX3 onDamageTaken;
		public UnityEvent onDeath;
		public UnityEventGameObject onDeathPrefabInstantiated;

		void Awake ()
		{
			healthPoints = _maxHealth;
			audioSource = GetComponent<AudioSource>();
		}

		public void TakeDamage (float value)
		{
			if (value < 0)
			{
				return;
			}
			
			var prevHealthPoints = healthPoints;
			healthPoints -= value;
			if ( onDamageTaken != null )
			{
				if ( audioSource != null && hurtSound != null )
				{
					audioSource.clip = hurtSound;
					audioSource.Play();
				}
			 	onDamageTaken.Invoke(healthPoints, prevHealthPoints, value);
			}

			if (healthPoints <= 0)
			{
				Die ();
			}
		}

		void OnTriggerEnter2D (Collider2D other)
		{
			var otherHealth = other.GetComponent<Health>();
			if (otherHealth != null)
			{
				otherHealth.TakeDamage(this.healthPoints);
			}
		}

		void Die()
		{
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
		}
	}
}