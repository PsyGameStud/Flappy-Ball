using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _clampYValue = 10;

    private Vector3 _previousPosition;
    private float _yDirection;

    private void Start()
    {
        _yDirection = -_clampYValue;
        _rigidbody2D.simulated = false;

        GameplayManager.Instance.OnStartGame += Setup;
    }

    private void Setup()
    {
        _effect.Play();
        _rigidbody2D.simulated = true;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity =
            new Vector2(_moveSpeed, _yDirection);
    }

    private void Update()
    {
        if (Input.anyKey && !GameplayManager.Instance.IsStarted)
        {
            GameplayManager.Instance.StartGame();
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            _yDirection = _clampYValue;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _yDirection = -_clampYValue;
        }
    }

    public void TouchMovement(bool isPressed)
    {
        _yDirection = isPressed ? _clampYValue : -_clampYValue;
    }
}
