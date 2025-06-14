using UnityEngine;

public class GameTracks : MonoBehaviour
{
    [SerializeField] private GameObject[] _tracks;

    public void Init()
    {
        int trackIndex = GameData.Instance.CurrentTrack;
        for (int i = 0; i < _tracks.Length; i++)
        {
            _tracks[i].SetActive(i == trackIndex);
        }
    }
}
