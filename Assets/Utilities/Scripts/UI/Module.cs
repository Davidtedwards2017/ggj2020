using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Module : MonoBehaviour {

    private bool _Active;

    Sequence activeSequence;

    public bool Active
    {
        get { return _Active; }
        set
        {
            if (_Active == value) return;

            _Active = value;

            if (_Active)
            {
                OnActivated();
            }
            else
            {
                OnDeactivated();
            }
        }
    }

    protected virtual void OnActivated()
    {
    }

    protected virtual void OnDeactivated()
    {
    }

    public void SetPosition(Vector2 position)
    {
        var rect = GetComponent<RectTransform>();
        rect.anchoredPosition = position;
    }
}
