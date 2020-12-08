namespace Sharpen.Engine
{
    public enum SharpenSuggestionType
    {
        /// <summary>
        /// Recommendation is a suggestion that is safe to apply and should always be accepted.
        /// </summary>
        Recommendation,
        /// <summary>
        /// Consideration is a suggestion that needs to be carefully considered before being accepted or rejected.
        /// </summary>
        Consideration
    }
}
