using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoBehaviour : MonoBehaviour
{
    private Rigidbody2D ourRigidbody;
    public float drag; //lamo

    // Start is called before the first frame update
    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ourRigidbody.velocity = Vector2.up * -drag;
    }
}
