// Copyright (c) 2020 Andrew Vardeman.  Published under the MIT license.
// See license.txt in the TopoPad distribution or repository for the
// full text of the license.

using Ardalis.GuardClauses;

namespace TopoPad.Core.Style
{
    public class ItemsStyleSpec : StyleNotifier
    {
        private FeatureStyleSet m_FeatureStyleSet = new FeatureStyleSet();
        public FeatureStyleSet FeatureStyleSet
        {
            get => m_FeatureStyleSet;
            set
            {
                Guard.Against.Null(value, nameof(value));
                SetNotifyUnregisterRegister(ref m_FeatureStyleSet, value);
            }
        }

        private FeatureStyleSet m_SelectedFeatureStyleSet = new FeatureStyleSet();
        public FeatureStyleSet SelectedFeatureStyleSet
        {
            get => m_SelectedFeatureStyleSet;
            set
            {
                Guard.Against.Null(value, nameof(value));
                SetNotifyUnregisterRegister(ref m_SelectedFeatureStyleSet, value);
            }
        }

        private FeatureStyleSet m_ActiveFeatureStyleSet = new FeatureStyleSet();
        public FeatureStyleSet ActiveFeatureStyleSet
        {
            get => m_ActiveFeatureStyleSet;
            set
            {
                Guard.Against.Null(value, nameof(value));
                SetNotifyUnregisterRegister(ref m_ActiveFeatureStyleSet, value);
            }
        }
    }
}
