using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;

	Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector2.up * 5;
		_renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
		if(!_renderer.isVisible) {
			Destroy(gameObject);
		}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
