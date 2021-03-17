using UnityEngine;
using UnityEngine.UI;
public class althud : MonoBehaviour
{
    GameObject myTextgameobject;
    GameObject speed_to_show;
    GameObject height_to_show;
    public GameObject hudhide;
    Text speed_comp;
    Text height_comp;
    Text component;
    //public GameObject Samolet= GameObject.Find("Samolet");
    public Text Plane;
    private int score_to_show;
    private float height_showing;
    private float speed_showing;
    public GameObject planeloc;
    public static bool GameIsPaused = false;
    public void hide()
    {
        hudhide.SetActive(false);
    }
    void show()
    {
        hudhide.SetActive(true);
    }
    void Start()
    {
        myTextgameobject = GameObject.Find("score");
        speed_to_show = GameObject.Find("show_speed");
        height_to_show = GameObject.Find("height");
        speed_comp = speed_to_show.GetComponent<Text>();
        height_comp = height_to_show.GetComponent<Text>();
        component = myTextgameobject.GetComponent<Text>();
        GameObject theSphere = GameObject.Find("Sphere");
        GameObject thePlane = GameObject.Find("Samolet");
        collisionscript collisionscript = theSphere.GetComponent<collisionscript>();
        PilotScript pilotScript = thePlane.GetComponent<PilotScript>();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                show();
                GameIsPaused = false;
            }
            else
            {
                hide();
                GameIsPaused = true;
            }
        }
        score_to_show = collisionscript.score;
        height_showing = Mathf.Round(GameObject.Find("Samolet").transform.position.y);
        component.text = "Ñ÷åò:"+score_to_show.ToString();
        if (height_showing<500f)
            height_comp.text = "Âûñîòà:" + height_showing;
        else
            height_comp.text = "Ñíèçòåñü!";
        speed_showing = Mathf.Round(PilotScript.speed   );
        speed_comp.text = "Ñêîðîñòü:"+speed_showing.ToString();
        //component.text = "yes";
        //Plane.text = "ÂÛÑÎÒÀ:" + ((int)Samolet.transform.position.y).ToString();
    }

}