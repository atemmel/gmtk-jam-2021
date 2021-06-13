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

    public float shotTimer;
    float last_shot;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.realtimeSinceStartup;
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

        // Kulor som skickas

        last_shot += Time.deltaTime;
        if (last_shot > shotTimer)
        {
            var bull = Instantiate(bullet, transform.position, transform.rotation);
            var velocity = Vector2.down * 5;
            bull.GetComponent<Rigidbody2D>().velocity = velocity;
            last_shot = 0;
            GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Space_move");
        }
        if (shotTimer - last_shot < 0.5)
        {
            GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Space_shoot");
        }
    }
}
