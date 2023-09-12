using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour
{
    public Canvas canvas;
    public GameObject menuPanel;
    public GameObject confirmPanel;
    public GameObject HpBar;
    public GameObject MpBar;
    float menuNum;
    PlayerInput player;
    CameraController cameraController;
    bool menuActive;
    bool confirmActive;
    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(false);
        confirmPanel.SetActive(false);
        player = FindObjectOfType<PlayerInput>();
        cameraController = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuActive)
            {
                if (confirmActive)
                {
                    CancelButton();
                }
                else
                {
                    Resume();
                }

            }
            else
            {
                Pause();
            }
        }
        HpBar.GetComponent<Image>().fillAmount = PlayerManager.playerManager.currentHp / PlayerManager.playerManager.maxHp;
        MpBar.GetComponent<Image>().fillAmount = PlayerManager.playerManager.currentMp / PlayerManager.playerManager.maxMp;
    }
    public void Resume()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1;
        menuActive = false;
    }
    public void Pause()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0;
        menuActive = true;
    }
    public void LoadGame()
    {
        menuNum = 1;
        confirmPanel.SetActive(true);
        confirmActive = true;
    }

    public void OpenSetting()
    {

    }

    
    public void GoMain()
    {
        menuNum = 2;
        confirmPanel.SetActive(true);
        confirmActive = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ConfirmButton()
    {
        if (menuNum == 1)
        {
            Destroy(player.gameObject);
            Destroy(cameraController.gameObject);
            Time.timeScale = 1;
        }
        else
        {
            Destroy(player.gameObject);
            Destroy(cameraController.gameObject);
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenuScene");
        }
    }
    public void CancelButton()
    {
        confirmPanel.SetActive(false);
        confirmActive = false;
    }
}
