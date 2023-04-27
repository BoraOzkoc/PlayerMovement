using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private float targetSpeed;
    private float _currentSpeed;
    void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        
        LookTowardsDirection(direction);

        IncreaseSpeed();
        transform.position += direction * Time.deltaTime * _currentSpeed;
        //Debug.Log("move called");
    }
    

    private void LookTowardsDirection(Vector3 dir)
    {
        transform.LookAt(transform.position + dir);
    }

    private void IncreaseSpeed()
    {
        if (variableJoystick.Vertical == 0 && variableJoystick.Horizontal == 0) ResetSpeed();
        else
        {
            if (_currentSpeed < targetSpeed) _currentSpeed += 0.07f;

        }
    }

    private void ResetSpeed()
    {
        _currentSpeed = 0;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ResetSpeed();
    }
}
