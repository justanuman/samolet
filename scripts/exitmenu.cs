using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class exitmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
