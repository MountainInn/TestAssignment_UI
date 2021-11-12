using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketWindow : MonoBehaviour
{
    [SerializeField] Page activePage, freePage;
    [SerializeField] Button leftButton, rightButton, closeButton;

    List<PageData> pageData;

    float pageWidth;

    int currentPageId, targetPageId;

    RectTransform activePageRect, freePageRect;

    Coroutine tabTween;

    void Awake()
    {
        activePageRect = activePage.GetComponent<RectTransform>();
        freePageRect = freePage.GetComponent<RectTransform>();
        pageWidth = activePageRect.sizeDelta.x;

        closeButton.onClick.AddListener(()=>Application.Quit());
    }

    void Start()
    {
        InitializePages();
    }

    public void SetPageData(List<PageData> pageData)
    {
        this.pageData = pageData;
    }

    void InitializePages()
    {
        ApplyPageData(activePage, 0);
        activePageRect.anchoredPosition = Vector3.zero;
        freePageRect.anchoredPosition = new Vector3(pageWidth, 0, 0);
    }

    void ApplyPageData(Page page,  int pageDataId)
    {
        PageData data = pageData[pageDataId];

        leftButton.interactable = data.leftButtonInteractable;
        rightButton.interactable = data.rightButtonInteractable;
        closeButton.interactable = data.closeButtonInteractable;

        page.LoadItems(data.items);
    }

    public void SwitchPageLeft()
    {
        SwitchPage(-1);
    }
    public void SwitchPageRight()
    {
        SwitchPage(1);
    }

    void SwitchPage(int direction)
    {
        targetPageId = Mathf.Clamp(targetPageId + direction, 0, pageData.Count - 1);

        if (tabTween == null)
        {
            tabTween = StartCoroutine(TweenPagePositions());
        }
    }

    IEnumerator TweenPagePositions()
    {
        while (currentPageId != targetPageId)
        {
            int
                direction = (int)Mathf.Sign( targetPageId - currentPageId ),
                nextPageId = currentPageId + direction;

            Vector3 nextTabStartPosition = freePageRect.anchoredPosition = new Vector3(pageWidth * direction, 0, 0);

            ApplyPageData(freePage, nextPageId);

            (activePage, freePage) = (freePage, activePage);
            (activePageRect, freePageRect) = (freePageRect, activePageRect);

            float t = 0;

            do
            {
                t += Time.deltaTime / .5f;

                freePageRect.anchoredPosition = Vector3.Lerp(Vector3.zero, -nextTabStartPosition, t);
                activePageRect.anchoredPosition = Vector3.Lerp(nextTabStartPosition, Vector3.zero, t);

                yield return new WaitForEndOfFrame();
            }
            while (t < 1f);

            currentPageId = nextPageId;
        }

        tabTween = null;
    }
}
