using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YankLink : MonoBehaviour
{
    public AudioSource yankSound;
    public GameObject linkToYank;
    public CargoScript cargo;
    public string keyToPress;
    public float timeBetweenYanks;

    const float yankMag = 20.0f;

    Rigidbody2D originBody, bodyToYank, body2ToYank;
    Vector2 offset;

    float timeSinceLastYank;


    // Start is called before the first frame update
    void Start()
    {
        var linkOrigin = linkToYank.gameObject.transform.GetChild(0).gameObject;
        var firstSegmentInLink = linkToYank.gameObject.transform.GetChild(1).gameObject;
        var secondSegmentInLink = linkToYank.gameObject.transform.GetChild(2).gameObject;
        originBody = linkOrigin.GetComponent<Rigidbody2D>();
        bodyToYank = firstSegmentInLink.GetComponent<Rigidbody2D>();
        body2ToYank = secondSegmentInLink.GetComponent<Rigidbody2D>();
        timeSinceLastYank = timeBetweenYanks;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastYank += Time.deltaTime;
        if (!cargo.IsAlive())
        {
            return;
        }
        if (Input.GetButtonDown(keyToPress) && timeSinceLastYank >= timeBetweenYanks)
        {
            var delta = originBody.position - body2ToYank.position;
            offset = delta * yankMag;
            bodyToYank.MovePosition(bodyToYank.position + offset);
            body2ToYank.MovePosition(body2ToYank.position + offset);
            yankSound.Play();
            timeSinceLastYank = 0;
        }
    }
}
