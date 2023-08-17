using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Vector3 _startPosition;
    private PlayerBehaviour _player;
    private float _distance;

    private void Start()
    {
        _startPosition = transform.localPosition;
        _player = GameplayManager.Instance.GetPlayer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.UpdateCounter();
            gameObject.SetActive(false);
        }
    }

    public void ResetFood()
    {
        gameObject.SetActive(true);
        transform.localPosition = _startPosition;
        transform.rotation = Quaternion.Euler(Vector3.forward * 0f);
    }

    private void Update()
    {
        _distance = Vector2.Distance(transform.position, _player.transform.position);
        if (_distance < 6f)
        {
            Follow();
        }
    }

    private void Follow()
    {
        Vector2 direction = _player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Deg2Rad;

        transform.position = Vector2.MoveTowards(transform.position, 
            _player.transform.position, _moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
