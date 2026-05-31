# Security Guidelines for Sensitive Configuration

## Protecting Redis and Database Credentials

This project uses multiple layers of security for sensitive data:

### Development Environment
1. **User Secrets**: Sensitive credentials are stored locally using .NET User Secrets
   - Location: `%APPDATA%\Microsoft\UserSecrets\<user-secrets-id>`
   - Run `setup-secrets.ps1` to initialize secrets

2. **appsettings.json**: Contains only placeholder values, never commit real credentials
   - Example values: `your-redis-host`, `your-connection-string`

### Production Environment
1. **Azure Key Vault**: For production, use Azure Key Vault
   - Store Redis password, database connection strings, and API keys
   - Reference secrets in appsettings.json using Azure Key Vault provider

2. **Environment Variables**: Set via deployment platform (Docker, App Service, etc.)
   - Set `ConnectionStrings__bike_store_db`
   - Set `Redis__Host`, `Redis__Port`, `Redis__Password`

### How to Setup Development Secrets

```powershell
# Navigate to the API project
cd BikeStore.Api

# Initialize user secrets (one-time setup)
dotnet user-secrets init

# Set Redis credentials
dotnet user-secrets set "Redis:Host" "your-redis-host"
dotnet user-secrets set "Redis:Port" "6379"
dotnet user-secrets set "Redis:User" "default"
dotnet user-secrets set "Redis:Password" "your-redis-password"

# Set database connection string
dotnet user-secrets set "ConnectionStrings:bike_store_db" "your-connection-string"

# List all secrets
dotnet user-secrets list
```

### Important Notes
- ✅ **DO**: Store secrets in User Secrets or Key Vault
- ✅ **DO**: Add `appsettings.json` to `.gitignore`
- ✅ **DO**: Use environment variables in production
- ❌ **DON'T**: Commit credentials to Git
- ❌ **DON'T**: Expose API keys in client-side code
- ❌ **DON'T**: Log sensitive information

### Configuration Priority (Highest to Lowest)
1. Environment variables
2. User Secrets (Development only)
3. appsettings.Development.json
4. appsettings.json

