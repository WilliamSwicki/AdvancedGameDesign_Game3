using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockPuddle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().isStuned = true;
        }
    }
}
