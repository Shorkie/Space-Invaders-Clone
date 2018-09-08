using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class EnemyWaveSpawner : MonoBehaviour
	{
		public UnityEngine.UI.Text waveText;
		public GameObject curWave;
		public GameObject[] wavePool;

		int waveCount = 1;
		float waveTextTimer = 0;
		float waveTextTimerMax = 4;

		void Update()
		{
			if (curWave == null)
			{
				waveText.gameObject.SetActive(true);
				waveText.text = "WAVE " + waveCount + "\n" + "starts in " + ((int)(waveTextTimerMax - waveTextTimer));
				waveTextTimer += Time.deltaTime;
				if ( waveTextTimer >= waveTextTimerMax )
				{
					waveText.gameObject.SetActive(false);
					waveTextTimer = 0;
					Spawn();
				}
			}
		}

		void Spawn()
		{
			var index = Random.Range(0, wavePool.Length - 1);
			var toSpwan = wavePool[index];
			var go = Instantiate(toSpwan);
			Debug.Log("EnemyWaveSpawner::Spawn() -- [" + index + "] " + toSpwan.name);
			go.transform.position = this.transform.position;
			go.transform.parent = this.transform;
			curWave = go;
			EnemyWave.ResetSpeedModifier();
			waveCount++;
		}
	}
}