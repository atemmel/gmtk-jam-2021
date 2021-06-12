using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		//Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
		//transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);

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
	}
}
