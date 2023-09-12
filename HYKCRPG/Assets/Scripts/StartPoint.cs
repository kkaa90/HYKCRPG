using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint;
    public int portalNum;
    private PlayerInput player;
    private CameraController cameraController;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerInput>();
        cameraController = FindObjectOfType<CameraController>();
        if(startPoint == player.currentMap&&portalNum == player.portalNum)
        {
            player.transform.position  = this.transform.position;
            cameraController.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, cameraController.transform.position.z); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
