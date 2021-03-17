using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_trigger : MonoBehaviour
{
    IEnumerator w()
    {
        yield return new WaitForSeconds(1f);
        intr = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    bool gears = true;
    bool intr = true;
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.L)) && (gears == true) && (intr == true))
        {
            GetComponent<Animation>().Play("GearsIn");
            gears = false;
            intr = false;
            StartCoroutine(w());
        }
        else if ((Input.GetKeyDown(KeyCode.L)) && (gears == false) && (intr == true))
        {
            gameObject.GetComponent<Animation>()["Scene"].speed = -1;
            gameObject.GetComponent<Animation>()["Scene"].time = gameObject.GetComponent<Animation>()["Scene"].length;
            GetComponent<Animation>().Play("Scene");
            gears = true;
            intr = false;
            StartCoroutine(w());
        }
    }
}
