using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool _isMovable;
    private float _moveSpeed;

    private float _yTop = 2.5f;
    private float _yDown = -2.5f;
    private float _currentDirection;

    public void Setup()
    {
        _moveSpeed = Random.Range(1f, 3f);
        transform.localPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(_yDown, _yTop));

        var randomDirection = Random.Range(0, 2);
        _currentDirection = randomDirection == 0 ? _yDown : _yTop;
    }

    private void Update()
    {
        if (_isMovable)
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        var newPosition = new Vector3(transform.localPosition.x, _currentDirection);
        
        transform.localPosition =
            Vector3.MoveTowards(transform.localPosition,
                newPosition, _moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.localPosition, newPosition) < 0.1f)
        {
            _currentDirection = -_currentDirection;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            GameplayManager.Instance.GameOver();
        }
    }
}
