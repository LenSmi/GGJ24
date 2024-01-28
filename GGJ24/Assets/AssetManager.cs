using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    [SerializeField,Header("SpriteRenderers")]
    public SpriteRenderer clownFace;
    public SpriteRenderer clownMouth;
    public SpriteRenderer clownHair;
    public SpriteRenderer clownEyes;
    public SpriteRenderer clownNose;

    public GameObject clownTearsObj;
    public SpriteRenderer clownTears;

    [Header("Neutral Face")]
    public Sprite neutralClownFaceSprite;
    public Sprite neutralClownMouthSprite;
    public Sprite neutralClownHairSprite;
    public Sprite neutralClownEyesSprite;
    public Sprite neutralClownNoseSprite;
    public Sprite neutralClownTearsSprite;

    [Header("Smiling Face")]
    public Sprite smilingClownFaceSprite;
    public Sprite smilingClownMouthSprite;
    public Sprite smilingClownHairSprite;
    public Sprite smilingClownEyesSprite;
    public Sprite smilingClownNoseSprite;
    public Sprite smilingClownTearsSprite;

    [Header("Happy Face")]
    public Sprite happyClownFaceSprite;
    public Sprite happyClownMouthSprite;
    public Sprite happyClownHairSprite;
    public Sprite happyClownEyesSprite;
    public Sprite happyClownNoseSprite;
    public Sprite happyClownTearsSprite;

    [Header("Sad Face")]
    public Sprite sadClownFaceSprite;
    public Sprite sadClownMouthSprite;
    public Sprite sadClownHairSprite;
    public Sprite sadClownEyesSprite;
    public Sprite sadClownNoseSprite;
    public Sprite sadClownTearsSprite;

    [Header("Angry Face")]
    public Sprite angryClownFaceSprite;
    public Sprite angryClownMouthSprite;
    public Sprite angryClownHairSprite;
    public Sprite angryClownEyesSprite;
    public Sprite angryClownNoseSprite;
    public Sprite angryClownTearsSprite;


    public void HappyFace()
    {
        clownHair.sprite = happyClownHairSprite;
        clownFace.sprite = happyClownFaceSprite;
        clownMouth.sprite = happyClownMouthSprite;
        clownNose.sprite = happyClownNoseSprite;

        //clownTearsObj.SetActive(true);
        //clownTears.sprite = happyClownTearsSprite;
    }

    public void SmilingFace()
    {

    }

    public void NeutralFace()
    {

    }

    public void SadFace()
    {

    }

    public void AngryFace()
    {

    }


}
