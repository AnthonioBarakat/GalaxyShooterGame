using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayButtonController : MonoBehaviour
{
    public void ButtonClicked()
    {
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if (buttonName == "Home")
        {
            SceneManager.LoadScene("StartScene");
        }
        else if (buttonName == "Restart")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
