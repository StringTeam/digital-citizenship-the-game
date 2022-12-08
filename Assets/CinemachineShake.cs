using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace ST
{
    public class CinemachineShake : MonoBehaviour
    {
        public static CinemachineShake Instance { get; private set; }
        private float shakeTimer;
        private float startingIntensity;
        private float ShakeTimerTotal;
        CinemachineVirtualCamera cinemachineVirtualCamera;
        public Transform target1;
        public Transform target2;
        public Transform target3;
        public Transform player;

        private void Awake()
        {
            Instance = this;
            cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        public void ShakeCamera(float intensity, float time)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
            startingIntensity = intensity;
            ShakeTimerTotal = time;
            shakeTimer = time;
        }

        private void Update()
        {
            if (shakeTimer > 0)
            {
                shakeTimer -= Time.deltaTime;
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain =
                Mathf.Lerp(startingIntensity, 0f, (1- (shakeTimer / ShakeTimerTotal)));
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                cinemachineVirtualCamera.Follow = target1.transform;
                Time.timeScale = 0.0f;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                cinemachineVirtualCamera.Follow = target2.transform;
                Time.timeScale = 0.0f;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                cinemachineVirtualCamera.Follow = target3.transform;
                Time.timeScale = 0.0f;
            }

            if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Alpha3))
            {
                cinemachineVirtualCamera.Follow = player.transform;
                Time.timeScale = 1.0f;
            }
            
        }
    }
}
