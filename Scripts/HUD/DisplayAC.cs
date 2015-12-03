﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using Matcha.Dreadful;


public class DisplayAC : BaseBehaviour
{
    private Text textComponent;
    private int intToDisplay;
    private string legend = "AC: ";

    void FadeInText()
    {
        // fade to zero instantly, then fade up slowly
        MFX.Fade(textComponent, 0, 0, 0);
        MFX.Fade(textComponent, 1, HUD_FADE_IN_AFTER, HUD_INITIAL_TIME_TO_FADE);
    }

    void OnInitInteger(int initInt)
    {
        textComponent = gameObject.GetComponent<Text>();
        textComponent.text = legend + initInt.ToString();
        textComponent.DOKill();
        FadeInText();
    }

    void OnChangeInteger(int newInt)
    {
        textComponent.text = legend + newInt.ToString();
    }

    void OnFadeHud(bool status)
    {
        MFX.Fade(textComponent, 0, HUD_FADE_OUT_AFTER, HUD_INITIAL_TIME_TO_FADE);
    }

    void OnEnable()
    {
        Messenger.AddListener<int>("init ac", OnInitInteger);
        // Messenger.AddListener<int>("change score", OnChangeInteger);
        Messenger.AddListener<bool>("fade hud", OnFadeHud);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener<int>("init ac", OnInitInteger);
        // Messenger.RemoveListener<int>("change score", OnChangeInteger);
        Messenger.RemoveListener<bool>("fade hud", OnFadeHud);
    }
}