using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    
    bool Lefty = false;
    public void PlayGame()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Setting(bool newValue)
    {
        
        if (Lefty == true)
        {
            Lefty = false;
            Debug.Log("Your're a stupid!");
        }
        else if(Lefty == false)
        {
            Lefty = true;
            Debug.Log("Your're a cool guy!");
        }
            
    }
}
