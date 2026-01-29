// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;

using RandomNumberGenerator rng = RandomNumberGenerator.Create();
byte[] entropy = new byte[64];
rng.GetBytes(entropy);

Console.WriteLine($"entropy : {Convert.ToBase64String(entropy)}");
Console.WriteLine();


Dictionary<string, string> dic = new Dictionary<string, string>()
{
    ["Development"] = "Test1234=Dev",
    ["Staging"] = "Test1234=Staging",
    ["Production"] = "Test1234=Prod",
};


foreach (KeyValuePair<string, string> kvp in dic)
{
    byte[] cypher = ProtectedData.Protect(Encoding.Unicode.GetBytes(kvp.Value), entropy, DataProtectionScope.LocalMachine);

    string cypherAsString = Convert.ToBase64String(cypher);
    Console.WriteLine($"{kvp.Key} : {cypherAsString}");
    Console.WriteLine();
}