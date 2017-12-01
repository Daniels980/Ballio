using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image BG;
    private Image joyStick;
    private Vector3 inputVector;

    private void Start()
    {
        BG = GetComponent<Image>();
        joyStick = transform.GetChild(0).GetComponent<Image>();


    }
    public virtual void OnPointerDown(PointerEventData PED)
    {
        OnDrag(PED);
    }
    public virtual void OnPointerUp(PointerEventData PED)
    {
        inputVector = Vector3.zero;
        joyStick.rectTransform.anchoredPosition = Vector3.zero;
    }
    public virtual void OnDrag(PointerEventData PED)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(BG.rectTransform, PED.position, PED.pressEventCamera, out pos))
        {
            pos.x = (pos.x / BG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / BG.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2 - 1, 0, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            joyStick.rectTransform.anchoredPosition = new Vector3(inputVector.x * (BG.rectTransform.sizeDelta.x / 3), inputVector.z * (BG.rectTransform.sizeDelta.y / 3));

            Debug.Log(inputVector);
        }

    }
    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }
    public float Vertical()
    {
        if (inputVector.z != 0)
            return inputVector.z;
        else
            return Input.GetAxis("Vertical");
    }
}
