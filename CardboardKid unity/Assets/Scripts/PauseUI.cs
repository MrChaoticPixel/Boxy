using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour {

    public GoogleAnalyticsV4 G4;
    public GameObject PauseMenuUI, ControlsUI, QuitToMainUI, MainPauseUI;
    public bool IsPaused;

	// Use this for initialization
	void Start () {
        IsPaused = false;
	}
	
	// Update is called once per frame
	void Update () {

        HandlePause();


    }

    public void HandleBackPause()
    {
        G4.LogEvent("PressButton", "BackPauseButton", "HasPressed", 1);

        // Builder Hit with all Event parameters.
        G4.LogEvent(new EventHitBuilder()
            .SetEventCategory("PressButton")
            .SetEventAction("BackPauseButton")
            .SetEventLabel("HasPressed")
            .SetEventValue(1));

        Debug.Log("Sent");
        ControlsUI.SetActive(false);
        QuitToMainUI.SetActive(false);
        MainPauseUI.SetActive(true);
    }

    public void HandleControl()
    {
        G4.LogEvent("PressButton", "ControlButton", "HasPressed", 1);

        // Builder Hit with all Event parameters.
        G4.LogEvent(new EventHitBuilder()
            .SetEventCategory("PressButton")
            .SetEventAction("ControlButton")
            .SetEventLabel("HasPressed")
            .SetEventValue(1));

        Debug.Log("Sent");
        MainPauseUI.SetActive(false);
        ControlsUI.SetActive(true);
    }

    public void HandleBack()
    {
        G4.LogEvent("ResumeGame", "Unpaused", "Back", 1);

        // Builder Hit with all Event parameters.
        G4.LogEvent(new EventHitBuilder()
            .SetEventCategory("ResumeGame")
            .SetEventAction("Unpaused")
            .SetEventLabel("Back")
            .SetEventValue(1));

        Debug.Log("Sent");
        Time.timeScale = 1;
        QuitToMainUI.SetActive(false);
        ControlsUI.SetActive(false);
        MainPauseUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        IsPaused = false;
    }

    public void HandlePause()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (IsPaused == false)
            {
                G4.LogEvent("PressedStart", "Paused", "HasPaused", 1);

                // Builder Hit with all Event parameters.
                G4.LogEvent(new EventHitBuilder()
                    .SetEventCategory("PressButton")
                    .SetEventAction("Paused")
                    .SetEventLabel("HasPressed")
                    .SetEventValue(1));

                Debug.Log("Sent");
                Time.timeScale = 0;
                PauseMenuUI.SetActive(true);
                MainPauseUI.SetActive(true);
                QuitToMainUI.SetActive(false);
                ControlsUI.SetActive(false);
                IsPaused = true;
            }
            else
            {
                Time.timeScale = 1;
                QuitToMainUI.SetActive(false);
                ControlsUI.SetActive(false);
                MainPauseUI.SetActive(true);
                PauseMenuUI.SetActive(false);
                IsPaused = false;
            }
            
        }
            
    }

    public void HandleToMain()
    {
        G4.LogEvent("PressButton", "MainButton", "HasPressed", 1);

        // Builder Hit with all Event parameters.
        G4.LogEvent(new EventHitBuilder()
            .SetEventCategory("PressButton")
            .SetEventAction("MainButton")
            .SetEventLabel("HasPressed")
            .SetEventValue(1));

        Debug.Log("Sent");
        QuitToMainUI.SetActive(true);
        MainPauseUI.SetActive(false);
    }

    public void HandleYes()
    {
        G4.LogEvent("PressButton", "YesButton", "HasPressed", 1);

        // Builder Hit with all Event parameters.
        G4.LogEvent(new EventHitBuilder()
            .SetEventCategory("PressButton")
            .SetEventAction("YesButton")
            .SetEventLabel("HasPressed")
            .SetEventValue(1));

        Debug.Log("Sent");
        SceneManager.LoadScene("Main");
    }
}
