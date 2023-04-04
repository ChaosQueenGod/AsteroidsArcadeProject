using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////
//Assignment/Lab/Project: Arcade Project
//Name: Joel Hill
//Section: 2023SP.SGD.285.4171
//Instructor: Aurore Locklear
//Date: 4/3/2023
/////////////////////////////////////////////
public class UIController : MonoBehaviour
{
    public void OnClickPlay()
    {
        SceneManager.LoadScene("Testing");
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnClickReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickQuit()
    {
        print("Quitting...");
        Application.Quit();
    }
}
