using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_sheka : MonoBehaviour
{
    private CinemachineVirtualCamera _cameraVirtual;
    private float sheka_time;
    public static camera_sheka instance { get;private set; }
    private void Awake()
    {
        instance = this;
        _cameraVirtual = GetComponent<CinemachineVirtualCamera>();
    }
    public void Sheka(float intensity,float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = _cameraVirtual.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        sheka_time = time;
    }
    private void Update()
    {
        if (sheka_time >0)
        {
            sheka_time -= Time.deltaTime;
            if(sheka_time <= 0) {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = _cameraVirtual.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
