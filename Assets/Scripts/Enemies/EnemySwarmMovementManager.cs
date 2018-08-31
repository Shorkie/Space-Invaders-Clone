using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	[DefaultExecutionOrder (-1000)]
	public class EnemySwarmMovementManager : MonoBehaviour
	{
		public Enemy[] enemies;

		[Header ("MOVEMENT")]
		public float speed = 10;
		public float hDir = 1;
		float vDir = 0;
		bool moveDown;
		Vector2 mDir;
		[Space]
		public float vTimerMax = .4f;
		float vTimer;

		[Header ("POSITION BOUNDARIES")]
		public float minPosX;
		public float maxPosX;

		void Awake ()
		{
			enemies = GetComponentsInChildren<Enemy> ();
		}

		void FixedUpdate ()
		{
			var hittedBoundaries = false;
			foreach (var unit in enemies)
			{
				if (IsUnitValid (unit) == false)
				{
					continue;
				}

				if (hittedBoundaries == false)
				{
					hittedBoundaries = HasHittedBoundaries (unit.transform.position.x);
					if (hittedBoundaries)
					{
						moveDown = true;
						hDir = -hDir;
					}
				}

				unit.Shoot ();
			}

			if ( moveDown )
			{
				MoveDownTimerTick();
			}

			SetMDir();
			SetUnitsDirAndSpeed();
		}

		void MoveDownTimerTick()
		{
			vTimer += Time.deltaTime;
			if (vTimer < vTimerMax)
			{
				vDir = -1;
			}
			else
			{
				vDir = 0;
				moveDown = false;
				vTimer = 0;
			}
		}

		void SetMDir()
		{
			mDir.x = hDir;
			mDir.y = vDir;
			mDir.Normalize();
		}

		void SetUnitsDirAndSpeed()
		{
			foreach (var unit in enemies)
			{
				unit.dir = this.mDir;
				unit.speed = speed;
			}
		}

		bool IsUnitValid (Enemy e)
		{
			var check = e == null || e.isActiveAndEnabled == false || e.gameObject.activeInHierarchy == false || e.gameObject.activeSelf == false;
			return check == false;
		}

		bool HasHittedBoundaries (float posX)
		{
			return posX < minPosX && hDir < 0 || posX > maxPosX && hDir > 0;
		}

		//void OnDrawGizmosSelected()
		void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			var y = 1000000;
			Gizmos.DrawLine(new Vector3(minPosX, -y, 0), new Vector3(minPosX, y, 0));
			Gizmos.DrawLine(new Vector3(maxPosX, -y, 0), new Vector3(maxPosX, y, 0));
		}
	}
}