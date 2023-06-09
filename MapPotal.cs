using UnityEngine;

public class MapPotal : MonoBehaviour
{
    // 카메라 스크립트 변수
    private CameraMove cam;
    // 새로운 맵 카메라 최소, 최대 범위 설정
    [SerializeField] Vector2 newMinCameraBoundary;
    [SerializeField] Vector2 newMaxCameraBoundary;
    // 플레이어가 새로운 맵으로 이동된 후 위치 조절.
    [SerializeField] Vector2 playerPosOffset;
    // 출구 위치 변수
    [SerializeField] Transform exitPos;
    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraMove>();
        Debug.Log(exitPos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cam.minCameraBoundary = newMinCameraBoundary;
            cam.maxCameraBoundary = newMaxCameraBoundary;

            cam.player.position = exitPos.position + (Vector3)playerPosOffset;
        }
    }
}