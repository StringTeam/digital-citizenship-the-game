using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ST
{
    public class BoulderSpawn : MonoBehaviour
    {
        public GameObject Boulder;
        public Transform Spawnpoint;
        private bool Spawned;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.tag == "Player" && !Spawned)
            {
                Spawned = true;
                Invoke("SpawnBoulder", 0.5f);
            }
        }

     void SpawnBoulder()
        {
            Instantiate(Boulder, Spawnpoint.position, Quaternion.identity);
        }

    }
}