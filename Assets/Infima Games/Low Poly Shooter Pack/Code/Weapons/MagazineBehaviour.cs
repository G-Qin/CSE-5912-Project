// Copyright 2021, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Magazine Behaviour.
    /// </summary>
    public abstract class MagazineBehaviour : MonoBehaviour
    {
        #region GETTERS
        
        /// <summary>
        /// Returns The Total Ammunition.
        /// </summary>
        public abstract int GetAmmunitionTotal();

        /// <summary>
        /// Returns The Clip Size.
        /// </summary>
        public abstract int GetClipSize();

        /// <summary>
        /// Sets The Clip Size.
        /// </summary>
        public abstract void SetClipSize(int amount);

        /// <summary>
        /// Set The Total Ammunition.
        /// </summary>
        public abstract void SetAmmunitionTotal(int amount);

        /// <summary>
        /// Returns The Current Ammunition.
        /// </summary>
        public abstract int GetAmmunitionCurrent();

        /// <summary>
        /// Returns the Sprite used on the Character's Interface.
        /// </summary>
        public abstract Sprite GetSprite();

        #endregion
    }
}