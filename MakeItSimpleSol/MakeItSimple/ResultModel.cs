namespace MakeItSimple
{
    /// <summary>
    /// Result model
    /// </summary>
    /// <typeparam name="T">Type parameter</typeparam>
    public record ResultModel<T>
    {
        /// <summary>
        /// Result status - Returns true if status is okay.
        /// </summary>
        public bool Status { get; init; }

        /// <summary>
        /// Result message
        /// </summary>
        public List<string>? Message { get; init; }

        /// <summary>
        /// Result data
        /// </summary>
        public T? Data { get; init; }

        /// <summary>
        /// Exception occurred
        /// </summary>
        public bool? IsException { get; init; }
    }
}
