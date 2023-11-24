using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "StrongMagazineConfig", menuName = "SO/MagazineConfig/StrongMagazineConfig")]
public class StrongMagazineConfig : ScriptableObject
{
    [SerializeField] private Image _image;

    public Image Image => _image;
}
