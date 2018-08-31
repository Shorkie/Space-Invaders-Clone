using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
	public float bulletSpeed;
	Vector3 bulletPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bulletPos = this.transform.position;
		bulletPos.y += bulletSpeed * Time.deltaTime;
		this.transform.position = bulletPos;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other.name);
			Debug.Log(other.name);
	}
	//Destroying bullet when it's not being rendered by the camera
	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
