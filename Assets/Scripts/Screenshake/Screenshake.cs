﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class Screenshake : MonoBehaviour {
		public float power = 0.7f;
		public float duration = 1.0f;
		public Transform camera;
		public float slowDownAmount = 1.0f;
		public bool shouldShake = false;

		Vector3 startPosition;
		float initialDuration;

		// Use this for initialization
		void Start () {
			camera = Camera.main.transform;
			startPosition = camera.localPosition;
			initialDuration = duration;
		}
		
		// Update is called once per frame
		void Update () {
			shakeIt();
		}

		void shakeIt(){
			if(shouldShake)
			{
				if(duration > 0)
				{
					camera.localPosition = startPosition + Random.insideUnitSphere * power;
					duration -= Time.deltaTime * slowDownAmount;
				}
				else
				{
					shouldShake = false;
					duration = initialDuration;
					camera.localPosition = startPosition; 
				}
			}
		}
	}
}
