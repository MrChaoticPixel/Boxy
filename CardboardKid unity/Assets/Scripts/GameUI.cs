using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

    public GoogleAnalyticsV4 G4;
    public GameObject StartMenu, ControlsMenu;
    

	// Use this for initialization
	void Start () {

        Time.timeScale = 1;

    }
	
	// Update is called once per frame
	void Update ()

    {

    }


    public void BackToMenu()
    {
        G4.LogEvent("PressButton", "BackButton", "HasPressed", 1);

        // Builder Hit with all Event parameters.
        G4.LogEvent(new EventHitBuilder()
            .SetEventCategory("PressButton")
            .SetEventAction("BackButton")
            .SetEventLabel("HasPressed")
            .SetEventValue(1));

        Debug.Log("Sent");
        ControlsMenu.SetActive(false);
        StartMenu.SetActive(true);
    }

    public void HandleStart()
    {
        G4.LogEvent("PressButton", "StartButton", "HasPressed", 1);

        // Builder Hit with all Event parameters.
        G4.LogEvent(new EventHitBuilder()
            .SetEventCategory("PressButton")
            .SetEventAction("StartButton")
            .SetEventLabel("HasPressed")
            .SetEventValue(1));

        Debug.Log("Sent");
        SceneManager.LoadScene("Playground");
    }

    public void HandleControls()
    {
        G4.LogEvent("PressButton", "ControlButton", "HasPressed", 1);

        // Builder Hit with all Event parameters.
        G4.LogEvent(new EventHitBuilder()
            .SetEventCategory("PressButton")
            .SetEventAction("ControlButton")
            .SetEventLabel("HasPressed")
            .SetEventValue(1));

        Debug.Log("Sent");
        ControlsMenu.SetActive(true);
        StartMenu.SetActive(false);
    }

    public void HandleQuit()
    {
        G4.LogEvent("PressButton", "QuitButton", "HasPressed", 1);

        // Builder Hit with all Event parameters.
        G4.LogEvent(new EventHitBuilder()
            .SetEventCategory("PressButton")
            .SetEventAction("QuitButton")
            .SetEventLabel("HasPressed")
            .SetEventValue(1));

        Debug.Log("Sent");
        Application.Quit();
    }

}
