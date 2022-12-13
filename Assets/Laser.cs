using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ST
{
    public class Laser : MonoBehaviour
    {
        public GameObject Sparks;
        public Transform ParticleSystemTransform;

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))                        
            {
                ParticleSystem Particle = Sparks.GetComponent<ParticleSystem>();    
                Particle.Play();                                                   
            }
        }
    }
}
