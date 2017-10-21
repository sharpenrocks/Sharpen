namespace Sharpen.Engine
{
    /// <summary>
    /// Represents a single suggestion given by Sharpen.
    /// </summary>
    public interface ISharpenSuggestion
    {
        /// <summary>
        /// Minimum language version in which the suggestion is applicable.
        /// </summary>
        CSharpLanguageVersion MinimumLanguageVersion { get; }

        /// <summary>
        /// Language feature to which the suggestion applies.
        /// </summary>
        ICSharpFeature LanguageFeature { get; }

        /// <summary>
        /// The widely accepted name for the suggestion.
        /// </summary>
        string FriendlyName { get; }
    }
}