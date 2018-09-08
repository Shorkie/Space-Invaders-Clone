using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class EnemyWave : MonoBehaviour
	{
		static float _speedModifier;
		public static float speedModifier { get { return _speedModifier; } protected set { _speedModifier = value; } }
		public static void ResetSpeedModifier()
		{
			_speedModifier = 1;
		}

		static float speedUpRate = 3.5f;

		EnemySwarmMovementManager[] swarms;
		[Header("dont touch")]
		[SerializeField] int startingTotalUnits;
		[SerializeField] int curTotalUnits;
		[SerializeField] float mySpeedModifier;

		void Start()
		{
			swarms = GetComponentsInChildren<EnemySwarmMovementManager>();
		}

		void Update()
		{
			if ( startingTotalUnits == 0 )
				foreach (var item in swarms)
				{
					startingTotalUnits += item.totalCount;
				}

			curTotalUnits = 0;
			int count=0;

			foreach (var item in swarms)
			{
				if (item.allDead)
				{
					count++;
				}
				curTotalUnits += item.totalCount - item.deadCount;
			}

			if (count >= swarms.Length)
			{
				Destroy(this.gameObject);
				return;
			}
			
			if ( curTotalUnits > startingTotalUnits )
			{
				curTotalUnits = startingTotalUnits;
			}

			mySpeedModifier = (float)curTotalUnits / (float)startingTotalUnits;
			mySpeedModifier = 1 + ( speedUpRate - mySpeedModifier * speedUpRate );
			_speedModifier = mySpeedModifier;
		}
	}
}