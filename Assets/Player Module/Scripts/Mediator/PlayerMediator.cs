using UnityEngine;
using Zenject;

public class PlayerMediator : MonoBehaviour
{
    public PlayerViewerMediator ViewerMediator { get; private set; }

    [Inject]
    public void Constructor(PlayerViewerMediator viewerMediator)
    {
        ViewerMediator = viewerMediator;
    }

    private void Start()
    {
        ViewerMediator.InitViewers();
    }

}
