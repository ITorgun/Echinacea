using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "StrongMagazineConfig", menuName = "SO/MagazineConfig/StrongMagazineConfig")]
public class StrongMagazineConfig : ScriptableObject
{
    [SerializeField] private Image _weakImage;
    [SerializeField] private Image _fastImage;
    [SerializeField] private Image _shortImage;

    public Image WeakImage => _weakImage;
    public Image FastImage => _fastImage;
    public Image ShortImage => _shortImage;
}
