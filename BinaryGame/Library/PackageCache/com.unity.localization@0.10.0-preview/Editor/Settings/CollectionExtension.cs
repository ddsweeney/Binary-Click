using UnityEngine;
using System;

namespace UnityEditor.Localization
{
    /// <summary>
    /// Allows for attaching additional data or functionality to a <see cref="StringTableCollection"/> or <see cref="AssetTableCollection"/>.
    /// </summary>
    [Serializable]
    public class CollectionExtension
    {
        [SerializeField, HideInInspector]
        LocalizationTableCollection m_Collection;

        /// <summary>
        /// The collection this extension is attached to.
        /// </summary>
        public LocalizationTableCollection TargetCollection => m_Collection;

        internal void Init(LocalizationTableCollection target)
        {
            m_Collection = target;
        }
    }
}
