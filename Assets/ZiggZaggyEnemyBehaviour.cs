using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiggZaggyEnemyBehaviour : MonoBehaviour
{

    Rigidbody2D _rigidbody2D;
    public GameObject bullet;

    public float downSpeed;
    public float sideSpeed;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.realtimeSinceStartup;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = new Vector2(sideSpeed, -downSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 18 || transform.position.x < -18)
        {
            sideSpeed *= -1;
        }

        _rigidbody2D.velocity = new Vector2(sideSpeed, -downSpeed);

        // Kulor som skickas
        if (Time.realtimeSinceStartup - timer > 2)
        {
            var bull = Instantiate(bullet, transform.position, transform.rotation);
            var velocity = Vector2.down * 5;
            bull.GetComponent<Rigidbody2D>().velocity = velocity;
            timer = Time.realtimeSinceStartup;
        }
    }
}
