using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUIBehaviour : MonoBehaviour
{

    [Header("UI References")]
    public Image ButtonIconImage;

    [Header("Button Parameters")]
    [Range(1f, 1.2f)]
    public float FinalScaleWhenEntering;
    [Range(0.001f, 0.2f)]
    public float TimeToZoomButton;
    [Range(1, 5)]
    public float ButtonIconPunchEffectStrength;


    private Sequence _iconSequence;


    //Metodo que hace el efecto de zoom in del boton al entrar el cursor
    public void EnterButton()
    {
        if (_iconSequence != null)
            _iconSequence.Kill();

        _iconSequence = DOTween.Sequence();
        
        _iconSequence.Append(transform.DOScale(FinalScaleWhenEntering, TimeToZoomButton));
        
        _iconSequence.Join(ButtonIconImage.transform.DOPunchRotation(Vector3.forward * ButtonIconPunchEffectStrength, 0.5f).SetLoops(-1));
        _iconSequence.Join(ButtonIconImage.transform.DOScale(FinalScaleWhenEntering, TimeToZoomButton));

        _iconSequence.Play();
    }

    //Metodo que hace el efecto de zoom out del boton al salir el cursor
    public void ExitButton()
    {
        if (_iconSequence != null)
            _iconSequence.Kill();

        _iconSequence.Append(transform.DOScale(1, 0.1f));

        _iconSequence.Join(ButtonIconImage.transform.DORotate(Vector3.zero, 0.01f));
        _iconSequence.Join(ButtonIconImage.transform.DOScale(1f, 0.1f));

        _iconSequence.Play();
    }
}
