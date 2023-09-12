using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour
{
    public float currentHp;
    public float maxHp;
    System.Random random = new System.Random();

    Rigidbody2D rigid;

    Vector3 cScale;
    public Canvas canvas;
    public Slider slider;
    public GameObject canvasPos;
    public GameObject posStart;
    public GameObject posEnd1;
    public GameObject prefab;


    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        prefab = Resources.Load<GameObject>("Prefabs/Damage");
        cScale = canvas.transform.localScale;
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //canvas.GetComponent<RectTransform>().transform.position = Camera.main.WorldToScreenPoint(canvasPos.transform.position);
        canvas.GetComponent<RectTransform>().transform.position = canvasPos.transform.position;
        slider.value = (float)currentHp/ maxHp;
    }

    private void FixedUpdate()
    {

        canvas.transform.localScale = gameObject.transform.localScale.x > 0 ? cScale : new Vector3(cScale.x*(-1),cScale.y,cScale.z);
    }

    public void HpDecrease()
    {
        GameObject test = Instantiate(prefab, canvas.transform);
        test.transform.position = posStart.transform.position;
        float temp = random.Next(10, 20);
        test.GetComponent<TextMeshProUGUI>().text = temp.ToString();
        test.AddComponent<DamageController>();
        
        StartCoroutine(textMove(test));
        currentHp -= temp;
        if(currentHp <= 0)
        {
            Destroy(gameObject);
            
        }
    }

    IEnumerator textMove(GameObject t)
    {
        
        yield return new WaitForSeconds(2.0f);
        Destroy(t.gameObject);
    }
}
