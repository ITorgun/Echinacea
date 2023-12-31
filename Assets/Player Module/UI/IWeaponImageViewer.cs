using Assets.WeaponModule.GunModule.Gun;

public interface IWeaponImageViewer
{
    IImageViewer ShootableViewer { get; }
    IImageViewer MagazineViewer { get; }

    void OnShootableSwitched(IImageViewable shootableViewable, IImageViewable magazineViewable);
}
