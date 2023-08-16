using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi_dondur : MonoBehaviour
{
    private Vector3 defaultLocalScale;
    private void Start()
    {
        defaultLocalScale = transform.localScale;
        transform.localScale = new Vector3(defaultLocalScale.x, -defaultLocalScale.y, defaultLocalScale.z);
    }

}
