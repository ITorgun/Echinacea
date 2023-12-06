using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IImageViewer
{
    void SetImage(IImageViewable image);
    void ResetImage();
}