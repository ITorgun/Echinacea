using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagazineImageViewer : MonoBehaviour, IImageViewer
{
    [SerializeField] private Image _image;

    public void SetImage(Image image)
    {
        _image.sprite = image.sprite;
    }

    public void ResetImage()
    {
        _image.sprite = null;
    }
}
