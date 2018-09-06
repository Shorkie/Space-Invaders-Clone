using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class Enemy : MonoBehaviour
	{
		public GameObject pfbBullet;
		public float baseChanceToShoot = 1;
		[Space]
		public Vector3 dir;
		public float speed;

		bool shot;
		float timer;
		Rigidbody2D rb2D;

		[Space]
		[SerializeField] bool canShoot;

		private UnityEngine.Events.UnityAction onBecameInvisibleUAction;
		private UnityEngine.Events.UnityAction onBecameVisibleUAction;

		SpriteRenderer spriteRenderer;

		void Awake ()
		{
			rb2D = GetComponent<Rigidbody2D> ();
			rb2D.interpolation = RigidbodyInterpolation2D.Interpolate;

			spriteRenderer = GetComponentInChildren<SpriteRenderer>();
			//ovcc.onBecameInvisible += OnBecameInvisible;
			//ovcc.onBecameVisible += OnBecameVisible;
			//Debug.LogError("WORKING ON VISIBILITY");

			spriteRenderer.color = Color.red;
		}

		public void Shoot (float chanceModifier = 1)
		{
			#if UNITY_EDITOR
			if ( spriteRenderer.IsVisibleFrom(Camera.main) == false )
			{
				return;
			}
			#else
			if ( spriteRenderer.isVisible == false )
			{
				return;
			}
			#endif

			var r = Random.Range (0, 1000);
			bool calculateChance = r <= baseChanceToShoot;
			if (calculateChance && shot == false)
			{
				shot = true;
				var go = Instantiate (pfbBullet);
				go.transform.position = this.transform.position;
				go.transform.parent = this.transform.parent;
			}
		}

		void Update ()
		{
			if (shot)
			{
				timer += Time.deltaTime;
				if (timer > Random.Range (.5f, 1.5f))
				{
					shot = false;
					timer = 0;
				}
			}
		}

		void FixedUpdate ()
		{
			//transform.position += dir * ( speed * Time.deltaTime );
			rb2D.MovePosition (transform.position + dir * (speed * Time.deltaTime));
		}
	}
}