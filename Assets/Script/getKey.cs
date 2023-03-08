using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;

public class getKey : MonoBehaviour
{
    public Text m_Text, axis_v, axis_h, axis_f1;

    // Start is called before the first frame update
    void Start()
    {
        m_Text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        var allKeys = System.Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>();
        foreach (var key in allKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Debug.Log(key);
                m_Text.text = key.ToString();
            }

            if (Input.GetKeyUp(key))
            {
                m_Text.text = "";
            }
        }
        axis_v.text = Convert.ToString(Input.GetAxis("Vertical"));
        axis_h.text = Convert.ToString(Input.GetAxis("Horizontal"));
        axis_f1.text = Convert.ToString(Input.GetAxis("Fire1"));
    }
}