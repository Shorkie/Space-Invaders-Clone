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
		bulletPos.y += bulletSpeed;
		this.transform.position = bulletPos;
	}
	//Destroying bullet when it's not being rendered by the camera
	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
