using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] float maxRange;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(startPos, transform.position);
        if (distance > maxRange) { Destroy(gameObject); }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
