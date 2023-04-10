// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Text.Json.Nodes;

internal class Program
{
	private static void Main(string[] args)
	{
		var json = @"
		{
			'ReportId': 205,
			'AppraisalId': '31779A3B-4AD1-4671-8129-5AC7624CF3AF',
			'Dados':{
				'Nome': 'Neto',
				'Idade': 37
			}
		}
		";

		var dict = new Dictionary<string, string>()
		{
			{ "AppraisalId", "ReportFile.Id" },
			{ "ReportId", "ReportFile.ReportId" },
			{ "Dados.Nome", "Identification.Name" },
			{ "Dados.Idade", "Identification.Age"}
		};

		var obj = JObject.Parse(json);
		
		var newObj = new JObject();
		dict.Keys.ToList().ForEach(key =>
		{
			var newKey = dict[key];
			var value = obj.SelectToken("Dados.Nome");

			//newObj.Add(newKey, value);

			//newObj["Identification"] = null;
			//newObj["Identification"]["Name"] = null;
			//newObj["Identification"]["Name"] = "Neto";
			//newObj.TryAdd("Identification", null);
			//newObj["Identification"]["Age"] = new JObject(37);

			//JObject newChild = new();
			//foreach (var kv in newKey.Split('.'))
			//{
			//	newChild.TryAdd(kv, null);
			//	newChild["kv"] = value;

			//	newObj.Add(newChild);
			//	newObj.TryAdd(kv, 32);


			//}

			//newObj.Add((newChild);

			newObj = new JObject();

			newObj["ReportFile"] = new JObject();
			var jt = newObj["ReportFile"];

			newObj["ReportFile"]["Id"] = value;
			//newObj["ReportFile"]["Id"] = new JObject(;
		});		

		Console.WriteLine(obj);
		Console.WriteLine(newObj);
	}
}