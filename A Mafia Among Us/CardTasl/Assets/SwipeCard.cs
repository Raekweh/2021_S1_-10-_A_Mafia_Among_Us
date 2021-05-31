using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeCard : MonoBehaviour, IDragHandler
{
    private Canvas _canvas;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, eventData.position, _canvas.worldCamera, out pos);

        transform.position = _canvas.transform.TransformPoint(pos);
    }

    public void Awake()
    {
        _canvas = GetComponentInParent<Canvas>();
    }
}
