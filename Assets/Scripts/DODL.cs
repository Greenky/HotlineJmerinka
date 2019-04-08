using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DODL : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (GameObject.FindGameObjectsWithTag("Finish").Length > 1)
            Destroy(gameObject);
	}

	private void Update()
	{
		if (SceneManager.GetActiveScene().name == "MainMenu")
			Destroy(gameObject);
	}
}
