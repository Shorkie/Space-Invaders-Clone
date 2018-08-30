using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class Health : MonoBehaviour
	{
		public float healthPoints;

		void TakeDamage(float value)
		{
			if ( value < 0 )
			{
				return;
			}

			healthPoints -= value;

			if (healthPoints <= 0)
			{
				Die();
			}
		}

		void Die()
		{
			// TODO: Spawn effects
			Destroy(this.gameObject);
		}
	}
}