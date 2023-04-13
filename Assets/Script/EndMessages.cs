using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndMessages : MonoBehaviour
{
    
    public Image img;
    public Text endmessage;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        
        finishLine();
    }
    private void finishLine() {
        StartCoroutine(scoreActive());
    }
    IEnumerator scoreActive() {
        Color imgColor = Color.white;
        imgColor.a = 0;
        img.color = imgColor;

        Color txtColor = endmessage.color;
        txtColor.a = 0;
        endmessage.color = imgColor;

        for (int i = 0; i < 500; i++) {
            imgColor.a += 0.002f;
            img.color = imgColor;
            txtColor.a += 0.002f;
            endmessage.color = txtColor;
            yield return null;
        }
        yield return new WaitForSeconds(3.0f);

        //for(int j = 0; j < 100; j++) {
        //    imgColor.a -= 0.01f;
        //    img.color = imgColor;
        //    yield return null;
        //}
        
    }
}
