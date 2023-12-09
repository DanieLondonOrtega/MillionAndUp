namespace MillionAndUp.Infrastructure.DataAccess.Context
{
    /// <summary>
    /// The connection factory to host connection details.
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// Gets a value indicating whether this instance is ready.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is ready; otherwise, <c>false</c>.
        /// </value>
        bool IsReady { get; }

        /// <summary>
        /// Gets the SQL connection configuration.
        /// </summary>
        /// <value>
        /// The SQL connection configuration.
        /// </value>
        string SqlConnectionConfig { get; }

        /// <summary>
        /// Setups the SQL configuration.
        /// </summary>
        /// <param name="sqlConnectionConfig">The SQL connection configuration.</param>
        void SetupSqlConfig(string sqlConnectionConfig);
    }
}
