using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour {
    public Text TM, score, victime, vicscore, GOTime, GOScore;
    public Player plr;
    public PauseUI PUI;
    public Victory Vic;
    public GameObject stamina, VictoryUI, GOUI;
    public Image staminaImg,ContImg, ScoreImg;
    public Material stamon, stamdown;
    public bool Stamcharge;
	// Use this for initialization
	void Start () {

        stamina.GetComponent<Image>().fillAmount = 0.1f;
        Stamcharge = false;
        TM = GameObject.Find("Time").GetComponent<Text>();
        score = GameObject.Find("Score").GetComponent<Text>();
        staminaImg = GameObject.Find("stamina").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
		TM.text = "Time: " + Timer.TimeScoreHours + ":" + Timer.TimeScoreMin + ":" + Timer.TimeScoreSeconds.ToString("f2");
        score.text = "Score: " + plr.score + "/50";
        victime.text = "Time: " + Timer.TimeScoreHours + ":" + Timer.TimeScoreMin + ":" + Timer.TimeScoreSeconds.ToString("f2");
        vicscore.text = "Score: " + plr.score + "/50";
        GOTime.text = "Time: " + Timer.TimeScoreHours + ":" + Timer.TimeScoreMin + ":" + Timer.TimeScoreSeconds.ToString("f2");
        GOScore.text = "Score: " + plr.score + "/50";
        if (plr.canmov == true)
        {
            if(PUI.IsPaused == false)
            {
                Stamcharge = true;
            }
            else
            {
                Stamcharge = false;
            }
           
        }
        if (plr.score >=30)
        {
            ScoreImg.material = stamon;
        }
        if (plr.score < 30)
        {
            ScoreImg.material = stamdown;
        }
        if (plr.KeyboardMode == true)
        {
            ContImg.material = stamdown;
        }
        else
        {
            ContImg.material = stamon;
        }
        if (Stamcharge == true)
        {
            if (plr.inbox == true)
            {
                stamina.SetActive(true);
                stamina.GetComponent<Image>().fillAmount = stamina.GetComponent<Image>().fillAmount - 0.004f;
            }
            if (plr.inbox == false)
            {
                stamina.GetComponent<Image>().fillAmount = stamina.GetComponent<Image>().fillAmount + 0.01f;
            }
        }
  

        if (stamina.GetComponent<Image>().fillAmount == 0)
        {
            staminaImg.material = stamdown;
            plr.box.SetActive(false);
            plr.inbox = false;
            plr.canbox = false;
        }
        if (stamina.GetComponent<Image>().fillAmount == 1)
        {
            staminaImg.material = stamon;
            plr.canbox = true;
        }
        if (plr.GO == true)
        {
            GOUI.SetActive(true);
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Main");
            }
        }
        else
        {
            GOUI.SetActive(false);
        }
        if (Vic.VictoryOn == true)
        {
            VictoryUI.SetActive(true);
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Main");
            }
        }
        else
        {
            VictoryUI.SetActive(false);
        }
    }

  
}
