using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class EnemySwarmManager : MonoBehaviour
	{
		public Enemy[] enemies;

		[Header ("MOVEMENT")]
		[Range (-20, 20)] public float hSpeed;
		[Range (-20, 20)] public float vSpeed;
		[Range (0, 2)] public float vTimerMax;

		[Header ("POSITION BOUNDARIES")]
		public float minPosX;
		public float maxPosX;

		float curHSpeed;
		public bool moveDown;
		bool hittedBoundaries;

		float vTimer;

		void Awake ()
		{
			curHSpeed = hSpeed;
			enemies = GetComponentsInChildren<Enemy> ();
		}

		void FixedUpdate ()
		{
			hittedBoundaries = false;
			foreach (var unit in enemies)
			{
				if (IsUnitValid(unit)==false)
				{
					Debug.Log ("pup");
					continue;
				}
				
				if ( hittedBoundaries == false )
				{
					hittedBoundaries = HasHittedBoundaries( unit.transform.position.x );
					InvertHSpeed();
				}
				
				unit.Shoot();
			}
			
			TranslateUnitsPositionX();
			MoveDown();
		}

		void InvertHSpeed()
		{
			curHSpeed = (-System.Math.Sign(curHSpeed)) * hSpeed;
		}

		void MoveDown()
		{
			if (hittedBoundaries)
			{
				moveDown = true;
			}

			if (moveDown == false)
			{
				return;
			}

			vTimer += Time.deltaTime;

			if ( vTimer < vTimerMax )
			{
				curHSpeed = System.Math.Sign(curHSpeed) * hSpeed * .1f;
				TranslateUnitsPositionY ();
			}
			else
			{
				moveDown = false;
				vTimer = 0;
			}
		}

		bool IsUnitValid(Enemy e)
		{
			var check = e == null || e.isActiveAndEnabled == false || e.gameObject.activeInHierarchy == false || e.gameObject.activeSelf == false;
			return check == false;
		}

		bool HasHittedBoundaries(float posX)
		{
			return posX < minPosX && curHSpeed < 0 || posX > maxPosX && curHSpeed > 0;
		}

		void TranslateUnitsPositionX ()
		{
			foreach (var unit in enemies)
			{
				if (IsUnitValid(unit))
				{
					unit.transform.Translate (curHSpeed * Time.fixedDeltaTime, 0, 0);
				}
			}
		}

		void TranslateUnitsPositionY ()
		{
			foreach (var unit in enemies)
			{
				if (IsUnitValid(unit))
				{
					unit.transform.Translate (0, vSpeed * Time.fixedDeltaTime, 0); // make it smooth? like if ( pos.y < targetY ) {do the smooth translate}
				}
			}
		}
	}
}