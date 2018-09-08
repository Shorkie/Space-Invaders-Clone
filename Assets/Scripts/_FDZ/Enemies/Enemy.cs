using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class Enemy : MonoBehaviour
	{
		public int score = 10;
		public Vector3 dir;
		public float speed;

		Rigidbody2D rb2D;

		private UnityEngine.Events.UnityAction onBecameInvisibleUAction;
		private UnityEngine.Events.UnityAction onBecameVisibleUAction;

		SpriteRenderer spriteRenderer;

		Shooter shooter;

		void Awake()
		{
			Debug.Log("wake");
			rb2D = GetComponent<Rigidbody2D>();
			rb2D.interpolation = RigidbodyInterpolation2D.Interpolate;

			spriteRenderer = GetComponentInChildren<SpriteRenderer>();
			//ovcc.onBecameInvisible += OnBecameInvisible;
			//ovcc.onBecameVisible += OnBecameVisible;
			//Debug.LogError("WORKING ON VISIBILITY");

			spriteRenderer.color = Color.red;

			 shooter = GetComponent<Shooter>();
		}

		public void Shoot()
		{
			shooter.Shoot();
		}

		void FixedUpdate()
		{
			//transform.position += dir * ( speed * Time.deltaTime );
			var newPos = transform.position + dir * (speed * Time.deltaTime);
			if ( float.IsNaN( newPos.x ) || float.IsNaN( newPos.z )|| float.IsNaN( newPos.z ) )
			{
				return;
			}
			rb2D.MovePosition(newPos);

			if ( transform.position.y < -6 )
			{
				//PlayerScore.AddScore(-score);
				Destroy(this.gameObject);
			}
		}
	}
}