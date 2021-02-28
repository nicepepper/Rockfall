using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public Transform target;
    public Transform showDistanceTo;
    public Text distanceLabel;
    public int margin = 50;

    public Color color
    {
        set
        {
            GetComponent<Image>().color = value;
        }
        get
        {
            return GetComponent<Image>().color;
        }
    }

    private void Start()
    {
        distanceLabel.enabled = false;
        GetComponent<Image>().enabled = false;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        if (showDistanceTo != null)
        {
            distanceLabel.enabled = true;
            var distance = (int) Vector3.Magnitude(showDistanceTo.position - target.position);
            distanceLabel.text = distance.ToString() + "m";
        }
        else
        {
            distanceLabel.enabled = false;
        }

        GetComponent<Image>().enabled = true;
        var viewportPoint = Camera.main.WorldToViewportPoint(target.position);

        if (viewportPoint.z < 0)
        {
            viewportPoint.z = 0;
            viewportPoint = viewportPoint.normalized;
            viewportPoint.x = -Mathf.Infinity;
        }

        var screenPoint = Camera.main.ViewportToScreenPoint(viewportPoint);

        screenPoint.x = Mathf.Clamp(
            screenPoint.x,
            margin,
            Screen.width - margin * 2);

        screenPoint.y = Mathf.Clamp(
            screenPoint.y,
            margin,
            Screen.height);
        
        var localPosition = new Vector2();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent.GetComponent<RectTransform>(),
            screenPoint,
            Camera.main,
            out localPosition);

        var rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = localPosition;
    }
}
