// Copyright 2021, Infima Games. All Rights Reserved.

using System;
using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Sway Data Struct.
    /// </summary>
    [Serializable]
    public struct Sway
    {
        /// <summary>
        /// Look Getter.
        /// </summary>
        public Transformation Look => look;
        /// <summary>
        /// Movement Getter.
        /// </summary>
        public Transformation Movement => movement;

        [Tooltip("Look Settings.")]
        [SerializeField] 
        private Transformation look;

        [Tooltip("Movement Settings.")]
        [SerializeField]
        private Transformation movement;
    }
}