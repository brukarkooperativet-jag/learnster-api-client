# Learnster api client

.NET client for [Leasrnster](https://learnster.com/) Api

---

## How to use:
- Add the package to references
- Register dependencies for DI Container
  - `services.RegisterLearnsterClient()`
- Add IOptions for Learnster (supports validation)
  - `services.Configure<LearnsterOptions>(Configuration.GetSection(LearnsterOptions.SECTION_NAME))`
- Call all requests via ILearnsterClient

---

## Test environment
Setup test environment variables for integration tests (windows):
```
dotnet user-secrets set "Learnster:Url" "https://{your-space-name}.learnster.com/"
dotnet user-secrets set "Learnster:VendorId" "{vendor-id}"
dotnet user-secrets set "Learnster:ClientId" "{client-id}"
dotnet user-secrets set "Learnster:ClientSecret" "{secret}"
```