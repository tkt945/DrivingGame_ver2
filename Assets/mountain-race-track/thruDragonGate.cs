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
        img.color = imgColor;        
        yield return new WaitForSeconds(3.0f);
        for(int j = 0; j <100; j++) {
            imgColor.a -= 0.01f;
            img.color = imgColor;
            yield return null;
        }
    }
}
