using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public InvaderData invaderData; // Scriptable Object referansı

    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;

    void Awake() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start() 
    {
        InvokeRepeating(nameof(AnimateSprite), invaderData.animationTime, invaderData.animationTime);    
    }

    private void AnimateSprite()
    {
        _animationFrame++;

        if (_animationFrame >= invaderData.animationSprites.Length)
        {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = invaderData.animationSprites[_animationFrame];
    }
}