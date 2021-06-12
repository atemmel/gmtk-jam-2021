using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//var translation = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f) * 0.02f;
		//transform.position = transform.position + translation;

		if (Input.GetKey(KeyCode.W)) {  
			transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f) * 0.02f;
		}  

		if (Input.GetKey(KeyCode.S)) {  
			transform.position = transform.position + new Vector3(0.0f, -1.0f, 0.0f) * 0.02f;
		}  

		if (Input.GetKey(KeyCode.A)) {  
			transform.position = transform.position + new Vector3(-1.0f, 0.0f, 0.0f) * 0.02f;
		}  

		if (Input.GetKey(KeyCode.D)) {  
			transform.position = transform.position + new Vector3(1.0f, 0.0f, 0.0f) * 0.02f;
		}  
    }
}
