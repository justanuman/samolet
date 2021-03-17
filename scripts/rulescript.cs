using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class rulescript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("14.03-map_functional");
    }
    public void backGame()
    {
        SceneManager.LoadScene("main");
    }
}
