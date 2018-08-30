using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class EnemySwarmManager : MonoBehaviour
	{
		public Enemy[] enemies;

		[Header ("SPEED")]
		[Range (0, 100)] public float speed;
		[Range (-100, 0)] public float unitsDown;

		[Header ("LIMITS")]
		public float leftX;
		public float rightX;

		float curSpeed;

		void Awake ()
		{
			curSpeed = speed;
			enemies = GetComponentsInChildren<Enemy> ();
		}

		void Update ()
		{
			var hittedLimit = false;
			foreach (var unit in enemies)
			{
				if (unit == null || unit.isActiveAndEnabled == false || unit.gameObject.activeInHierarchy == false || unit.gameObject.activeSelf == false)
				{
					Debug.Log ("pup");
					continue;
				}
				var posX = unit.transform.position.x;
				if (posX < leftX && curSpeed < 0 || posX > rightX && curSpeed > 0)
				{
					hittedLimit = true;
				}
			}

			if (hittedLimit)
			{
				MoveDown ();
			}
			else
			{
				MoveToSides();
			}
		}

		public void MoveToSides ()
		{
			foreach (var unit in enemies)
			{
				unit.transform.Translate (curSpeed * Time.deltaTime, 0, 0);
			}
		}

		public void MoveDown ()
		{
			curSpeed = -curSpeed;
			foreach (var unit in enemies)
			{
				unit.transform.Translate (0, unitsDown, 0); // make it smooth? like if ( pos.y < targetY ) {do the smooth translate}
			}
		}
	}
}