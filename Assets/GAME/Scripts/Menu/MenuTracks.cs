using UnityEngine;

public class MenuTracks : MonoBehaviour
{
    [SerializeField] private MenuCameraController _menuCameraController;
    
    [SerializeField] private UITrack[] _tracks;

    [SerializeField] private UIPanel _selectedTrackPanel;
    [SerializeField] private UIPanel _selectCarPanel;

    public void Init()
    {
        for (int i = 0; i < _tracks.Length; i++)
        {
            if (GameSaves.Instance.OpenTracks[i] == 0)
                _tracks[i].Locked = true;
            else
                _tracks[i].Locked = false;
            
            _tracks[i].Init();
        }
    }

    public void OnTrackClick(int id)
    {
        if (id == -1)
        {
            GameData.Instance.CurrentTrack = id;
            return;
        }

        if (!_tracks[id].Locked)
        {
            GameData.Instance.CurrentTrack = id;
            
            _menuCameraController.SetActiveCamera(2);
            
            _selectCarPanel.Open();
            _selectedTrackPanel.Close();
        }
    }
}
