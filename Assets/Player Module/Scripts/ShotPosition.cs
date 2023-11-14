using UnityEngine;

public class ShotPosition : MonoBehaviour
{
    [SerializeField] private Transform _leftPositon;
    [SerializeField] private Transform _rightPositon;
    [SerializeField] private Transform _upPositon;
    [SerializeField] private Transform _downPositon;

    public Transform CurrentTransform { get; set; }
    public Transform LeftPositon => _leftPositon;
    public Transform RightPositon => _rightPositon;
    public Transform UpPositon => _upPositon;
    public Transform DownPositon => _downPositon;

    private void Awake()
    {
        CurrentTransform = _leftPositon;
    }
}
