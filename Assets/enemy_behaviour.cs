using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{

    public GameObject player;
    int curr_dir = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Get difference in position
        Vector3 pos_diff = getPositionDiff();

        if (pos_diff.magnitude < 3 && curr_dir == 1)
            curr_dir = -1;
        else if (pos_diff.magnitude > 5 && curr_dir == -1)
            curr_dir = 1;

        transform.position += curr_dir*(pos_diff / 4 * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, 0, -getAngle());

    }
    Vector3 getPositionDiff()
    {
        return player.transform.position - transform.position;
    }
    float getAngle()
    {
        return Vector3.Angle(transform.position, player.transform.position);
    }
}
