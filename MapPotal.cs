using UnityEngine;

public class MapPotal : MonoBehaviour
{
    // ī�޶� ��ũ��Ʈ ����
    private CameraMove cam;
    // ���ο� �� ī�޶� �ּ�, �ִ� ���� ����
    [SerializeField] Vector2 newMinCameraBoundary;
    [SerializeField] Vector2 newMaxCameraBoundary;
    // �÷��̾ ���ο� ������ �̵��� �� ��ġ ����.
    [SerializeField] Vector2 playerPosOffset;
    // �ⱸ ��ġ ����
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