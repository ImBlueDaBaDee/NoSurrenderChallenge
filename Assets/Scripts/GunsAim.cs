using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsAim : MonoBehaviour
{
    //this script is attached to : Player > Character Body > Guns > Right Gun and Left Gun.

    [SerializeField] float range;
    public LayerMask layerMask;
    public bool enemyInRange;


    Transform[] enemiesInRange;
    public Transform closestEnemyTransform;
    [SerializeField] Transform objectToRotate;

    private void Awake()
    {
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemiesInRange = FindEnemiesInRange(range, layerMask);
        enemyInRange = CheckEnemies(enemiesInRange);
        closestEnemyTransform = GetClosestEnemy(enemiesInRange);        
        AimAtEnemy(closestEnemyTransform, enemyInRange);
    }
    Transform[] FindEnemiesInRange(float range, int layerMask)
    {
        Collider[] enemiesInRangeColliders = Physics.OverlapSphere(transform.position, range, layerMask);
        Transform[] enemiesInRangeTransforms = new Transform[enemiesInRangeColliders.Length];
        for (int i = 0; i < enemiesInRangeColliders.Length; i++)
        {
            enemiesInRangeTransforms[i] = enemiesInRangeColliders[i].GetComponent<Transform>();
        }
        return enemiesInRangeTransforms;
    }
    bool CheckEnemies(Transform[] enemies)
    {
        if(enemies.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform minTransform = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform enemyTransform in enemies)
        {
            float distance = Vector3.Distance(enemyTransform.position, currentPos);
            if (distance < minDistance)
            {
                minTransform = enemyTransform;
                minDistance = distance;
            }
        }
        return minTransform;
    }
    void AimAtEnemy(Transform closestEnemy,bool enemyInRange)
    {
        if(enemyInRange)
        {
            objectToRotate.LookAt(ChangeVectorsYToObservers(closestEnemy.position));
        }
    }

    //Our character should not change it's Y rotation while looking at enemies. So we change their positions Y with our characters.
    private Vector3 ChangeVectorsYToObservers(Vector3 vectorToChange)
    {
        Vector3 changedVector = new Vector3(vectorToChange.x, transform.position.y, vectorToChange.z);
        return changedVector;
    }
   
}




