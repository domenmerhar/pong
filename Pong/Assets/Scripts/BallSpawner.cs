using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    public void SpawnBall()
    {
        Vector3 spawnPosition = new Vector3(0f, UnityEngine.Random.Range(-4.6f, 4.6f), 0); //Teleports ball
        Instantiate(ballPrefab, spawnPosition, transform.rotation);
    }
}
