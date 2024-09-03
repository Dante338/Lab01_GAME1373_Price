using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class Spinning : MonoBehaviour
{
    public float Speed = 5f;

    public bool isRotating = false;

    public float startMousePosition;

    Touchscreen touch = Touchscreen.current;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            startMousePosition = Input.mousePosition.x;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        if(touch.press.wasPressedThisFrame)
        {
            isRotating = true;
        }
        if(touch.press.wasReleasedThisFrame)
        {
            isRotating = false;
        }

        if(isRotating)
        {
            float currentMousePosition = Input.mousePosition.x;
            float mouseMovement = currentMousePosition - startMousePosition;

            transform.Rotate(Vector3.up, mouseMovement * Speed * Time.deltaTime);
            startMousePosition = currentMousePosition;
        }
    }
}
