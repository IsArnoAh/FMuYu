using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pipe;
    public float spawnRate;
    public float timer;
    public float heightOffset;
    void Start()
    {
        spawnRate = 3;
        timer = 0;
        heightOffset = 4;
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        //每隔一段时间创建管道
        if (timer<spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }

        
    }
    void spawnPipe()
    {
        float lowestPos = transform.position.y - heightOffset;
        float highestPos = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x,Random.Range(lowestPos,highestPos),0), transform.rotation);
    }
}
