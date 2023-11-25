using UnityEngine;
using UnityEngine.UI;

public class ShootableImageViewer : MonoBehaviour, IImageViewer 
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
