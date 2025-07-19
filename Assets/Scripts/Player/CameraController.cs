using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] ParticleSystem speedUpParticleSystem; 
    [SerializeField] float minFov = 35f; 
    [SerializeField] float maxFov = 85f;
    [SerializeField] float zoomDuration = 5f;
    [SerializeField] float zoomSpeedModifier =  5f;

    CinemachineCamera cinemachineCamera;

    void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }
    public void ChangeCameraFov(float speed)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOV(speed));
        if (speed > 0)
        {
            speedUpParticleSystem.Play();
        }
    }
    IEnumerator ChangeFOV(float speed)
    {
        float startPosition = cinemachineCamera.Lens.FieldOfView;
        float targetPosition = Mathf.Clamp(startPosition + speed * zoomSpeedModifier, minFov, maxFov);
        float elapseTime = 0f;

        while (elapseTime < zoomDuration)
        {
            float t = elapseTime / zoomDuration;
            elapseTime += Time.deltaTime;
            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startPosition, targetPosition, t);
            yield return null;
        }
        cinemachineCamera.Lens.FieldOfView = targetPosition;
    }
}