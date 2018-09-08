using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class Shooter : MonoBehaviour
	{
		public enum ShootMethod { FireRate, Chance }

		public GameObject pfbBullet;
		public ShootMethod method;

		[Header("Fire Rate Properties")]
		public float shotPerSecond = 10;
		float fireRateTime;

		[Header("Chance Propoerties")]
		public float baseChanceToShoot = 1;
		public float chanceToShootRange = 1000;
		float chanceCoolDownTimer;

		bool canShoot;
		bool shot;

		SpriteRenderer spriteRenderer;
		AudioSource audioSource;

		void Start()
		{
			spriteRenderer = GetComponentInChildren<SpriteRenderer>();
			audioSource = GetComponent<AudioSource>();
		}

		void Update()
		{
			if (shot)
			{
				if (method == ShootMethod.Chance)
				{
					chanceCoolDownTimer += Time.deltaTime;
					if (chanceCoolDownTimer >= Random.Range(.5f, 1.5f))
					{
						shot = false;
						chanceCoolDownTimer = 0;
					}
				}
				else if (method == ShootMethod.FireRate)
				{
					fireRateTime += Time.deltaTime;
					if (fireRateTime >= 1 / shotPerSecond)
					{
						shot = false;
						fireRateTime = 0;
					}
				}
			}
		}

		public void Shoot()
		{
			if ( spriteRenderer == null )
			{
				return;
			}

#if UNITY_EDITOR
			if (spriteRenderer.IsVisibleFrom(Camera.main) == false)
			{
				return;
			}
#else
			if (spriteRenderer.isVisible == false)
			{
				return;
			}
#endif
			if ( method == ShootMethod.Chance )
			{
				var r = Random.Range(0, chanceToShootRange);
				bool calculateChance = r <= baseChanceToShoot;
				if (calculateChance && shot == false)
				{
					shot = true;
					InstantiateBullet();
				}
			}
			else if ( method == ShootMethod.FireRate  )
			{
				if (shot == false)
				{
					shot = true;
					InstantiateBullet();
				}
			}
		}

		void InstantiateBullet()
		{
			var go = Instantiate(pfbBullet);
			go.transform.position = this.transform.position;
			go.transform.parent = this.transform.parent;
			audioSource.Play();
		}
	}
}