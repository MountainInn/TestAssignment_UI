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

    int
        currentPageId,
        targetPageId;

    RectTransform
        activePageRect,
        freePageRect;

    Coroutine tabTween;

    void Awake()
    {
        activePageRect = activePage.GetComponent<RectTransform>();
        freePageRect = freePage.GetComponent<RectTransform>();

        pageWidth = activePageRect.sizeDelta.x;

        pageData = new List<PageData>();
    }

    void Start()
    {
        InitializePages();
    }

    void InitializePages()
    {
        ApplyPageData(activePage, 0);
        activePageRect.anchoredPosition = Vector3.zero;
        freePageRect.anchoredPosition = new Vector3(pageWidth, 0, 0);
    }

    public void SwitchPageLeft()
    {
        if (currentPageId == 0) return;

        targetPageId = currentPageId - 1;

        SwitchPage(targetPageId, -1);
    }
    public void SwitchPageRight()
    {
        if (currentPageId == pageData.Count-1) return;

        targetPageId = currentPageId + 1;

        SwitchPage(targetPageId, +1);
    }

    private void SwitchPage(int nextPageId, int pageDirection)
    {
        StartCoroutine(TweenTabPositions(pageDirection));

        currentPageId = nextPageId;
    }

    private void ApplyPageData(Page page,  int pageDataId)
    {
        PageData nextPage = pageData[pageDataId];

        leftButton.interactable = nextPage.leftButtonAvailable;
        rightButton.interactable = nextPage.rightButtonAvailable;
        closeButton.interactable = nextPage.closeButtonAvailable;

        page.LoadItems(nextPage.items);
    }

    IEnumerator TweenTabPositions(int direction)
    {
        Vector3 nextTabStartPosition = freePageRect.anchoredPosition = new Vector3(pageWidth * direction, 0, 0);

        float t = 0;

        ApplyPageData(freePage, nextPageId);

        (activePage, freePage) = (freePage, activePage);
        (activePageRect, freePageRect) = (freePageRect, activePageRect);

        while (t < 1f)
        {
            t += Time.deltaTime / .5f;

            freePageRect.anchoredPosition = Vector3.Lerp(Vector3.zero, -nextTabStartPosition, t);
            activePageRect.anchoredPosition = Vector3.Lerp(nextTabStartPosition, Vector3.zero, t);

            yield return new WaitForEndOfFrame();
        }
    }

    public void LoadPageData(List<PageData> pageData)
    {
        this.pageData = pageData;
    }
}
