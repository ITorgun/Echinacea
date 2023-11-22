using UnityEngine;
using Zenject;

public class PlayerMediator : MonoBehaviour
{
    public PlayerViewerMediator ViewerMediator { get; private set; }
    public PlayerInputMediator InputMediator { get; private set; }

    [Inject]
    public void Constructor(PlayerViewerMediator viewerMediator, PlayerInputMediator playerInput)
    {
        ViewerMediator = viewerMediator;
        InputMediator = playerInput;
    }

    private void Start()
    {
        ViewerMediator.InitViewers();
    }

}
