using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Value : MonoBehaviour
{
    public int value;
    private Text t;
    
    void Start() {
        t = this.transform.GetChild(0).GetComponent<Text>();
        t.text = value.ToString();
    }    
}
