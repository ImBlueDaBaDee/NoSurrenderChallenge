using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed;

    private Vector3 lastTouchPos, curTouchPos;
    public Vector3 processedInputs;

    private void FixedUpdate()
    {
        ProcessInputs(Input.mousePosition);
        MoveTheCharacter(processedInputs, moveSpeed);
    }
    void MoveTheCharacter(Vector3 input, float speed)
    {

        transform.Translate(input * speed * Time.deltaTime);

    }
    private void ProcessInputs(Vector3 mousePos)
    {
        //Substracting the first touch position from current touch position and using the result as direction. 

        if (Input.GetMouseButtonDown(0))
        {
            lastTouchPos = ChangeYToZ(mousePos);
        }
        else if (Input.GetMouseButton(0))
        {
            curTouchPos = ChangeYToZ(mousePos);
            processedInputs = (curTouchPos - lastTouchPos).normalized;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            processedInputs = Vector3.zero;
        }

        

    }

    //Touch inputs are 2d, x and y. This method changes y input to z in order to use it in a 3d enviroment.
    Vector3 ChangeYToZ(Vector3 unchanged)
    {
        Vector3 changed = new Vector3(unchanged.x, 0, unchanged.y);
        return changed;
    }
}
