using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShipBehaviour : MonoBehaviour
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
        //Move to mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 directionToMouse = (mousePosition - transform.position).normalized;
        ourRigidbody.velocity = directionToMouse * playerSpeed;
    }
}
