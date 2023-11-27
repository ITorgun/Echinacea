using UnityEngine;
using UnityEngine.UI;

public class ShootableImageViewer : MonoBehaviour, IImageViewer 
{
    [SerializeField] private Image _image;

    public void SetImage(IImageViewable image)
    {
        _image.sprite = image.Image.sprite;
        _image.color = image.Image.color;
    }

    public void ResetImage()
    {
        _image.sprite = null;
    }
}
