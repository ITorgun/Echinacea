using Assets.Playable_Entity_Module;
using UnityEngine;

public class TraderGoodsViewer : MonoBehaviour, IViewable
{
    [SerializeField] private BulletsViewer _bulletViewer;

    public BulletsViewer BulletViewer => _bulletViewer;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        BulletViewer.Hide();
        gameObject.SetActive(false);
    }
}
