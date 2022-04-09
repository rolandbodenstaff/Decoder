
using CommandLine;
using CommandLine.Text;
using Robod.Decoder.Cli;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;

var parser = new Parser(with => with.HelpWriter = null);
var parserResult = parser.ParseArguments<Options>(args);
if (args.Length == 0) DisplayHelp(parserResult);

parserResult
  .WithParsed<Options>(o =>
  {
      if (!string.IsNullOrEmpty(o.Jwt))
          DecodeJwt(o.Jwt);
      else if (!string.IsNullOrEmpty(o.Base64))
          ParseBase64(o.Base64, o.Encode);
      else if (!string.IsNullOrEmpty(o.Url))
          ParseUrl(o.Url, o.Encode);
      else
          throw new ArgumentException("No input provided");
  })
  .WithNotParsed(errs => DisplayHelp(parserResult));


void DisplayHelp<T>(ParserResult<T> result)
{
    var helpText = HelpText.AutoBuild(result, h => HelpText.DefaultParsingErrorsHandler(result, h), e => e);
    Console.WriteLine(helpText);
    Environment.Exit(1);
}

void ParseUrl(string url, bool encode)
{
    string output = string.Empty;
    if (encode)
        output = Uri.EscapeDataString(url);
    else
        output = Uri.UnescapeDataString(url);

    Console.WriteLine(output);
    CopyToClipboard(output);
}

void ParseBase64(string base64, bool encode)
{
    string output = string.Empty;
    if (encode)
        output = Convert.ToBase64String(Encoding.UTF8.GetBytes(base64));
    else
        output = Encoding.UTF8.GetString(Convert.FromBase64String(base64));

    Console.WriteLine(output);
    CopyToClipboard(output);
}

void DecodeJwt(string jwt)
{
    var handler = new JwtSecurityTokenHandler();
    var jsonToken = handler.ReadToken(jwt);
    var tokenS = jsonToken as JwtSecurityToken;

    if (tokenS == null)
    {
        Console.WriteLine("Invalid JWT");
        return;
    }
    var json = JsonSerializer.Serialize(tokenS.Payload, new JsonSerializerOptions
    {
        WriteIndented = true
    });
    Console.WriteLine(json);
    CopyToClipboard(json);
}

void CopyToClipboard(string text)
{
    TextCopy.ClipboardService.SetText(text);
}

