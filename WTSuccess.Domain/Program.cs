var s=Console.ReadLine();
string a = "DON";
string b = "Dilshod";
Dictionary<string, string> keyValuePairs = new Dictionary<string, string>() { { a, b } };
if (s==keyValuePairs.Values.FirstOrDefault())
{
    Console.WriteLine(keyValuePairs.Keys.FirstOrDefault());
}
a v = new a();
v.MyProperty[0] = "don0";
v.MyProperty[1] = "don";

foreach (var item in v.MyProperty)
{
    Console.WriteLine(item);
}
class a
{
public string[] MyProperty { get; set; }=new string[2];

}
