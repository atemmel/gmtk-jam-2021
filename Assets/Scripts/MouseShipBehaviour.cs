using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShipBehaviour : MonoBehaviour
{
    public float acceleration;
    private Rigidbody2D ourRigidbody;
    private Vector2 directionToMouse;

    // Start is called before the first frame update
    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {

        //Move to mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //directionToMouse = (mousePosition - transform.position).normalized;
        //ourRigidbody.velocity = directionToMouse * playerSpeed;

        directionToMouse = Vector2.zero;
        if (Input.GetMouseButton(0))
        {
            directionToMouse = (mousePosition - transform.position).normalized;
        }


    }


    private void FixedUpdate()
    {
        ourRigidbody.AddForce(directionToMouse * acceleration);
    }
}
