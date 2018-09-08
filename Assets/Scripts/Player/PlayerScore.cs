using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Name
{
	public class PlayerScore : MonoBehaviour
	{
		public Text scoreText;
		static Text _scoreText;

		public Text gameOverText;

		//public int scoreIncrement;
		//public int totalScore;
		static int totalScore;
		
		// Use this for initialization
		void Start ()
		{
			totalScore = 0;
			scoreText.text = "Score: " + totalScore;
			_scoreText = scoreText;
		}

		// Update is called once per frame
		void Update ()
		{
			if (GameObject.Find ("player") == null)
			{
				scoreText.gameObject.SetActive (false);
				gameOverText.gameObject.SetActive (true);
				gameOverText.text = "Game Over\n Score: " + totalScore + "\n Press R to restart.";
			}
		}

		public static void AddScore(int scoreIncrement)
		{
			totalScore += scoreIncrement;
			_scoreText.text = "Score: " + totalScore;
		}
	}
}