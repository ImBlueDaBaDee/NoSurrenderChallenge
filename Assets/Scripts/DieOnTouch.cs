using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Die
            GameManager.Instance.Restart();
        }
    }
}
