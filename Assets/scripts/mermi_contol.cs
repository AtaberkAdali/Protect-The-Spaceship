using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi_contol : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y>7 || gameObject.transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }
}
