using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float followSpeed = 5f;

    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - _player.position;
    }

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 targetPosition = _player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
