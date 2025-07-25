﻿namespace Infrastructure.Configuration
{
    public class PostgresSettings
    {
        public string Database { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Host { get; set; } = default!;
        public int Port { get; set; }
    }
}

