using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Name
{
	public class Health : MonoBehaviour
	{
		public float healthPoints;

		public class UnityEventFloat : UnityEvent<float> {}
		public UnityEventFloat onDamageTaken;
		public UnityEvent onDeath;

		void TakeDamage(float value)
		{
			if ( value < 0 )
			{
				return;
			}

			healthPoints -= value;
			onDamageTaken.Invoke(healthPoints);

			if (healthPoints <= 0)
			{
				Die();
			}
		}

		void Die()
		{
			// TODO: Spawn effects
			onDeath.Invoke();
			Destroy(this.gameObject);
		}
	}
}