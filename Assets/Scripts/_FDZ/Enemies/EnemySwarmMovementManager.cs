using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	[DefaultExecutionOrder(-1000)]
	public class EnemySwarmMovementManager : MonoBehaviour
	{
		public bool allDead { get; protected set; }
		public Enemy[] enemies;

		[Header("MOVEMENT")]
		public float hDir = 1;
		public float vDir = 0;
		public bool modifyVDirOnBounce = true;
		[Space]
		public float speed = 10;
		bool moveDown;
		Vector2 mDir;
		[Space]
		public float moveDownForSeconds = .4f;
		float vTimer;

		[Header("POSITION BOUNDARIES")]
		public float minPosX;
		public float maxPosX;

		void OnEnable()
		{
			enemies = GetComponentsInChildren<Enemy>();
		}

		public int deadCount { get; protected set; }
		public int totalCount { get { return enemies.Length; } }

		void FixedUpdate()
		{
			deadCount = 0;

			var hittedBoundaries = false;
			foreach (var unit in enemies)
			{
				if (IsUnitValid(unit) == false)
				{
					deadCount++;
					continue;
				}

				if (hittedBoundaries == false)
				{
					hittedBoundaries = HasHittedBoundaries(unit.transform.position.x);
					if (hittedBoundaries)
					{
						moveDown = true;
						hDir = -hDir;
					}
				}

				unit.Shoot();
			}

			if (deadCount >= enemies.Length)
			{
				allDead = true;
			}

			if (moveDown)
			{
				MoveDownTimerTick();
			}

			SetMDir();
			SetUnitsDirAndSpeed();
		}

		void MoveDownTimerTick()
		{
			if (modifyVDirOnBounce == false)
			{
				return;
			}

			vTimer += Time.deltaTime;
			if (vTimer < moveDownForSeconds)
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
				unit.dir = mDir.normalized;
				unit.speed = speed * EnemyWave.speedModifier;
			}
		}

		bool IsUnitValid(Enemy e)
		{
			var check = e == null || e.isActiveAndEnabled == false || e.gameObject.activeInHierarchy == false || e.gameObject.activeSelf == false;
			return check == false;
		}

		bool HasHittedBoundaries(float posX)
		{
			return posX < minPosX && hDir < 0 || posX > maxPosX && hDir > 0;
		}

		void OnDrawGizmosSelected()
		//void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			var y = 1000000;
			Gizmos.DrawLine(new Vector3(minPosX, -y, 0), new Vector3(minPosX, y, 0));
			Gizmos.DrawLine(new Vector3(maxPosX, -y, 0), new Vector3(maxPosX, y, 0));
		}
	}
}