using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public GameObject obj;
    System.Random random = new System.Random();
    float temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = random.Next(-5,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        obj.transform.Translate(new Vector2(0.005f*temp, 0));
    }
}
