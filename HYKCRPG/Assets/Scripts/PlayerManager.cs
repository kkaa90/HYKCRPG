using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager playerManager;
    public GameObject obj;
    public int mf;
    public int ability;
    public int job; //초보자 0 / 워리어 100 / 매지션 200 / 사제 300 / 사수 400 /  
    public float currentHp;
    public float currentMp;
    public float maxHp;
    public float maxMp;
    public string nick;

    private void Awake()
    {
        if (playerManager == null)
        {
            playerManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
