using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class stopwatch : MonoBehaviour
{
    public float min, sec, milisec, currentTime = 0;
    public int k = 0;
    public Text txt;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(k % 2 != 0 & k<=2 ) {
            currentTime += Time.deltaTime;
            min = Mathf.Floor(currentTime / 60);
            sec = currentTime % 60;
            txt.text = string.Format("{0:00}:{1:00.00}",min,sec); }        
    }
    private void OnTriggerEnter(Collider other) {
        k++;
    }
}
