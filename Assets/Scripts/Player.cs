using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInputs gameInputs;

    private bool isWalking;

    private void Update()
    {
        Vector2 inputVector = gameInputs.GetMovementVectorNormalized();
        
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        transform.position += moveDir * moveSpeed * Time.deltaTime;
        isWalking=moveDir!=Vector3.zero;

        //Smooth Rotation 
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed*Time.deltaTime);

        Debug.Log(inputVector);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
