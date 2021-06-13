using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_logic : MonoBehaviour
{
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
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 6) //playerBullet layer
        {
            hp -= 1;
        }
        else if (collision.relativeVelocity.magnitude > 20)
        {
            hp -= 3;
        }

        if (hp <= 0)
            Destroy(gameObject);

        if (GetComponent<Rigidbody2D>().velocity.magnitude > 10)
            Debug.Log(GetComponent<Rigidbody2D>().velocity.magnitude);
    }
}