using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "MagazineConfig", menuName = "SO/MagazineConfig/DefaultMagazineConfig")]
public class DefaultMagazineConfig : ScriptableObject
{
    [SerializeField] private Image _weakImage;
    [SerializeField] private Image _averageImage;
    [SerializeField] private Image _strongImage;
    [SerializeField] private Image _testImage;

    public Image WeakImage => _weakImage;
    public Image AverageImage => _averageImage;
    public Image StrongImage => _strongImage;
    public Image TestImage => _testImage;
}
