using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenuController : MonoBehaviour
{

    [SerializeField]
    private GameObject exitPanel;

    [SerializeField]
    private GameObject helpPanel;

    public void Awake()
    {
        
    }

    public void ButtonClicked()
    {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;


        if (buttonName == "Play Game")
        {
            SceneManager.LoadScene("GameScene");
        }
        else if (buttonName == "Exit")
        {
            exitPanel.SetActive(true);
        }
        else if (buttonName == "Help")
        {
            helpPanel.SetActive(true);
        }
    }

    public void PanelExitButtonClicked()
    {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        if (buttonName == "Yes")
        {
            Application.Quit();
        }
        else if (buttonName == "No")
        {
            exitPanel.SetActive(false);
        }
    }
    public void PanelHelpButtonClicked()
    {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        if (buttonName == "X")
        {
            helpPanel.SetActive(false);
        }
    }


}
