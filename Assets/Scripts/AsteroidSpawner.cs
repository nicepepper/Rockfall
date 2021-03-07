using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    public float radius = 250.0f;
    public Rigidbody asteroidPrefab;
    public float spawRate = 5.0f;
    public float variance = 1.0f;
    public Transform target;
    public bool spawnAsteroids = false;

    private void Start()
    {
        StartCoroutine(CreateAsteroids());
    }

    private IEnumerator CreateAsteroids()
    {
        while (true)
        {
            float nextSpawnTime = spawRate + Random.Range(-variance, variance);
            yield return new WaitForSeconds(nextSpawnTime);
            yield return new WaitForFixedUpdate();
            CreateNewAsteroid();
        }
    }

    private void CreateNewAsteroid()
    {
        if (!spawnAsteroids)
        {
            return;
        }

        var asteroidPosition = Random.onUnitSphere * radius;
        asteroidPosition.Scale(transform.lossyScale);

        asteroidPosition += transform.position;
        var newAsteroid = Instantiate(asteroidPrefab);
        newAsteroid.transform.position = asteroidPosition;
        newAsteroid.transform.LookAt(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireSphere(Vector3.zero, radius);
    }

    public void DestroyAllAsteroids()
    {
        foreach (var asteroid in FindObjectsOfType<Asteroid>())
        {
            Destroy(asteroid.gameObject);
        }
    }
}
