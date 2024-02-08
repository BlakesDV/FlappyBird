using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenPipes;

    private float timer;
    private PoolScript pipePool;

    void Start()
    {
        timer = timeBetweenPipes;
        pipePool = GetComponent<PoolScript>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenPipes)
        {
            GameObject obj = pipePool.RequestObject();

            float randY = Random.Range(2.33f, -2.33f);
            obj.transform.position = new Vector3(transform.position.x, randY, 0);
            timer = 0;
        }
    }
}
