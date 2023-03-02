using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraShake : MonoBehaviour
{
    [Header("Screenshake")]
    [SerializeField] private CameraShakeData defaultShakeData;

    private CinemachineVirtualCamera _virtualCamera;
    private CinemachineBasicMultiChannelPerlin _cameraNoise;

    private void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();

        if (_virtualCamera != null)
        {
            _cameraNoise = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
    }

    /// <summary>
    /// Start camera shake with default values
    /// </summary>
    public void StartCameraShake()
    {
        StopAllCoroutines();
        if (defaultShakeData.infiniteDuration) SetNoiseValues();
        else StartCoroutine(CameraShakeCoroutine());
    }

    /// <summary>
    /// Start camera shake with specific values
    /// </summary>
    public void StartCameraShake(CameraShakeData shakeData)
    {
        StopAllCoroutines();
        if (shakeData.infiniteDuration) SetNoiseValues(shakeData);
        else StartCoroutine(CameraShakeCoroutine(shakeData));
    }

    private void SetNoiseValues()
    {
        _cameraNoise.m_AmplitudeGain = defaultShakeData.amplitude;
        _cameraNoise.m_FrequencyGain = defaultShakeData.frequency;
    }

    private void SetNoiseValues(CameraShakeData shakeData)
    {
        _cameraNoise.m_AmplitudeGain = shakeData.amplitude;
        _cameraNoise.m_FrequencyGain = shakeData.frequency;
    }

    private IEnumerator CameraShakeCoroutine()
    {
        SetNoiseValues();
        yield return new WaitForSecondsRealtime(defaultShakeData.duration);
        StopCameraShake();
    }

    private IEnumerator CameraShakeCoroutine(CameraShakeData shakeData)
    {
        SetNoiseValues(shakeData);
        yield return new WaitForSecondsRealtime(shakeData.duration);
        StopCameraShake();
    }

    /// <summary>
    /// Stop camera shake
    /// </summary>
    public void StopCameraShake()
    {
        StopAllCoroutines();
        _cameraNoise.m_AmplitudeGain = 0f;
    }
}

[Serializable]
public struct CameraShakeData
{
    public float amplitude;
    public float frequency;
    public bool infiniteDuration;
    public float duration;

    public CameraShakeData(float amplitude, float frequency, bool infiniteDuration, float duration)
    {
        this.amplitude = amplitude;
        this.frequency = frequency;
        this.infiniteDuration = infiniteDuration;
        this.duration = duration;
    }
}

