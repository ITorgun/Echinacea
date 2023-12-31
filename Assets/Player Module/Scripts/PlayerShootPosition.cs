using UnityEngine;
using Zenject;

public class PlayerShootPosition : MonoBehaviour, IShootPosition
{
    [SerializeField] private Transform _leftPositon;
    [SerializeField] private Transform _rightPositon;
    [SerializeField] private Transform _upPositon;
    [SerializeField] private Transform _downPositon;

    public Transform CurrentPosition { get; private set; }
    public Vector2 CurrentVector { get; private set; }
    public bool IsLocked { get; private set; }

    private ILockShootPositionEvent _lockPositionEvent;

    private void Awake()
    {
        CurrentPosition = _leftPositon;
        CurrentVector = Vector2.left;
    }

    [Inject]
    public void Construct(ILockShootPositionEvent lockPositionEvent)
    {
        _lockPositionEvent = lockPositionEvent;
    }

    private void OnEnable()
    {
        _lockPositionEvent.ShootPositionLocked += OnPositionLocked;
    }

    public void UpdateState(Vector2 movementDirection)
    {
        if (Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.y))
        {
            if (movementDirection.x > 0)
            {
                ChangeCurrentState(_rightPositon, Vector2.right);
            }
            else
            {
                ChangeCurrentState(_leftPositon, Vector2.left);
            }
        }
        else
        {
            if (movementDirection.y > 0)
            {
                ChangeCurrentState(_upPositon, Vector2.up);
            }
            else
            {
                ChangeCurrentState(_downPositon, Vector2.down);
            }
        }
    }

    private void OnPositionLocked()
    {
        IsLocked = !IsLocked;
    }

    private void ChangeCurrentState(Transform position, Vector2 direction)
    {
        if (IsLocked == false)
        {
            CurrentPosition = position;
            CurrentVector = direction;
        }
    }
}
