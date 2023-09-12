using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController cameraInstance;
    public GameObject target;
    public float moveSpeed = 5.0f;
    private Vector3 targetPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        if(cameraInstance == null) {
            cameraInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed*Time.deltaTime);
        }
    }
}
