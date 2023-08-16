using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
    InvokeRepeating("Fonksiyon_İsmi", ilk kez fonksiyon çağırıldıktan kaç sny sonra başlasın, fonksiyon hangi aralıklarla çağırılsın);
 */
public class uzay_gemisi : MonoBehaviour
{
    [SerializeField] float gemi_hiz=1f;
    [SerializeField] float maxXGameScane;
    [SerializeField] float minXGameScane;
    public GameObject mermi;
    public GameObject ulti_mermisi;
    [SerializeField] float mermi_araligi;
    [SerializeField] int can;
    private score_control score_sıfır;
    public int sonScor;
    private can_metini canımaBak;
    private Dusman_duzenimiz kacinci_bolum;
    [SerializeField] GameObject ulti_paneli;
    [SerializeField] GameObject lose_panel;

    public AudioClip atesSesi;
    public AudioClip olmeSesi;
    // Start is called before the first frame update
    void Start()
    {
        score_sıfır = GameObject.FindObjectOfType<score_control>();
        canımaBak = GameObject.FindObjectOfType<can_metini>();
        kacinci_bolum = GameObject.FindObjectOfType<Dusman_duzenimiz>();
    }

    void AtesEt()
    {
        AudioSource.PlayClipAtPoint(atesSesi, transform.position);
        GameObject gemiMermisi = Instantiate(mermi, transform.position, Quaternion.identity) as GameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("dusman_mermisi"))
        {
            Destroy(collision.gameObject);
            can--;
            canımaBak.canim(can);
        }
        if (can <= 0)
        {
            sonScor = score_sıfır.score;
            lose_panel.SetActive(true);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(olmeSesi, transform.position);
            Time.timeScale = 0;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (kacinci_bolum.bolum_kac % 3 == 1)
        {
            ulti_paneli.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                GameObject gemiMermisi1 = Instantiate(ulti_mermisi, transform.position, Quaternion.identity) as GameObject;
                GameObject gemiMermisi2 = Instantiate(ulti_mermisi, new Vector3(transform.position.x + 1,transform.position.y,transform.position.z), Quaternion.identity) as GameObject;
                GameObject gemiMermisi3 = Instantiate(ulti_mermisi, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
            }
        }
        else
        {
            ulti_paneli.SetActive(false);
        }
        float sonX = Mathf.Clamp(transform.position.x, minXGameScane, maxXGameScane);
        transform.position = new Vector3(sonX, transform.position.y, transform.position.z);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * gemi_hiz * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * gemi_hiz * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //InvokeRepeating("AtesEt", 0.00001f, mermi_araligi);
            AtesEt();
        }
    }
}
