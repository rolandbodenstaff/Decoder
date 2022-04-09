# Decoder.Cli

This is a simple decoder/encoder .NET tool that I created because I was tired of having to use different website to encode/decode stuff. Use at your own risk because it was made with no intention of being used by anyone else.


## Getting Started

### Dependencies

* CommandLineParser
* TextCopy
* System.IdentityModel.Tokens.Jwt

### Installing
From source
``` 
dotnet pack
dotnet tool install --global --add-source .\nupkg Robod.Decoder.Cli
```
From NuGet
```
dotnet tool install --global Robod.Decoder.Cli --version 0.0.1
```

### Some examples
Decode JWT
```
dor -j {token}
```

Encode to base64
```
dor -e -b {base64}
```

## Author

Roland Bodenstaff

## Version History
* 0.0.1
    * Initial Release

## License

This project is licensed under the [MIT License](https://licenses.nuget.org/MIT)
