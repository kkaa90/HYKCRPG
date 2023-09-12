using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        color = gameObject.GetComponent<TextMeshProUGUI>().color;
        StartCoroutine(DecreaseAlpha());
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        gameObject.transform.Translate(new Vector2(0.01f,0.01f));
    }
    IEnumerator DecreaseAlpha()
    {
        for (float i = 1; i>=0; i -= 0.05f)
        {
            color.a = i;
            gameObject.GetComponent<TextMeshProUGUI>().color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
