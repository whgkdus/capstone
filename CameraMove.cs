using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform
    public Vector2 minCameraBoundary; // ī�޶��� �ּ� ���
    public Vector2 maxCameraBoundary; // ī�޶��� �ִ� ���

    private Vector3 desiredPosition; // ���ϴ� ī�޶� ��ġ
    private Vector3 smoothDampVelocity; // �ε巯�� �̵��� ���� �ӵ� ����
    public float smoothTime = 0.3f; // �ε巯�� �̵��� ���Ǵ� �ð�

    private bool isCameraFixed = true; // ī�޶� �����Ǿ� �ִ��� ����

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
            // ������ ī�޶� ��ġ ���
            float posX = (minCameraBoundary.x + maxCameraBoundary.x) / 2f;
            float posY = (minCameraBoundary.y + maxCameraBoundary.y) / 2f;
            desiredPosition = new Vector3(posX, posY, transform.position.z);

            // ī�޶� ��ġ �̵�
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref smoothDampVelocity, smoothTime);
        }
        else if (player != null)
        {
            // �÷��̾�� ī�޶� ������ �߰� ��ġ ���
            float posX = Mathf.Clamp(player.position.x, minCameraBoundary.x, maxCameraBoundary.x);
            float posY = Mathf.Clamp(player.position.y, minCameraBoundary.y, maxCameraBoundary.y);
            desiredPosition = new Vector3(posX, posY, transform.position.z);

            // �ε巯�� �̵��� ���� SmoothDamp �Լ� ���
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref smoothDampVelocity, smoothTime);
        }
    }
}