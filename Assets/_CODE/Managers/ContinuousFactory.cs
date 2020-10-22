using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousFactory : Spawner {

	public float SpawnInterval;
    public float IntervalChange;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            Spawn(SpawnLocations, true);
            yield return new WaitForSeconds(SpawnInterval);
            SpawnInterval = (SpawnInterval + IntervalChange <= 0) ?  0 : SpawnInterval + IntervalChange;
        }
    }
}
