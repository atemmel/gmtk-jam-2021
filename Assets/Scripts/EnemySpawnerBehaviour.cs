using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    public GameObject[] enemies;
    public float spawnInterval;
    //public GameObject enemy;
    public bool randomRotation;

    float collectedTime = 0.0f;

    const float spawnOffsetX = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        collectedTime += Time.deltaTime;
        if (collectedTime > spawnInterval)
        {
            float x = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(spawnOffsetX, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - spawnOffsetX, 0)).x);

            var vec = new Vector3(x, transform.position.y, transform.position.z);
            int rand = Random.Range(0, enemies.Length);
            Instantiate(enemies[rand], vec, randomRotation ? Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.forward) : Quaternion.identity);
            collectedTime = 0.0f;
        }
    }
}
