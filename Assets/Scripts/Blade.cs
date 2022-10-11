using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelocity = 0.1f;
    private Rigidbody2D rb;
    private Vector3 lastMousePosition;
    private Vector3 mouseVelocity;
    private Collider2D collider2D;

    // Awake is called before the first frame update and Start method
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        collider2D.enabled = IsMouseMoving();
        SetBladeToMouse();
    }

    
    private void SetBladeToMouse()
    {
        var mousePostion = Input.mousePosition;
        mousePostion.z = 20;
        rb.position = Camera.main.ScreenToWorldPoint(mousePostion);
    }

    private bool IsMouseMoving()
    {
        Vector3 currentMousePosition = transform.position;
        float traveled = (lastMousePosition - currentMousePosition).magnitude;
        lastMousePosition = currentMousePosition;
        if (traveled > minVelocity)
        {
            return true;
        }
        return false;
    }

}
