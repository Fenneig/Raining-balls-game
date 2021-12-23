﻿using UnityEngine;

namespace RainingBalls
{
    public class BallChooser : MonoBehaviour
    {
        [SerializeField] private Sprite[] _balls;
        
        public Sprite GetRandomBall()
        {
            return _balls[Random.Range(0, _balls.Length)];
        }

    }
}