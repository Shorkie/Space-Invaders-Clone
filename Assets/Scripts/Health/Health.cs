using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Name
{
	public class Health : MonoBehaviour
	{
		float _healthPoints = 1;
		public float healthPoints { get { return _healthPoints; } protected set { _healthPoints = value; } }

		[System.Serializable]
		public class UnityEventFloat : UnityEvent<float> {}

		public UnityEventFloat onDamageTaken;
		public UnityEvent onDeath;

		public void TakeDamage(float value)
		{
			if ( value < 0 )
			{
				return;
			}

			healthPoints -= value;

			if ( onDamageTaken != null )
				onDamageTaken.Invoke(healthPoints);

			if (healthPoints <= 0)
			{
				Die();
			}
		}

		void Die()
		{
			// TODO: Spawn effects
			if ( onDeath != null )
				onDeath.Invoke();
			Destroy(this.gameObject);
		}
	}
}