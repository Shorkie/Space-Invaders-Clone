using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Name
{
	public class BulletBehaviour : MonoBehaviour
	{
		public int bulletDamage;
		public float bulletSpeed;
		//Score
		//public GameObject uiGO;
		//Spawn check 
		string spawner;
		bool checkSpawner = true;
		Vector3 bulletPos;
		// Use this for initialization
		void Start ()
		{
			//Finding the UI for the scoring system to use
			//uiGO = GameObject.FindWithTag("UI");
		}

		// Update is called once per frame
		void Update ()
		{
			bulletPos = this.transform.position;
			bulletPos.y += bulletSpeed * Time.deltaTime;
			this.transform.position = bulletPos;
		}

		void OnTriggerEnter2D (Collider2D other)
		{
			var h = other.GetComponent<Health> ();
			var s = Camera.main.GetComponent<Screenshake> ();
			if (checkSpawner)
			{
				spawner = other.tag;
				checkSpawner = false;
			}
			if (h != null && other.tag != spawner)
			{
					//Score
					if (other.tag == "enemy" && GameObject.Find("/player") != null)
					{
						//var a = uiGO.GetComponent<PlayerScore>();
						//Score goes up
						//a.totalScore += a.scoreIncrement;
						//a.scoreText.text = "Score: " + a.totalScore;
						var enemy = other.GetComponent<Enemy>();
						PlayerScore.AddScore(enemy.score);
					}
				//Shake
				s.shouldShake = true;
				h.TakeDamage (bulletDamage);
				Debug.Log (this.name + " hitted with object " + other.name);
				//Destroying bullet upon impact
				Destroy (gameObject);

			}
		}
		//Destroying bullet when it's not being rendered by the camera
		void OnBecameInvisible ()
		{
			Destroy (gameObject);
		}
	}
}