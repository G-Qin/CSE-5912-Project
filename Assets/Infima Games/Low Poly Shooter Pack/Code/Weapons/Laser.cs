// Copyright 2021, Infima Games. All Rights Reserved.

using System;
using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Laser.
    /// </summary>
    public class Laser : LaserBehaviour
    {
        #region FIELDS SERIALIZED

        [Header("Settings")]

        [Tooltip("Sprite. Displayed on the player's interface.")]
        [SerializeField]
        private Sprite sprite;

        [Header("Laser Beam")]
        
        [Tooltip("Laser Beam Transform.")]
        [SerializeField]
        private Transform beam;

        [Tooltip("Determines how thick the laser beam is.")]
        [SerializeField]
        private float beamThickness = 1.2f;

        [Tooltip("Maximum distance for tracing the laser beam.")]
        [SerializeField]
        private float beamMaxDistance = 500.0f;
        
        #endregion

        #region FIELDS

        /// <summary>
        /// Beam Parent.
        /// </summary>
        private Transform beamParent;

        #endregion
        
        #region GETTERS

        public override Sprite GetSprite() => sprite;

        #endregion

        #region UNITY

        private void Awake()
        {
            //Ignore.
            if (beam == null)
                return;
            
            //Cache beam parent.
            beamParent = beam.parent;
        }

        private void Update()
        {
            //Ignore.
            if (beam == null)
                return;
        
            //Target Scale. We'll use the default value if we don't hit anything with our raycast.
            float targetScale = beamMaxDistance;
            
            //Raycast forward from the beam starting point.
            if (Physics.Raycast(new Ray(beam.position, beamParent.forward), out RaycastHit hit, beamMaxDistance))
                targetScale = hit.distance * 5.0f;
            
            //Scale to reach the hit location.
            beamParent.localScale = new Vector3(beamThickness, beamThickness, targetScale);
        }

        #endregion
    }
}