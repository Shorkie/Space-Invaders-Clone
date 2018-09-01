using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Name
{
	public class BulletBehaviour : MonoBehaviour
	{
		public int bulletDamage;
		public float bulletSpeed;
		Vector3 bulletPos;
		// Use this for initialization
		void Start ()
		{

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
			if (h != null)
			{
				//Shake
				s.shouldShake = true;
				h.TakeDamage (bulletDamage);
				Debug.Log (this.name + " hitted with object " + other.name);

			}
			//Destroying bullet on impact with barrier
			if (other.gameObject.tag == "barrier")
			{
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