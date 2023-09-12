using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFirst()
    {
        SceneManager.LoadScene("SelectJobsScene");
    }
    public void PlayContinue() 
    {

    }
    public void ShowSetting()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
