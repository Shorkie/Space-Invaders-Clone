using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Name
{
	public class PlayerScore : MonoBehaviour {
		public Text scoreText;
		public Text gameOverText;
		public int scoreIncrement;
		public int totalScore;
		// Use this for initialization
		void Start () {
		totalScore = 0;
		scoreText.text = "Score: " + totalScore;
		}
		
		// Update is called once per frame
		void Update () {
			if (GameObject.Find("player") == null)
			{
				scoreText.gameObject.SetActive(false);
				gameOverText.gameObject.SetActive(true);
				gameOverText.text = "Game Over\n Score: "+totalScore+"\n Press R to restart.";
			}
		}
	}
}
