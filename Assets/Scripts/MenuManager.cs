using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private AudioSource _bang;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _loadingMenu;

    public void OnPlayClick()
    {
        _mainMenu.SetActive(false);
        _loadingMenu.SetActive(true);
        Invoke("Load", 3f);
    }

    private void Load()
    {
        SceneManager.LoadScene("level1");
    }
    
    public void OnExitClick()
    {
        Application.Quit();
    }
}
