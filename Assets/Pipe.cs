using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    private float _deadZone = -10;
    void Start()
    {
        moveSpeed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position+(Vector3.left*moveSpeed)*Time.deltaTime;
        if (transform.position.x<_deadZone)
        {
            Destroy(gameObject);
        }
    }
}
