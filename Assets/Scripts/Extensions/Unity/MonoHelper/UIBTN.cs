using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Extensions.DoTween;
using Extensions.Unity.MonoHelper;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UIBTN : MonoBehaviour, IPointerClickHandler, ITweenContainerBind
{
    [SerializeField] private Image _image;
    public ITweenContainer TweenContainer { get; set; }

    private void Awake()
    {
        TweenContainer = TweenContain.Install(this);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Time.timeScale = 1f;
        PlayClickAnimation(() => OnClick());
    }

    private void OnDisable()
    {
        TweenContainer.Clear();
    }

    private void PlayClickAnimation(TweenCallback onComplete)
    {
        TweenContainer.AddTween = _image.transform.DOScale(new Vector3(1.1f, 1.1f, 1f), 0.1f)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad)
            .OnComplete(onComplete); 
    }
    
    protected abstract void OnClick();
}