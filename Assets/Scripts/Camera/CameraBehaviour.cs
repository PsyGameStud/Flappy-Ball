using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _target;
    
    private Vector3 _offset = new Vector3(5f, 0f, -10f);
    private float _smoothTime = 0.2f;
    private Vector3 _velocity = Vector3.zero;
    
    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, 
            new Vector3(_target.position.x + _offset.x, _offset.y, _offset.z), ref _velocity, _smoothTime);
    }
}
