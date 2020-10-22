using System.Collections.Generic;
using UnityEngine;

namespace DiepMono.Managers
{
    public class Spawner : MonoBehaviour
    {
        public List<GameObject> ItemPool = new List<GameObject>();
        public List<Transform> SpawnLocations = new List<Transform>();
        int lastSpawnLocationID;

        public virtual void Spawn()
        {
            GameObject spawnedItem = ItemPool[Random.Range(0, ItemPool.Count)];
            if (spawnedItem == null)
                return;
            Instantiate(spawnedItem, transform.position, spawnedItem.transform.rotation);
        }

        public virtual void Spawn(List<Transform> locations, bool preventSameLocation = true)
        {
            GameObject spawnedItem = ItemPool[Random.Range(0, ItemPool.Count)];
            if (spawnedItem == null)
                return;
            int locationID = Random.Range(0, locations.Count);
            if (preventSameLocation && locationID == lastSpawnLocationID)
            {
                do
                {
                    locationID = Random.Range(0, locations.Count);
                } while (locationID == lastSpawnLocationID);
            }
            lastSpawnLocationID = locationID;
            Transform spawnLocation = locations[locationID];
            Instantiate(spawnedItem, spawnLocation.position, spawnedItem.transform.rotation);
        }
    } 
}
