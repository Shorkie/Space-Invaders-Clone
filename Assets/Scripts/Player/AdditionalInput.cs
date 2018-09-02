using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Name
{
	public class AdditionalInput : MonoBehaviour
	{

		// Use this for initialization
		void Start ()
		{

		}

		// Update is called once per frame
		void Update ()
		{
			//Input R
			if (Input.GetKeyDown (KeyCode.R))
			{
				//Restart scene
				SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex);
			}
		}
	}
}