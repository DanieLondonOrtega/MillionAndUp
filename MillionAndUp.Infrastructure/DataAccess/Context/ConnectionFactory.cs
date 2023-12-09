namespace MillionAndUp.Infrastructure.DataAccess.Context
{
    /// <summary>
    /// The connection factory.
    /// </summary>
    public class ConnectionFactory : IConnectionFactory
    {
        /// <summary>
        /// The connection configuration.
        /// </summary>
        private IDictionary<string, object> connectionConfiguration;
        /// <inheritdoc/>
        public bool IsReady => this.connectionConfiguration != null;

        /// <inheritdoc/>
        public string SqlConnectionConfig => this.GetValue<string>(nameof(this.SqlConnectionConfig));

        /// <inheritdoc/>
        public void SetupSqlConfig(string sqlConnectionConfig)
        {
            this.connectionConfiguration ??= new Dictionary<string, object>();

            var key = nameof(this.SqlConnectionConfig);
            if (this.connectionConfiguration.ContainsKey(key))
            {
                this.connectionConfiguration[key] = sqlConnectionConfig;
            }
            else
            {
                this.connectionConfiguration.Add(key, sqlConnectionConfig);
            }
        }


        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>The configuration value.</returns>
        private TValue GetValue<TValue>(string key)
        {
            if (this.connectionConfiguration != null && this.connectionConfiguration.ContainsKey(key))
            {
                return (TValue)this.connectionConfiguration[key];
            }
            return default(TValue);
        }
    }
}
