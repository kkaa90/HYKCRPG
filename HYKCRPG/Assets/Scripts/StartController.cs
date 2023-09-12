using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    public GameObject canvas;
    public GameObject confirmJob;
    
    public TextMeshProUGUI text;

    public TextMeshProUGUI abilityTitle;
    public TextMeshProUGUI abilityContext;

    public Button maleButton;
    public Button femaleButton;



    string[,] abilityArray = new string[4, 2] { { "�Ⱦ����", "���ֺξ���\n�ΰ���" }, { "����", "���ֺξ���\n�ƴѰ���" }, 
        { "���̵���", "���ֺξ���\n���ֺξ����ΰ���" }, { "�ŵ��޵���", "�ŵ��ŵ�\n�ŵ��ŵ�" } };

    public int mf;
    public int abilityNum;
    
    // Start is called before the first frame update
    void Start()
    {
        confirmJob.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "������ ���� �����ϼ̽��ϴ�.\n �����Ͻðڽ��ϱ�?\n���� : " 
            + (mf == 0 ? "����" : "����")
            + "\nƯ�� : " + abilityArray[abilityNum, 0];
        if (mf == 0)
        {
            maleButton.GetComponent<Image>().color = new Color(1f, 1f, 200 / 255f, 1f);
            femaleButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            maleButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            femaleButton.GetComponent<Image>().color = new Color(1f, 1f, 200 / 255f, 1f);
        }
        abilityTitle.text = abilityArray[abilityNum, 0];
        abilityContext.text = abilityArray[abilityNum, 1];
    }
    public void ChangeLeft()
    {
        if(abilityNum == 0)
        {
            abilityNum = 3;
        }
        else
        {
            abilityNum--;
        }
    }
    public void ChangeRight()
    {
        if (abilityNum == 3)
        {
            abilityNum = 0;
        }
        else
        {
            abilityNum++;
        }
    }
    public void selectMale()
    {
        mf = 0;
    }
    public void selectFemale()
    {
        mf = 1;
    }

    public void ActiveConfirm()
    {
        confirmJob.SetActive(true);
    }

    public void GoMainMenu()
    {
        Destroy(PlayerManager.playerManager.gameObject);
        SceneManager.LoadScene("MainMenuScene");
    }

    public void CancelScreen()
    {
        confirmJob.SetActive(false);
    }

    public void StartGame()
    {
        PlayerManager p = PlayerManager.playerManager;
        p.mf = mf;
        p.ability = abilityNum;
        p.maxHp = 100;
        p.maxMp = 100;
        p.currentHp = 100;
        p.currentMp = 100; 
        SceneManager.LoadScene("TutorialScene");
    }
}
