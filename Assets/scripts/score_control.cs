using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_control : MonoBehaviour
{
    public int score;
    public Text benimMetnim;
    private void Start()
    {
        benimMetnim = GetComponent<Text>();
        benimMetnim.text = score.ToString();
    }
    public void ScoruArttir(int puan)
    {
        score += puan;
        benimMetnim.text = score.ToString();
    }
    public void ScoruSifirla()
    {
        score = 0;
        benimMetnim.text = score.ToString();
    }
}
