// Copyright 2021, Infima Games. All Rights Reserved.

using System;
using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Transformation Data.
    /// </summary>
    [Serializable]
    public struct Transformation
    {
        /// <summary>
        /// Location Getter.
        /// </summary>
        public Direction Location => location;
        /// <summary>
        /// Rotation Getter.
        /// </summary>
        public Direction Rotation => rotation;

        [Tooltip("Location Directions.")]
        [SerializeField]
        private Direction location;

        [Tooltip("Rotation Directions.")]
        [SerializeField]
        private Direction rotation;
    }
}