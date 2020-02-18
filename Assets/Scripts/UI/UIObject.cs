using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObject : ReusableObject
{
    RectTransform _rectTransform;
    public RectTransform rectTransform
    {
        get
        {
            if (_rectTransform == null)
                _rectTransform = transform as RectTransform;
            
            return _rectTransform;
        }
        private set{_rectTransform = value;}
    }

    public void Show(bool show){
        if (gameObject.activeSelf != show)
            gameObject.SetActive(show);
    }

    public bool isShown(){
        return gameObject.activeSelf;
    }
}
