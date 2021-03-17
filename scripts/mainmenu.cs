using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("14.03-map_functional");
    }
    
    public void Settings()
    {
        SceneManager.LoadScene("rules");
    }
    public void tits()
    {
        SceneManager.LoadScene("tits");
    }
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
