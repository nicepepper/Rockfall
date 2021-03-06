using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTarget : MonoBehaviour
{
    public Sprite targetImage;

    private void Start()
    {
        IndicatorManager.instance.AddIndicator(gameObject, Color.yellow, targetImage);
    }
}
