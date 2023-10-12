using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{

    public void PlayGame()
    {
        string clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("button was clicked:" + clickedButton);
        if (clickedButton == "Soccer")
        {
            MyGameManager.Instance.CharIndex = 0;
            SceneManager.LoadScene("SampleScene3");
        }
        else if (clickedButton == "Vollyball")
        {
            MyGameManager.Instance.CharIndex = 1;
            SceneManager.LoadScene("Test1");
        }
    }
}
