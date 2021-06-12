using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCrosshair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, transform.position.z);
        //transform.position = mouseWorldPosition;

        /*
		if (Input.GetKey(KeyCode.UpArrow)) {  
			transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f) * 0.02f;
		}  

		if (Input.GetKey(KeyCode.DownArrow)) {  
			transform.position = transform.position + new Vector3(0.0f, -1.0f, 0.0f) * 0.02f;
		}  

		if (Input.GetKey(KeyCode.LeftArrow)) {  
			transform.position = transform.position + new Vector3(-1.0f, 0.0f, 0.0f) * 0.02f;
		}  

		if (Input.GetKey(KeyCode.RightArrow)) {  
			transform.position = transform.position + new Vector3(1.0f, 0.0f, 0.0f) * 0.02f;
		}  
		*/
    }
}
