using Assets.WeaponModule.GunModule.Gun;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WeaponImageViewer : MonoBehaviour, IWeaponImageViewer
{
    [Inject(Id = "ShootableViewer")]
    public IImageViewer ShootableViewer { get; private set; }

    [Inject(Id = "MagazineViewer")]
    public IImageViewer MagazineViewer { get; private set; }

    public void OnShootableSwitched(IImageViewable shootableViewable, IImageViewable magazineViewable)
    {
        ShootableViewer.SetImage(shootableViewable);
        MagazineViewer.SetImage(magazineViewable);
    }

    public void OnAmmoTypeSwitched(IImageViewable magazineViewable)
    {
        MagazineViewer.SetImage(magazineViewable);
    }
}
