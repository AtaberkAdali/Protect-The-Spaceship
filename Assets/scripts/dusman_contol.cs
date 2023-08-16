using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusman_contol : MonoBehaviour
{
    [SerializeField] int can;
    public GameObject dusmanin_mermisi;
    private int maxValue;
    private Dusman_duzenimiz mermimm;
    private int rasgelee;
    public int score_değeri=200;
    private score_control scorum;

    public AudioClip atesSesi;
    public AudioClip olmeSesi;
    // Start is called before the first frame update
    void Start()
    {
        mermimm = GameObject.FindObjectOfType<Dusman_duzenimiz>();
        maxValue = (can * 250 / mermimm.atesEtmeHizi);
        scorum = GameObject.FindObjectOfType<score_control>();
    }
    void AtesEt()
    {
        AudioSource.PlayClipAtPoint(atesSesi, transform.position);
        GameObject dusmanMermisi = Instantiate(dusmanin_mermisi, transform.position, Quaternion.identity) as GameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gemi_mermisi"))
        {
            Destroy(collision.gameObject);
            can--;
            maxValue = (can * 250 / mermimm.atesEtmeHizi);
        }
        if (collision.gameObject.CompareTag("ulti_mermisi"))
        {
            Destroy(collision.gameObject);
            can=can-3;
            maxValue = (can * 250 / mermimm.atesEtmeHizi);
        }
        if (can <= 0)
        {
            AudioSource.PlayClipAtPoint(olmeSesi, transform.position);

            scorum.ScoruArttir(score_değeri);
            if (can <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        rasgelee = Random.Range(0, maxValue);
        if(rasgelee == 1)
        {
            AtesEt();
        }
    }
}
