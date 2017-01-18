# BaseNTypes and Validators

A .NET-Core (C#) implementation using the netstandard1.0 framework

This project implements instance representations and Validators for

- Base16
- Base32
- Base32 extended hex alphabet
- Base64
- Base64 URL and filename safe alphabet
- Base64 URL and filename safe alphabet in Jws representation

based on [RFC4648](http://tools.ietf.org/html/rfc4648).

## Features

- Encoding/Decoding is done only once per instance
- Each BaseN Instance can easily converted to another BaseN representation (i. e. Base32 to Base64Url)
- Decoder and Encoder can replaced
- Validators are usable independent from the BaseN implementation
- A set of Extension methods for simple usage and better readability

## Supported Frameworks

- .Net Standard 1.0 (which includes .NET Core)
- .Net 4.0+

## Installation

Download directly from [NuGet](https://www.nuget.org/packages/Franzmayr.BaseNTypes)
or via NuGet Package Manager: ```Install-Package franzmayr.basentypes```

## Usage Examples

Create a Base32 encoded string from the Base64 encoded string "Zm9vYg=="

```csharp
using Franzmayr.BaseNTypes

private static string ConvertBase64ToBase32Demo()
{
    // maybe you get the instance from another module or library
    var base64Instance = CreateBase64Instance("Zm9vYg==");

    return new Base32(base64Instance).ToString();
}

private static Base64 CreateBase64Instance(string base64EncodedString)
{
    return new Base64(base64EncodedString);
}
```

### Using Extension Methods

```csharp
using Franzmayr.BaseNTypes

private static string ConvertBase64ToBase32UsingExtensionMethodsDemo()
{
    return "Zm9vYg==".AsBase64().ToBase32().ToString();
}
```

Result: "MZXW6YQ="

### Using Validation

```csharp
using Franzmayr.BaseNTypes.Validate

private static string ConvertBase64ToBase32UsingExtensionMethodsDemo()
{
    var validationResult = new Base64Validator("Zm9vYg==").IsValid;
}
```

***

## License

This project is licensed under the [MIT license](https://opensource.org/licenses/MIT), a copy of the license is located in LICENSE.txt.

## Credits

The Encoder and Decoder is adapted from [Albireo.Base32](https://github.com/kappa7194/base32/blob/master/Albireo.Base32/Base32.cs)
which also is licensed under the [MIT License](https://github.com/kappa7194/base32/blob/master/LICENSE.txt). Thanks to [Albireo](https://github.com/kappa7194).
