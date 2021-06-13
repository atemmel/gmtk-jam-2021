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

	AudioSource shootSound;

    // Start is called before the first frame update
    void Start()
    {
       
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = new Vector2(sideSpeed, -downSpeed);
		shootSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 18 || transform.position.x < -18)
        {
            sideSpeed *= -1;
        }

        _rigidbody2D.velocity = new Vector2(sideSpeed, -downSpeed);
        timer += Time.deltaTime;
        // Kulor som skickas
        
        if(timer >= 2.0f)
        {
            var bull = Instantiate(bullet, transform.position, transform.rotation);
            var velocity = Vector2.down * 5;
            bull.GetComponent<Rigidbody2D>().velocity = velocity;
            
            timer = 0.0f;
        }
    }
}
