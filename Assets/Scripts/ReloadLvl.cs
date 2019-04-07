using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLvl : MonoBehaviour
{
  public void Reload()
	{ Scene sc = SceneManager.GetActiveScene();
		SceneManager.LoadScene(sc.name);
	}
}
