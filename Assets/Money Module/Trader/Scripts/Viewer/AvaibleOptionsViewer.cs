using Assets.Playable_Entity_Module;
using UnityEngine;

public class AvaibleOptionsViewer : MonoBehaviour, IViewable
{
    [SerializeField] private TraderGoodsViewer _goodsViewer;

    public void Show()
    {
        gameObject.SetActive(true);
        _goodsViewer.Show();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        _goodsViewer.Hide();
    }
}
