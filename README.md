# BitcoinCracker
Bitcoin private key cracker using brute force.

This project was migrated from the legacy .NET Framework / WPF structure to a modern SDK-style .NET 8 build so it can compile in a current development environment.

Build:

```bash
dotnet build
```

The original WinForms / WPF GUI sources were excluded from the modern build because they are Windows-only and not compatible with a cross-platform .NET SDK build. The core cracker logic remains in the C# sources and continues to run under the .NET 8 runtime.