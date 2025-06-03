using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private Image _backImage;
    [SerializeField] private Animation _logoAnim;
    [SerializeField] private Animation _textAnim;
    [SerializeField] private Animation _downTextAnim;
    [SerializeField] private AudioSource _logoAudio;
    
    private void Start()
    {
        StartCoroutine(LoadingAnimCor());
    }

    public IEnumerator LoadingAnimCor()
    { 
        _downTextAnim.Play();
        _logoAnim.Play();
        _textAnim.Play();
        
        RectTransform backRectTransform = _backImage.GetComponent<RectTransform>();
        DOTween.Sequence()
            .Append(backRectTransform.DOAnchorPosX(backRectTransform.anchoredPosition.x + 1000, 25f))
            .SetEase(Ease.Linear);

        yield return new WaitForSecondsRealtime(3f);

        SceneManager.LoadScene("MenuAutumm");
    }
}
