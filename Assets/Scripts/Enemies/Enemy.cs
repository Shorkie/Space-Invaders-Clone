using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class Enemy : MonoBehaviour
	{
		public GameObject pfbBullet;
		public float baseChanceToShoot = 1;

		bool shot;
		float timer;

		public void Shoot(float chanceModifier=1)
		{
			var r = Random.Range(0, 1000);
			bool calculateChance = r <= baseChanceToShoot;
			if ( calculateChance && shot == false )
			{
				shot = true;
				var go = Instantiate(pfbBullet);
				go.transform.position = this.transform.position;
				go.transform.parent = this.transform.parent;
			}
		}

		void Update()
		{
			if ( shot )
			{
				timer += Time.deltaTime;
				if ( timer > Random.Range(.5f, 1.5f) )
				{
					shot = false;
					timer = 0;
				}
			}
		}
	}
}