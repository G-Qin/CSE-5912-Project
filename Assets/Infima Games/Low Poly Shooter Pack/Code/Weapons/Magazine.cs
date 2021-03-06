// Copyright 2021, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Magazine.
    /// </summary>
    public class Magazine : MagazineBehaviour
    {
        #region FIELDS SERIALIZED

        [Header("Settings")]
        
        [Tooltip("Total Ammunition.")]
        [SerializeField]
        public int ammunitionTotal = 30;

        [Tooltip("Current Ammunition.")]
        [SerializeField]
        private int ammunitionCurrent = 10;

        [Tooltip("Clip Size.")]
        [SerializeField]
        private int clip = 10;

        [Header("Interface")]

        [Tooltip("Interface Sprite.")]
        [SerializeField]
        private Sprite sprite;

        #endregion

        #region GETTERS

        /// <summary>
        /// Ammunition Total.
        /// </summary>
        public override int GetAmmunitionTotal() => ammunitionTotal;

        /// <summary>
        /// Ammunition Total.
        /// </summary>
        public override int GetClipSize() => clip;

        /// <summary>
        /// Set Clip Size.
        /// </summary>
        public override void SetClipSize(int amount){
            clip=amount;
        }

        /// <summary>
        /// Set Ammunition Total.
        /// </summary>
        public override void SetAmmunitionTotal(int amount){
            ammunitionTotal=amount;
        }

        /// <summary>
        /// Ammunition Current.
        /// </summary>
        public override int GetAmmunitionCurrent() => ammunitionCurrent;

        /// <summary>
        /// Sprite.
        /// </summary>
        public override Sprite GetSprite() => sprite;

        #endregion
    }
}