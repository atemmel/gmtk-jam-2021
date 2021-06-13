using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_logic : MonoBehaviour
{
	public GameObject explosionVfx;
    public int hp;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) //playerBullet layer
        {
            hp -= 1;
        }
        else if (collision.relativeVelocity.magnitude > 20)
        {
            hp -= 3;
        }

        if (hp <= 0) {
			var effect = Instantiate(explosionVfx, transform.position, Quaternion.identity);
			Destroy(effect, 0.5f);
            Destroy(gameObject);
		}
    }
}
