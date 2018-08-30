using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class EnemySwarmManager : MonoBehaviour
	{
		public Enemy[] enemies;

		[Header ("MOVEMENT")]
		[Range (0, 100)] public float speed;
		[Range (-100, 0)] public float unitsDown;

		[Header ("POSITION BOUNDARIES")]
		public float minPosX;
		public float maxPosX;

		float curSpeed;

		void Awake ()
		{
			curSpeed = speed;
			enemies = GetComponentsInChildren<Enemy> ();
		}

		void Update ()
		{
			var hittedBoundaries = false;
			foreach (var unit in enemies)
			{
				if (unit == null || unit.isActiveAndEnabled == false || unit.gameObject.activeInHierarchy == false || unit.gameObject.activeSelf == false)
				{
					Debug.Log ("pup");
					continue;
				}
				
				if ( hittedBoundaries == false )
					hittedBoundaries = HasHittedBoundaries( unit.transform.position.x );
				unit.Shoot();
			}

			if (hittedBoundaries)
			{
				MoveDown ();
			}
			else
			{
				MoveToSides();
			}
		}

		bool HasHittedBoundaries(float posX)
		{
			return posX < minPosX && curSpeed < 0 || posX > maxPosX && curSpeed > 0;
		}

		void MoveToSides ()
		{
			foreach (var unit in enemies)
			{
				unit.transform.Translate (curSpeed * Time.deltaTime, 0, 0);
			}
		}

		void MoveDown ()
		{
			curSpeed = -curSpeed;
			foreach (var unit in enemies)
			{
				unit.transform.Translate (0, unitsDown, 0); // make it smooth? like if ( pos.y < targetY ) {do the smooth translate}
			}
		}
	}
}