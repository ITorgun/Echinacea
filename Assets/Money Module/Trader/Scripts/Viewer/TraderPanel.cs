using Assets.Playable_Entity_Module;
using UnityEngine;

public class TraderPanel : MonoBehaviour, IViewable
{
    [SerializeField] private AvaibleOptionsViewer _avaibleOptionsViewer;
    [SerializeField] private TraderGoodsViewer _goodsViewer;

    public AvaibleOptionsViewer AvaibleOptionsViewer => _avaibleOptionsViewer;
    public TraderGoodsViewer GoodsViewer => _goodsViewer;

    public void Show()
    {
        gameObject.SetActive(true);
        _goodsViewer.Show();
        _avaibleOptionsViewer.Show();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        _goodsViewer.Hide();
        _avaibleOptionsViewer.Hide();
    }
}
