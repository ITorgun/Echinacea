using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "MagazineConfig", menuName = "SO/MagazineConfig/DefaultMagazineConfig")]
public class DefaultMagazineConfig : ScriptableObject
{
    [SerializeField] private Image _image;

    public Image Image => _image;
}
