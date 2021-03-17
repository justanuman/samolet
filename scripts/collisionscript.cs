using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class collisionscript : MonoBehaviour
{
    public DateTime bruh_moment = DateTime.Now;
    public Transform Samolet;
    public Transform Sphere;
    public static int score = 0;
    public Text scor;
    //public Vector3 plane_pos = GameObject.Find("Samolet").transform.position;
    //public Vector3 ring_pos = GameObject.Find("Sphere").transform.position;
    // Start is called before the first frame update && 
    //UnityEngine.Random.Range(1.0f, 10.0f), UnityEngine.Random.Range(1.0f, 10.0f) , UnityEngine.Random.Range(1.0f, 10.0f)
    void Start()
    {
        UnityEngine.Random.seed = (bruh_moment.Second + bruh_moment.Day + bruh_moment.Minute);
    }

    // Update is called once per frame
    void Update()
    {
        //System.Random = new Unity.Engine.Random.Random
        Debug.Log((score).ToString());
        if (((Mathf.Abs(Sphere.position.x - Samolet.position.x)<15f) &&((Mathf.Abs(Sphere.position.x - Samolet.position.x)>0f))&& (((Mathf.Abs(Sphere.position.y - Samolet.position.y) < 15f) && ((Mathf.Abs(Sphere.position.y - Samolet.position.y) > 0f))))&& (((Mathf.Abs(Sphere.position.z - Samolet.position.z) < 15f) && (Mathf.Abs(Sphere.position.z - Samolet.position.z) > 0f)))))
        {
            
            Sphere.transform.position = new Vector3(UnityEngine.Random.Range(-600f, 600f), UnityEngine.Random.Range(220f, 450f), UnityEngine.Random.Range(-600f, 600f));
            //Debug.Log((Sphere.position.x - Samolet.position.x).ToString());
            score += 1;
        }
        //scor.text = "яв╗р: " + score.ToString();
    }
}
