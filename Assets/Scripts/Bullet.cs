﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction;
    public float livingTime = 3f;
    public Color initialColor=Color.white;
    public Color finalColor;

    private SpriteRenderer _render;
    private float _startingTime;
    
  

    private void Awake()
    {
        _render = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // inicia el tiempo
        _startingTime = Time.time;
        Destroy(this.gameObject, livingTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = direction.normalized * speed * Time.deltaTime;
       // transform.position =new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);
        transform.Translate(movement);

        //Cambia el color de la bala de acuerdo al tiempo
        float _timeSinceStarted = Time.time - _startingTime;
        float _precentageCompleted = _timeSinceStarted / livingTime;

        _render.color = Color.Lerp(initialColor, finalColor, _precentageCompleted);
    }
}
