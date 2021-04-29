using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet ref_bullet;

    public float TurnSpeed = 300;
    public float MoveSpeed = 100;
    public float Bullet_Speed = 100;
    public float Bullet_Life = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // movement by keys
        Vector3 o_pos = gameObject.transform.position; // used to shorten the name length
        Vector3 o_rot = gameObject.transform.eulerAngles;

        Vector2 direction = CheckArrowKeyMove();

        if (direction.y != 0)
            gameObject.transform.position = PlotPointFromAngle(o_pos, o_rot.y, direction.y * MoveSpeed * Time.deltaTime);

        gameObject.transform.rotation = Quaternion.Euler(o_rot.x, o_rot.y + direction.x * Time.deltaTime * TurnSpeed, o_rot.z);

        o_pos = gameObject.transform.position; // update these
        o_rot = gameObject.transform.eulerAngles;

        // mouse input
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(ref_bullet.gameObject, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

            go.SetActive(true);

            go.transform.position = PlotPointFromAngle(o_pos, o_rot.y, 1);

            go.GetComponent<Bullet>().Init(Bullet_Life, o_rot.y, Bullet_Speed);

            //Debug.Log("Pressed primary button.");
        }
    }

    public Vector2 CheckArrowKeyMove()
    {
        Vector2 arrowkeymove = Vector2.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            arrowkeymove.y = 1;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            arrowkeymove.x = 1;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            arrowkeymove.y = -1;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            arrowkeymove.x = -1;

        return arrowkeymove;
    }

    public static Vector3 PlotPointFromAngle(Vector3 start, float angle, float distance)
    {
        float radians = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(radians);
        float z = Mathf.Sin(radians);
        return new Vector3(start.x + x * distance * -1, start.y, start.z + z * distance);
    }
}
