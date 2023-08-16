using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman_duzenimiz : MonoBehaviour
{
    public GameObject dusmanPrefabi;
    [SerializeField] float en;
    [SerializeField] float boy;
    [SerializeField] float hiz = 6f;
    private bool sagaHareket=true;
    private float xmin;
    private float xmax;
    public int atesEtmeHizi;
    public float gecikmeSuresi;
    public int bolum_kac=1;
    // Start is called before the first frame update
    void Start()
    {
        float kameraIleObjeZFarki = transform.position.z - Camera.main.transform.position.z;
        Vector3 kameraninSagi = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, kameraIleObjeZFarki));
        Vector3 kameraninSolu = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, kameraIleObjeZFarki));
        xmin = kameraninSolu.x;
        xmax = kameraninSagi.x;
        DusmanlarinTekTekOlusturulmasi();
    }
    /*void DusmanlarinYaratilmasi()
    {
        foreach (Transform cocuk in transform)
        {
            GameObject dusman = Instantiate(dusmanPrefabi, cocuk.transform.position, Quaternion.identity) as GameObject;
            dusman.transform.parent = cocuk;
        }
    }*/

    void DusmanlarinTekTekOlusturulmasi()
    {
        Transform uygunPozisyon = SonrakiUygunPosition();
        if (uygunPozisyon)
        {
            GameObject dusman = Instantiate(dusmanPrefabi, uygunPozisyon.transform.position, Quaternion.identity) as GameObject;
            dusman.transform.parent = uygunPozisyon;
        }
        if (SonrakiUygunPosition())
        {
            Invoke("DusmanlarinTekTekOlusturulmasi", gecikmeSuresi);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(en, boy));
    }

    // Update is called once per frame
    void Update()
    {
        if (sagaHareket)
        {
            //transform.position = new Vector3(hiz * Time.deltaTime, 0);
            transform.position += Vector3.right * hiz * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * hiz * Time.deltaTime;
        }
        float sağSinir = transform.position.x + en/2;
        float solSinir = transform.position.x - en/2;
        if(sağSinir>xmax)
        {
            sagaHareket = false;
        }
        else if(solSinir < xmin)
        {
            sagaHareket = true;
        }

        if (ButunDusmanlarOlduMu())
        {
            DusmanlarinTekTekOlusturulmasi();
            atesEtmeHizi++;
            bolum_kac++;
        }
    }

    Transform SonrakiUygunPosition()
    {
        foreach (Transform cocuklarınPozisyonu in transform)
        {
            if (cocuklarınPozisyonu.childCount == 0)
            {
                return cocuklarınPozisyonu;
            }
        }
        return null;
    }

    bool ButunDusmanlarOlduMu()
    {
        foreach(Transform cocuklarınPozisyonu in transform)
        {
            if(cocuklarınPozisyonu.childCount>0){
                return false;
            }
        }
        return true;
    }
}
