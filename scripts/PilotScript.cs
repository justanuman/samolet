using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PilotScript : MonoBehaviour
{
    public static float speed = 0f;
    public float liftSpeed = 10f;
    public float turnSpeed = 10f;
    public float boostSpeed = 20f;
    public float bankSpeed = 10f;
    public string debug;
    public bool grounded;
    private MeshRenderer renderer_corpus;
    private MeshRenderer renderer_pointer;
    private MeshRenderer renderer_glass;
    private MeshRenderer renderer_fronttorus;
    private MeshRenderer renderer_lefttorus;
    private MeshRenderer renderer_righttorus;
    private Light renderer_rightlight;
    private Light renderer_leftlight;
    private float grav = -0.01f;
    private bool blown = false;
    private BoxCollider boom_trigger1;
    private BoxCollider boom_trigger2;
    private CapsuleCollider boom_trigger3;
    public float distToGround = 1f;
    // Start is called before the first frame update
    void Start()
    {
        boom_trigger1 = GameObject.Find("Samolet").GetComponent<BoxCollider>();
        boom_trigger2 = GameObject.Find("Samolet").GetComponent<BoxCollider>();
        boom_trigger3 = GameObject.Find("Samolet").GetComponent<CapsuleCollider>();
        Debug.Log("Plane pilot script added to: " + gameObject.name);
        renderer_corpus = gameObject.transform.GetChild(0).GetComponent<MeshRenderer>();
        renderer_pointer = gameObject.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>();
        renderer_glass = gameObject.transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>();
        renderer_fronttorus = gameObject.transform.GetChild(0).GetChild(2).GetComponent<MeshRenderer>();
        renderer_lefttorus = gameObject.transform.GetChild(0).GetChild(3).GetComponent<MeshRenderer>();
        renderer_righttorus = gameObject.transform.GetChild(1).GetComponent<MeshRenderer>();
        renderer_rightlight = gameObject.transform.GetChild(3).GetComponent<Light>();
        renderer_leftlight = gameObject.transform.GetChild(4).GetComponent<Light>();
    }
    private void OnTriggerEnter(Collider other)
    {
        blown = true;
        renderer_rightlight.enabled = false;
        renderer_leftlight.enabled = false;
        renderer_corpus.enabled = false;
        renderer_pointer.enabled = false;
        renderer_glass.enabled = false;
        renderer_fronttorus.enabled = false;
        renderer_lefttorus.enabled = false;
        renderer_righttorus.enabled = false;
        var ps = GetComponentsInChildren<ParticleSystem>();
        debug = blown.ToString();
        foreach (var p in ps)
            p.Play();
        speed = 0f;

        //Destroy(gameObject.transform.GetChild(1));
        //Camera.main.GetComponent<CameraEffects>().Shake();
    }
    // Update is called once per frame
    void Update()
    {
        IEnumerator w()
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("endgame");
        }
        if (blown == true) { StartCoroutine(w()); }

        if ((Input.GetKey(KeyCode.D) == false) && (Input.GetKey(KeyCode.A) == false) && (transform.rotation.eulerAngles.z > 0f) && (transform.rotation.eulerAngles.z < 180f)) { transform.Rotate(0f, 0f, -(transform.rotation.eulerAngles.z - 0) * 0.0005f); }
        if ((Input.GetKey(KeyCode.D) == false) && (Input.GetKey(KeyCode.A) == false) && (transform.rotation.eulerAngles.z < 359f) && ((transform.rotation.eulerAngles.z > 180f))) { transform.Rotate(0f, 0f, -(transform.rotation.eulerAngles.z - 360) * 0.0005f); }
        if (Input.GetKey(KeyCode.A) && (blown == false) && (grounded == false))
        {
            transform.Rotate(0f, -turnSpeed * Time.deltaTime, 0f, Space.World);
            transform.Rotate(0f, 0f, bankSpeed * Time.deltaTime);// Left turn in relation to world not object
        }
        if (Input.GetKey(KeyCode.D) && (blown == false)&&(grounded==false))
        {
            transform.Rotate(0f, turnSpeed * Time.deltaTime*3, 0f, Space.World);
            transform.Rotate(0f, 0f, -bankSpeed * Time.deltaTime); // Bank right
        } // As above but right
        if (Input.GetKey(KeyCode.W) && (blown == false) && (grounded == false))
            transform.Rotate(liftSpeed * Time.deltaTime, 0f, 0f); // Descends object Same as actual plane joy stick forward is down

        if (Input.GetKey(KeyCode.S) && (blown == false) && (grounded == false))
            transform.Rotate(-liftSpeed * Time.deltaTime, 0f, 0f); // Raises object

        if (Input.GetKey(KeyCode.Q) && (blown == false) && (grounded == false))
            transform.Rotate(0f, -turnSpeed * Time.deltaTime, 0f, Space.World); // Bank left

        if (Input.GetKey(KeyCode.E) && (blown == false) && (grounded == false))
            transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f, Space.World); // Bank right
        Vector3 moveCamTo = transform.position - transform.forward * 15.0f + Vector3.up * 3.0f + transform.right * 2.0f;
        float bias = 0.96f;
        GameObject Camera = GameObject.Find("Camera");
        Camera.transform.position = Camera.transform.position * bias + moveCamTo * (1.0f - bias);
        //Camera.transform.LookAt(transform.position + transform.forward * 30.0f);

       /* if (Input.GetKey(KeyCode.A) && (blown==false) && (grounded == false))
            transform.Rotate(0f, -turnSpeed * Time.deltaTime, 0f, Space.World); // Left turn in relation to world not object
        if (Input.GetKey(KeyCode.D) && (blown == false))
            transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f, Space.World); // As above but right*/

        if (Input.GetKey(KeyCode.W) && (blown == false) && (grounded == false))
            transform.Rotate(liftSpeed * Time.deltaTime, 0f, 0f); // Descends object Same as actual plane joy stick forward is down

        if (Input.GetKey(KeyCode.S) && (blown == false) && (grounded == false))
            transform.Rotate(-liftSpeed * Time.deltaTime, 0f, 0f); // Raises object
        //driving
        if (Input.GetKey(KeyCode.U) && (blown == false) && (grounded == true))
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime);
        if (Input.GetKey(KeyCode.H) && (blown == false) && (grounded == true))
            transform.Rotate(0f, -5 * Time.deltaTime, 0f, Space.World);
        if (Input.GetKey(KeyCode.J) && (blown == false) && (grounded == true))
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime);
        if (Input.GetKey(KeyCode.K) && (blown == false) && (grounded == true))
            transform.Rotate(0f, 5 * Time.deltaTime, 0f, Space.World);


        if (Input.GetKey(KeyCode.R) && (blown == false))
        {
            if (speed < 100f)
            {
                speed += 0.05f;
            }
        }
        if (Input.GetKey(KeyCode.F) && (blown == false))
        {
            if (speed > 0f)
            {
                speed -= 0.05f;
            }
        }
        if (speed < 0f)
            speed = 0f;

        transform.position += transform.forward * Time.deltaTime * speed;
        if ((speed < 3f) && (grounded == false))
        {
            grav -= 0.001f;
        }
        if ((speed > 3f) && (grav < -0.01))
        {
            grav += 0.0001f;
        }
        if ((blown==false) && (grounded == false))
            transform.position += transform.up * grav; // THIS IS GRAVITY
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
            grounded = true;
        else
            grounded = false;
        speed -= transform.forward.y * 2.0f * Time.deltaTime;

        //if ((speed < 5.0f) && (blown == false))
        //{
        //    speed = 5.0f;
        //}
        if (transform.position.y >= 500f) //Ceiling
        {
            grav -= 0.0005f;
        }

        


        //Terrain terrain = GetClosestCurrentTerrain(transform.position);

        //transform.Rotate( Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));
        //underground check
        //debug2 = Terrain.activeTerrains[0].SampleHeight(transform.position).ToString();
        //debug = Terrain.activeTerrains[3].ToString();

    }
}
