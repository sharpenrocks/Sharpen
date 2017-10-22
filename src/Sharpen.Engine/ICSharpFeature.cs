using System.Collections.Immutable;

namespace Sharpen.Engine
{
    /// <summary>
    /// Represents a single C# language feature. A feature can span several language versions.
    /// </summary>
    public interface ICSharpFeature
    {
        /// <summary>
        /// Language versions in which the feature appears.
        /// </summary>
        ImmutableArray<string> LanguageVersions { get; }

        /// <summary>
        /// The widely accepted name for the feature.
        /// </summary>
        string FriendlyName { get; }
    }
}