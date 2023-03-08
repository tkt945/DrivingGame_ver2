using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thruDragonGate : MonoBehaviour
{
    
    public Image img;
    public AudioSource BingChillin, win;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void doingWell() {
        StartCoroutine(scoreActive());
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("trigger entered");
        doingWell();
        
    }

    IEnumerator scoreActive() {
        BingChillin.Play();
        win.Play();
        Color imgColor = Color.white;
        RectTransform rect;
        float banner_moving_step = 2f; 
        rect = img.rectTransform;
        img.color = imgColor;

        for(int i = 0; i < 100; i++) {
            //rect.localPosition.y += .01f;
            img.rectTransform.localPosition += new Vector3(0, banner_moving_step, 0);
            yield return null;
        }
        yield return new WaitForSeconds(3.0f);
        
        for(int j = 0; j <100; j++) {
            imgColor.a -= 0.01f;
            img.color = imgColor;
            yield return null;
        }
        img.rectTransform.localPosition -= new Vector3(0,100*banner_moving_step, 0);
    }
}
