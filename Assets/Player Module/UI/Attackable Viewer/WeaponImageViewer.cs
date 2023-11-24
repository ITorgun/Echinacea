using Assets.WeaponModule.GunModule.Gun;
using UnityEngine;
using Zenject;

public class WeaponImageViewer : MonoBehaviour, IWeaponImageViewer
{
    [Inject(Id = "ShootableViewer")]
    public IImageViewer ShootableViewer { get; private set; }

    [Inject(Id = "MagazineViewer")]
    public IImageViewer MagazineViewer { get; private set; }

    public void OnShootableSwitched(IShootable shootable)
    {
        ShootableViewer.SetImage(shootable.Image);
        MagazineViewer.SetImage(shootable.Magazine.Image);
    }
}
