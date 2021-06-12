using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasdShipBehaviour : MonoBehaviour
{
    public float acceleration;
    private Rigidbody2D ourRigidbody;
    private Vector2 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //WASD to Move        
        inputVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        //ourRigidbody.velocity = inputVector * playerSpeed;

        //ourRigidbody.AddForce(inputVector * acceleration);
    }

    private void FixedUpdate()
    {
        ourRigidbody.AddForce(inputVector * acceleration);
    }
}
