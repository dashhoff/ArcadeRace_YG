using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private GameTracks _gameTracks;
    
    
    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _gameTracks.Init();
    }
}
