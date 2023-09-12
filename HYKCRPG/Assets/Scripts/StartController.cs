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



    string[,] abilityArray = new string[4, 2] { { "안아줘요", "우주부엉이\n인가요" }, { "야추", "우주부엉이\n아닌가요" }, 
        { "놀이동산", "우주부엉이\n우주부엉이인가요" }, { "돼돌꿈동산", "돼돌돼돌\n돼돌돼돌" } };

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
        text.text = "다음과 같이 선택하셨습니다.\n 진행하시겠습니까?\n성별 : " 
            + (mf == 0 ? "남성" : "여성")
            + "\n특성 : " + abilityArray[abilityNum, 0];
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
