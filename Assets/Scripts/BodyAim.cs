using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAim : MonoBehaviour
{
    [SerializeField] PlayerMovement movementScript;
    Transform leftGunTarget;
    Transform rightGunTarget;
    Vector3 processedInputs;

    private void Start()
    {
        
    }
    void Update()
    {
        processedInputs = movementScript.processedInputs;
        FaceMiddleOfEnemies();
    }
    void FaceMiddleOfEnemies()
    {
        //Both guns have their own targets. If these targets aren't the same. Makes character look into middle of them.
        leftGunTarget = GameObject.Find("LeftGun").GetComponent<GunsAim>().closestEnemyTransform;
        rightGunTarget = GameObject.Find("RightGun").GetComponent<GunsAim>().closestEnemyTransform;
        if(leftGunTarget && rightGunTarget)
        {
            if (leftGunTarget != rightGunTarget)
            {
                Vector3 middlePos = (leftGunTarget.position + rightGunTarget.position) / 2;
                transform.LookAt(middlePos);
            }
            else
            {
                transform.LookAt(leftGunTarget);
            }
        }
        //And if there are no enemies in range. Makes character face to direction it is moving.
        else if(leftGunTarget ==null && rightGunTarget==null)
        {
            if(processedInputs != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(processedInputs);
            }
        }
        
        
    }
}
