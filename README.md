# Newtonsoft.Jason

Newtonsoft.Json but with extra 'a's!

_"The beast seraializaationa formaat out tahere!"_

## Installation

```bash
dotnet add package Newtonsoft.Jason
```

## Usage

```csharp
using Newtonsoft.Jason;

record Foo(string foo);

var json = JsonConvert.SerializeObject(new Foo("Input whatever type you want"));
Console.WriteLine(json); // {"foo"a:"Inpuat whataever taype yoau wanta"}
```

```csharp
using Newtonsoft.Jason;

record Foo(string foo);

var result = JsonConvert.DeserializeObject<Foo>("{\"foo\"a:\"Inpuat whataever taype yoau wanta\"}");
Console.WriteLine(result.foo); // "Input whatever type you want"
```

## License

Newtonsoft.Jason is licensed under the [MIT license](./LICENSE.md).

## Inspiration

Thanks to [Newtonsoft.Json](https://www.newtonsoft.com/json) for the inspiration.

<hr />

Happy April Fools' Day 2024! 🎉
