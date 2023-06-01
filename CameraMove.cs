using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public Vector2 minCameraBoundary; // 카메라의 최소 경계
    public Vector2 maxCameraBoundary; // 카메라의 최대 경계

    private Vector3 desiredPosition; // 원하는 카메라 위치
    private Vector3 smoothDampVelocity; // 부드러운 이동을 위한 속도 변수
    public float smoothTime = 0.3f; // 부드러운 이동에 사용되는 시간

    private bool isCameraFixed = true; // 카메라가 고정되어 있는지 여부

    public void SetCameraFixed(bool fixedState)
    {
        isCameraFixed = fixedState;
    }

    public void SetCameraBounds(Vector2 minBoundary, Vector2 maxBoundary)
    {
        minCameraBoundary = minBoundary;
        maxCameraBoundary = maxBoundary;
    }

    private void LateUpdate()
    {
        if (isCameraFixed)
        {
            // 고정된 카메라 위치 계산
            float posX = (minCameraBoundary.x + maxCameraBoundary.x) / 2f;
            float posY = (minCameraBoundary.y + maxCameraBoundary.y) / 2f;
            desiredPosition = new Vector3(posX, posY, transform.position.z);

            // 카메라 위치 이동
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref smoothDampVelocity, smoothTime);
        }
        else if (player != null)
        {
            // 플레이어와 카메라 사이의 중간 위치 계산
            float posX = Mathf.Clamp(player.position.x, minCameraBoundary.x, maxCameraBoundary.x);
            float posY = Mathf.Clamp(player.position.y, minCameraBoundary.y, maxCameraBoundary.y);
            desiredPosition = new Vector3(posX, posY, transform.position.z);

            // 부드러운 이동을 위해 SmoothDamp 함수 사용
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref smoothDampVelocity, smoothTime);
        }
    }
}