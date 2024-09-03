using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ButtonView : MonoBehaviour
{
    private UnityEngine.UI.Button _button;
    private Animator _animator;
    public event Func<Task> OnButtonPressed;

    private void Start()
    {
        _button = gameObject.GetComponent<UnityEngine.UI.Button>();
        _animator = gameObject.GetComponent<Animator>();
        _button.onClick.AddListener(Click);
    }

    private void Click()
    {
        _animator.SetBool("anim", true);
        OnButtonPressed?.Invoke();
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }
}
