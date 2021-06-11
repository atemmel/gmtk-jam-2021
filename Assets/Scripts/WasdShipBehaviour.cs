using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasdShipBehaviour : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D ourRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //WASD to Move        
        Vector2 inputVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        ourRigidbody.velocity = inputVector * playerSpeed;
    }
}
