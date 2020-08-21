using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region public variables
    public string LoadScene = "GameScene";

    public Dropdown qualityDropdown;
    public Toggle fullscreenToggle;
    public GameObject IWanttoDissableThis;


    public void Start()
    {
        Debug.Log("Starting Game Main Menu");

        if (!PlayerPrefs.HasKey("fullscreen"))
        {
            PlayerPrefs.SetInt("fullscreen", 0);
            Screen.fullScreen = false;

        }
        else

        if (!PlayerPrefs.HasKey("quality"))
        {
            PlayerPrefs.SetInt("quality", 5);
            QualitySettings.SetQualityLevel(5);
        }
        else
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));

        }

        PlayerPrefs.Save();

    }

    public void StartGame()
    {

        SceneManager.LoadScene(LoadScene);
    }


    public void SetFullScreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void ChangeQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }


    public void QuitGame()
    {
        Debug.Log("Quitting Game Adios");

        // #if UNITY_Editor
        EditorApplication.ExitPlaymode();
        // #endif
        Application.Quit();
    }

    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel());
        
        if (fullscreenToggle.isOn)
        {
            PlayerPrefs.SetInt("fullscreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("fullscreen", 0);
        }


        PlayerPrefs.Save();


    }

    public void LoadPlayerPrefs()
    {
        qualityDropdown.value = PlayerPrefs.GetInt("quality");

        if (PlayerPrefs.GetInt("fullscreen") == 0)
        {
            // set toggle off
            fullscreenToggle.isOn = false;
        }
        else
        {
            // set toggle off 
            fullscreenToggle.isOn = true;
        }

    }

    #endregion

    public void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 150), "Testing box");


        if (GUI.Button(new Rect(20, 40, 80, 20), "Press me 1 "))
        {
            Debug.Log("Press me 1 got pressed");
        }

        if (GUI.Button(new Rect(20, 70, 80, 20), "Press me 2 "))
        {
            Debug.Log("Press me 2 got pressed");
            //QuitGame();
        }

        if (GUI.Button(new Rect(20, 100, 80, 20), "Press me 3 "))
        {
            Debug.Log("Press me 3 got pressed");
            //QuitGame();
        }

        if (GUI.Button(new Rect(20, 130, 80, 20), "Press me 4 "))
        {
            Debug.Log("Press me 4 got pressed");
            QuitGame();
        }

        /* GameObject target = GameObject.Find("Main Menu");
            if(GUI.Button(new Rect(320,10,20,20), "X "))
            {
            target.SetActive(false);
            Debug.Log("Random button was pessed");
            } */

    }


}
