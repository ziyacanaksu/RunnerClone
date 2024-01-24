using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 MousePos = new Vector3();
    [SerializeField] private int HorizontalSpeed;
    [SerializeField] private int VerticalSpeed;




    // Update is called once per frame
    void Update()
    {
        InitialPos();
        SwipeThrough();
    }

    private void InitialPos(){
        if(Input.GetMouseButtonDown(0)){
            MousePos = Input.mousePosition;

        }
    }
private void SwipeThrough(){
    if(Input.GetMouseButton(0)){
        
        Vector3 Difference = MousePos - Input.mousePosition;
        MousePos = Input.mousePosition;

        // Calculate new position
        Vector3 newPosition = transform.position + new Vector3(-Difference.x * HorizontalSpeed, 0, 1 * VerticalSpeed) * Time.deltaTime;

        // Clamp the x position to be between -2 and 2
        newPosition.x = Mathf.Clamp(newPosition.x, -2f, 2f);

        // Apply the new position
        transform.position = newPosition;

        //Debug.Log(Difference);
    }
}
}
