using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahne_control : MonoBehaviour
{
    private score_control sc;
    private void Start()
    {
        sc = GameObject.FindObjectOfType<score_control>();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sc.ScoruSifirla();
        Time.timeScale = 1;
    }
    public void cikiss()
    {
        Application.Quit();
    }
}
