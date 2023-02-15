using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AtoB : MonoBehaviour
{
    [SerializeField] Button buttan1;
    [SerializeField] Transform destinationB;
    [SerializeField] Transform blockA;
    [SerializeField] float waitTime;
    [SerializeField] float TravelTime = 2f;
    [SerializeField] CanvasGroup ImageBtn;

    public void OnClickButtan1()
    {
        buttan1.enabled = false;
        Vector3 posOver = new(destinationB.position.x + 3, destinationB.position.y + 2, destinationB.position.z);
        Debug.Log(posOver);
        var quence = DOTween.Sequence();
        quence.Append(transform.DOMove(destinationB.position, TravelTime).OnComplete(() => transform.DOMove(posOver, TravelTime).SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo))).AppendInterval(waitTime);
        quence.OnComplete(() => blockA.DOScale(2, 2).SetLoops(2, LoopType.Yoyo).OnComplete(() => ImageBtn.DOFade(0, 2)));     
    }
}
