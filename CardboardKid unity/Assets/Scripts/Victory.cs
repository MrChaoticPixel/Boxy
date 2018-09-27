using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour {
    public Player P;
    public MeshRenderer VicMesRen;
    public Material closed, open;
    public bool Op, VictoryOn;
    // Use this for initialization
    void Start () {
        VictoryOn = false;
        Op = false;
        VicMesRen = GetComponent<MeshRenderer>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (P.score < 30)
        {
            Op = false;
            VicMesRen.material = closed;
        }
        if (P.score >= 30)
        {
            Op = true;
            VicMesRen.material = open;
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
           if (Op == true)
            {
                VictoryOn = true;
                P.canbox = false;
                Time.timeScale = 0;
                Debug.Log("YouWin " + "Time: " + Timer.TimeScoreHours + ":" + Timer.TimeScoreMin + ":" + Timer.TimeScoreSeconds.ToString("f2"));
            }
        
        }
    }
}
