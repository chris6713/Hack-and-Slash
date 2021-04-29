using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float life;
    float angle;
    float speed;
    bool countdown = false;

    public void Init(float l, float a, float s)
    {
        life = l;
        angle = a;
        speed = s;
        countdown = true;

        Vector3 o_rot = gameObject.transform.eulerAngles;
        gameObject.transform.rotation = Quaternion.Euler(o_rot.x, a, o_rot.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (!countdown) return;

        // movement by keys
        Vector3 o_pos = gameObject.transform.position; // used to shorten the name length

        gameObject.transform.position = Player.PlotPointFromAngle(o_pos, gameObject.transform.eulerAngles.y, speed * Time.deltaTime);

        life -= Time.deltaTime;

        if (life <= 0)
            Destroy(gameObject);
    }
}
