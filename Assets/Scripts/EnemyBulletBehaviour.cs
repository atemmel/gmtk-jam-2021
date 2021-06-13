using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
	public string[] collidableTags;
	Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
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
		foreach(var tag in collidableTags) {
			if(collision.gameObject.tag == tag) {
				Destroy(gameObject);
				break;
			}
		}
    }
}
