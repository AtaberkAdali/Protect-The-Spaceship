using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusman_pozisyonu : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
