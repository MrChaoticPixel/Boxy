using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public GoogleAnalyticsV4 G4;
    private Rigidbody PlayerRB;
    public float spd, verticalSpeed, horizontalSpeed, hAxis, vAxis, JoyHaxis, JoyVaxis, h, v, Jh, Jv, score;
    public GameObject target, box, player, ControllerIcon;
    public bool canmov, GamepadMode, KeyboardMode, inbox, canbox, GO;
    public AIEnemies AI1, AI2, AI3, AI4, AI5, AI6, AI7, AI8, AI9, AI10, AI11, AI12;
    public RectTransform playericon;
    public AudioSource Detect, coins, Portal, Gamover;
    public CapsuleCollider playercol;
    public Animator anim;


    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        playercol = GetComponent<CapsuleCollider>();
        Detect = GetComponent<AudioSource>();
        GO = false;
        canbox = false;
        score = 0;
        inbox = false;
        KeyboardMode = false;
        GamepadMode = true;
        canmov = false;
        Invoke("StartMovDelay", 3);
        horizontalSpeed = 2.0F;
        verticalSpeed = 2.0F;
        PlayerRB = GetComponent<Rigidbody>();
        spd = 50;

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Jh = horizontalSpeed * Input.GetAxis("JoyHorCam");
        Jv = verticalSpeed * Input.GetAxis("JoyVerCam");
        h = horizontalSpeed * Input.GetAxis("Mouse X");
        v = verticalSpeed * Input.GetAxis("Mouse Y");
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        JoyHaxis = Input.GetAxis("JoyHor");
        JoyVaxis = Input.GetAxis("JoyVer");
        HandleCam();
        HandleMov();
        HandleBox();

	}
    public void HandleControllerMode()
    {
        if (GamepadMode == false)
        {
            GamepadMode = true;
            KeyboardMode = false;
        }
        else
        {
            GamepadMode = false;
            KeyboardMode = true;
        }
        
    }
    public void HandleBox()
    {
        if (KeyboardMode == true)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (canbox == true)
                {
                    if (inbox == false)
                    {
                        anim.Play("Box");
                        anim.SetBool("On", true);
                        canmov = false;
                        inbox = true;
                    }
                    else
                    {
                        anim.SetBool("On", false);
                        canmov = true;
                        inbox = false;
                    }
                }
            

            }
        }
        if (GamepadMode == true)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                if (canbox == true)
                {
                    if (inbox == false)
                    {
                        anim.Play("Box");
                        anim.SetBool("On", true);
                        inbox = true;
                    }
                    else
                    {
                        anim.SetBool("On", false);
                        inbox = false;
                    }
                }

            }
        }

        if (inbox == true)
        {
            spd = 0;
        }
        else
        {
            spd = 50;
        }
    }
    public void HandleCam()
    {
        if (KeyboardMode == true)
        {
            if (canmov == true)
            {
               transform.Rotate(0, h, 0);
            }
        }
        if (GamepadMode == true)
        {
            if (canmov == true)
            {
                transform.Rotate(0, Jh, 0);
            }
        }

    }
    public void HandleMov()
    {
        if (KeyboardMode == true)
        {
            if (canmov == true)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    if (inbox == false)
                    {
                        anim.Play("Walk");
                    }
                    transform.Translate(Vector3.forward * (spd) * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    if (inbox == false)
                    {
                        anim.Play("Walk");
                    }
                    transform.Translate(Vector3.left * (spd) * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    if (inbox == false)
                    {
                        anim.Play("Walk");
                    }
                    transform.Translate(Vector3.back * (spd) * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    if (inbox == false)
                    {
                        anim.Play("Walk");
                    }
                    transform.Translate(Vector3.right * (spd) * Time.deltaTime);
                }
            }
        }
        if (GamepadMode == true)
        {
            if (canmov == true)
            {
                if (Input.GetAxis("JoyHor") == -1)
                {
                    if (inbox == false)
                    {
                        anim.Play("Walk");
                    }
                    transform.Translate(Vector3.left * (spd) * Time.deltaTime);
                }
                if (Input.GetAxis("JoyVer") == -1)
                {
                    if (inbox == false)
                    {
                        anim.Play("Walk");
                    }
                    transform.Translate(Vector3.forward * (spd) * Time.deltaTime);
                }
                if (Input.GetAxis("JoyVer") == 1)
                {
                    if (inbox == false)
                    {
                        anim.Play("Walk");
                    }
                    transform.Translate(Vector3.back * (spd) * Time.deltaTime);
                }
                if (Input.GetAxis("JoyHor") == 1)
                {
                    if (inbox == false)
                    {
                        anim.Play("Walk");
                    }
                    transform.Translate(Vector3.right * (spd) * Time.deltaTime);
                }
            }
        }


        }
    public void StartMovDelay()
    {
        canbox = true;
        canmov = true;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Collect")
        {
            coins.Play();
            Destroy(collision.gameObject);
            score = score + 1;
            if(score == 30)
            {
                Portal.Play();
            }
        }
        if (collision.gameObject.name == "Boundry1")
        {
            if (AI1.playerVis == true)
            {

                if (inbox == false)
                {
                    Detect.Play();
                }

            }
        }
        if (collision.gameObject.name == "Boundry2")
        {
            if (AI2.playerVis == true)
            {
                if (inbox == false)
                {
                    Detect.Play();
                }

            }
        }
        if (collision.gameObject.name == "Boundry3")
        {
            if (AI3.playerVis == true)
            {
                if (inbox == false)
                {
                    Detect.Play();
                }

            }
        }
        if (collision.gameObject.name == "Boundry4")
        {
            if (AI4.playerVis == true)
            {
                if (inbox == false)
                {
                    Detect.Play();
                }

            }
        }
        if (collision.gameObject.name == "Boundry5")
        {
            if (AI5.playerVis == true)
            {
                if (inbox == false)
                {
                    Detect.Play();
                }

            }
        }
        if (collision.gameObject.name == "Boundry6")
        {
            if (AI6.playerVis == true)
            {
                if (inbox == false)
                {
                    Detect.Play();
                }

            }
        }
        if (collision.gameObject.name == "Boundry7")
        {
            if (AI7.playerVis == true)
            {
                if (inbox == false)
                {
                    Detect.Play();
                }

            }
        }
        if (collision.gameObject.name == "Boundry8")
        {
            if (AI8.playerVis == true)
            {
                if (inbox == false)
                {
                    Detect.Play();
                }

            }
        }
        if (collision.gameObject.name == "Boundry9")
        {
            if (AI9.playerVis == true)
            {
                if (inbox == false)
                {
                    Detect.Play();
                }

            }
        }
        if (collision.gameObject.name == "Boundry10")
        {
            if (AI10.playerVis == true)
            {
                if (inbox == false)
                {
                    Detect.Play();
                }

            }
        }
        if (collision.gameObject.name == "Boundry11")
        {
            if (AI11.playerVis == true)
            {
                if (inbox == false)
                {
                    Detect.Play();
                }

            }
        }
        if (collision.gameObject.name == "Boundry12")
        {
            if (AI12.playerVis == true)
            {
                if (inbox == false)
                {
                    Detect.Play();
                }
             
            }
        }
    }
    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Boundry1")
        {
            if (AI1.playerVis == true)
            {
                if (inbox == false)
                {
                    AI1.Mode = 1;
                }
               
            }
            if (inbox == true)
            {
                AI1.Mode = 0;
            }
         
           
        }
        if (collision.gameObject.name == "Boundry2")
        {
            if (AI2.playerVis == true)
            {
                if (inbox == false)
                {
                    AI2.Mode = 1;
                }
            }
            if (inbox == true)
            {
                AI2.Mode = 0;
            }
        }
        if (collision.gameObject.name == "Boundry3")
        {
            if (AI3.playerVis == true)
            {
                if (inbox == false)
                {
                    AI3.Mode = 1;
                }
            }
            if (inbox == true)
            {
                AI3.Mode = 0;
            }
        }
        if (collision.gameObject.name == "Boundry4")
        {
            if (AI4.playerVis == true)
            {
                if (inbox == false)
                {
                    AI4.Mode = 1;
                }
            }
            if (inbox == true)
            {
                AI4.Mode = 0;
            }
        }
        if (collision.gameObject.name == "Boundry5")
        {
            if (AI5.playerVis == true)
            {
                if (inbox == false)
                {
                    AI5.Mode = 1;
                }
            }
            if (inbox == true)
            {
                AI5.Mode = 0;
            }
        }
        if (collision.gameObject.name == "Boundry6")
        {
            if (AI6.playerVis == true)
            {
                if (inbox == false)
                {
                    AI6.Mode = 1;
                }
            }
            if (inbox == true)
            {
                AI6.Mode = 0;
            }
        }
        if (collision.gameObject.name == "Boundry7")
        {
            if (AI7.playerVis == true)
            {
                if (inbox == false)
                {
                    AI7.Mode = 1;
                }
            }
            if (inbox == true)
            {
                AI7.Mode = 0;
            }
        }
        if (collision.gameObject.name == "Boundry8")
        {
            if (AI8.playerVis == true)
            {
                if (inbox == false)
                {
                    AI8.Mode = 1;
                }
            }
            if (inbox == true)
            {
                AI8.Mode = 0;
            }
        }
        if (collision.gameObject.name == "Boundry9")
        {
            if (AI9.playerVis == true)
            {
                if (inbox == false)
                {
                    AI9.Mode = 1;
                }
            }
            if (inbox == true)
            {
                AI9.Mode = 0;
            }
        }
        if (collision.gameObject.name == "Boundry10")
        {
            if (AI10.playerVis == true)
            {
                if (inbox == false)
                {
                    AI10.Mode = 1;
                }
            }
            if (inbox == true)
            {
                AI10.Mode = 0;
            }
        }
        if (collision.gameObject.name == "Boundry11")
        {
            if (AI11.playerVis == true)
            {
                if (inbox == false)
                {
                    AI11.Mode = 1;
                }
            }
            if (inbox == true)
            {
                AI11.Mode = 0;
            }
        }
        if (collision.gameObject.name == "Boundry12")
        {
            if (AI12.playerVis == true)
            {
                if (inbox == false)
                {
                    AI12.Mode = 1;
                }
            }
            if (inbox == true)
            {
                AI12.Mode = 0;
            }
        }
        if (collision.gameObject.tag == "Spotlight")
        {
            if (inbox == false)
            { 
                Gamover.Play();
                canbox = false;
                canmov = false;
                GO = true;
                Time.timeScale = 0;
                Debug.Log("YouLose " + "Time: " + Timer.TimeScoreHours + ":" + Timer.TimeScoreMin + ":" + Timer.TimeScoreSeconds.ToString("f2"));
                G4.LogEvent("finalscore", "score", "gameover", 1);

                // Builder Hit with all Event parameters.
                G4.LogEvent(new EventHitBuilder()
                    .SetEventCategory("finalscore")
                    .SetEventAction("score")
                    .SetEventLabel("gameover")
                    .SetEventValue(1));

                Debug.Log("Sent");
            }
            
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Boundry1")
        {
            AI1.Mode = 0;
        }
        if (collision.gameObject.name == "Boundry2")
        {
            AI2.Mode = 0;
        }
        if (collision.gameObject.name == "Boundry3")
        {
            AI3.Mode = 0;
        }
        if (collision.gameObject.name == "Boundry4")
        {
            AI4.Mode = 0;
        }
        if (collision.gameObject.name == "Boundry5")
        {
            AI5.Mode = 0;
        }
        if (collision.gameObject.name == "Boundry6")
        {
            AI6.Mode = 0;
        }
        if (collision.gameObject.name == "Boundry7")
        {
            AI7.Mode = 0;
        }
        if (collision.gameObject.name == "Boundry8")
        {
            AI8.Mode = 0;
        }
        if (collision.gameObject.name == "Boundry9")
        {
            AI9.Mode = 0;
        }
        if (collision.gameObject.name == "Boundry10")
        {
            AI10.Mode = 0;
        }
        if (collision.gameObject.name == "Boundry11")
        {
            AI11.Mode = 0;
        }
        if (collision.gameObject.name == "Boundry12")
        {
            AI12.Mode = 0;
        }
    }

    }
