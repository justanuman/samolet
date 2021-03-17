using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endgame : MonoBehaviour
{
    public void returntoMainmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void retry()
    {
        SceneManager.LoadScene("14.03-map_functional");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
