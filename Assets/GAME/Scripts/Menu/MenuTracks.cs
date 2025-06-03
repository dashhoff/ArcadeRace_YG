using UnityEngine;

public class MenuTracks : MonoBehaviour
{
    [SerializeField] private UITrack[] _tracks;

    public void Init()
    {
        for (int i = 0; i < _tracks.Length; i++)
        {
            
            
            _tracks[i].Init();
        }
    }

    public void OnTrackClick(int id)
    {
        
    }
}
