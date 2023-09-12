using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    public string targetScene;
    public int targetNum;
    bool portalActive;
    private PlayerInput player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (portalActive)
            {
                player.currentMap = targetScene;
                player.portalNum = targetNum;
                player.rigid.velocity = Vector2.zero;
                SceneManager.LoadScene(targetScene);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            portalActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            portalActive = false;
        }
    }
}
