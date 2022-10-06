using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;

    [Header("Pipe Spawn Values")]
    public float pipeSpawnRate = 1f;
    public float pipeMinSpawnHeight = -1f;
    public float pipeMaxSpawnHeight = 1f;

    private void OnEnable() 
    {
        InvokeRepeating(nameof(Spawn), pipeSpawnRate, pipeSpawnRate);
    }

    private void OnDisable() 
    {
        CancelInvoke(nameof(Spawn));
    }

    public void Spawn()
    {
        GameObject pipes = Instantiate(pipePrefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(pipeMinSpawnHeight, pipeMaxSpawnHeight);
    }
}
