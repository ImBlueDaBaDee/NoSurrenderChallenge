using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform muzzleTransform;
    private GunsAim gunsAimScript;
    
    [SerializeField] float force, shootDelay;
    private float elapsed = 0f;
    private void Start()
    {
        gunsAimScript = GetComponent<GunsAim>();
    }
    void Update()
    {
        if (gunsAimScript.enemyInRange)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= shootDelay)
            {
                elapsed %= shootDelay;
                ShootBullets(force);
            }
        }
    }
    void ShootBullets(float force)
    {
        GameObject bulletInstance = Instantiate(Resources.Load("bullet", typeof(GameObject)),muzzleTransform.position, muzzleTransform.rotation) as GameObject;
        bulletInstance.GetComponent<Rigidbody>().AddForce(muzzleTransform.forward * force);
    }
}
