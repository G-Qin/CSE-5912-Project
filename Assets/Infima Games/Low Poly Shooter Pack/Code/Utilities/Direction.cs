// Copyright 2021, Infima Games. All Rights Reserved.

using UnityEngine;
using System;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Basic Horizontal And Vertical Value Struct.
    /// </summary>
    [Serializable]
    public struct Direction
    {
        /// <summary>
        /// Horizontal Getter.
        /// </summary>
        public Vector3 Horizontal => horizontal;
        /// <summary>
        /// Vertical Getter.
        /// </summary>
        public Vector3 Vertical => vertical;

        #region FIELDS SERIALIZED

        [Tooltip("Horizontal Direction.")]
        [SerializeField]
        private Vector3 horizontal;

        [Tooltip("Vertical Direction.")]
        [SerializeField]
        private Vector3 vertical;

        #endregion
    }
}