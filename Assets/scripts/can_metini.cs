using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class can_metini : MonoBehaviour
{
    public Text canMetnim;
    private void Start()
    {
        canMetnim = GetComponent<Text>();
    }
    public void canim(int cann)
    {
        canMetnim.text = cann.ToString();
    }
}
