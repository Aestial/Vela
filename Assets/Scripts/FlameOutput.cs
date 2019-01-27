﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameOutput : MonoBehaviour 
{
    [SerializeField] private Transform flare;
    [SerializeField] float maxFlare;
    [SerializeField] float minFlare;
    [SerializeField] AudioClip destroySound;

    FlameBehave flameBehave;
    public float currentHP;
	
	void Start () 
    {
        //this.material = this.meshRenderer.material;
        this.flameBehave = GetComponent<FlameBehave>();
	}
	
	void Update () 
    {
        this.currentHP = this.flameBehave.actualHP;
        if (this.currentHP <= 0.001f)
        {
            AudioManager.Instance.PlayOneShoot2D(destroySound);
            gameObject.SetActive(false);
        }
        float t = this.currentHP;
        float flareScale = Mathf.Lerp(minFlare, maxFlare, t);
        flare.localScale = new Vector3(flareScale, flareScale, flareScale);
	}
}