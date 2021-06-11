using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    float speed = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward*speed*Input.GetAxis("Vertical")*Time.deltaTime;
        transform.position += Vector3.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime;
    }
}
