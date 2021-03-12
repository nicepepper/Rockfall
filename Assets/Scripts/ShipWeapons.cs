using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapons : MonoBehaviour
{
    public GameObject shotPrefab;

    public void Awake()
    {
        InputManager.instance.SetWeapons(this);
    }

    public void OnDestroy()
    {
        if (Application.isPlaying == true)
        {
            InputManager.instance.RemoveWeapons(this);
        }
    }

    public Transform[] firePoints;
    private int _firePointIndex;

    public void Fire()
    {
        if (firePoints.Length == 0)
        {
            return;
        }

        var firePointToUse = firePoints[_firePointIndex];
        
        Instantiate(
            shotPrefab,
            firePointToUse.position,
            firePointToUse.rotation);

        var audio = firePointToUse.GetComponent<AudioSource>();
        if (audio)
        {
            audio.Play();
        }

        _firePointIndex++;
        if (_firePointIndex >= firePoints.Length)
        {
            _firePointIndex = 0;
        }
    }
}
