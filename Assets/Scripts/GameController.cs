using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public List<HPcomponent> enemys;
	public HPcomponent player;

	public GameObject winScreen;
	public GameObject loseScreen;

	public bool gameEnd = false;

	private void Update()
	{
		if (gameEnd == false)
		{
			if (player == null)
			{
				//GAME OVER player lose
				gameEnd = true;
				Debug.Log("GAME OVER");
				loseScreen.SetActive(true);
			}
			for (int i = 0; i < enemys.Count; i++)
			{
				if (enemys[i] == null)
					enemys.RemoveAt(i);
			}
			if (enemys.Count == 0)
			{
				//WIN 
				gameEnd = true;
				winScreen.SetActive(true);
				Debug.Log("PLAYER WIN");
			}
		}
	}
}
