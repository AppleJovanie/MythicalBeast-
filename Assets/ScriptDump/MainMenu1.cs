using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
  public void Newgame()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {

    }
    public void Quit()
    {
        Debug.Log("Application Quitted");
        Application.Quit();
    }

}
