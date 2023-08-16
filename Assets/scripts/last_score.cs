using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class last_score : MonoBehaviour
{
    private uzay_gemisi ug;
    public Text benimMetnim;
    void Start()
    {
        benimMetnim = GetComponent<Text>();
        ug = GameObject.FindObjectOfType<uzay_gemisi>();
        benimMetnim.text = ug.sonScor.ToString();
    }

}
