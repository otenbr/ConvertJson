// See https://aka.ms/new-console-template for more information
using ConvertJson;
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

		obj.ReplacePath("Dados.Nome", "Junior");

		var newObj = JObject.FromObject(new Valuation());		
		dict.Keys.ToList().ForEach(key =>
		{
			var newKey = dict[key];
			var value = obj.SelectToken(key);

			newObj.ReplacePath(newKey, value);
		});

		//var newObj = new JObject();
		//dict.Keys.ToList().ForEach(key =>
		//{
		//	var newKey = dict[key];
		//	var value = obj.SelectToken(key);

		//	//newObj.Add(newKey, value);

		//	//newObj["Identification"] = null;
		//	//newObj["Identification"]["Name"] = null;
		//	//newObj["Identification"]["Name"] = "Neto";
		//	//newObj.TryAdd("Identification", null);
		//	//newObj["Identification"]["Age"] = new JObject(37);

		//	//JObject newChild = new();
		//	//foreach (var kv in newKey.Split('.'))
		//	//{
		//	//	newChild.TryAdd(kv, null);
		//	//	newChild["kv"] = value;

		//	//	newObj.Add(newChild);
		//	//	newObj.TryAdd(kv, 32);


		//	//}

		//	//newObj.Add((newChild);

		//	//newObj = new JObject();
		//	var writer = newObj.CreateWriter();
		//	var paths = newKey.Split('.');
		//	for (int i = 0; i < paths.Length; i++)
		//	{
		//		writer.WritePropertyName(paths[i]);
		//		if (i < paths.Length - 1)
		//		{
		//			writer.WriteStartObject();
		//		}
		//	}
		//	writer.WriteValue(value);
		//});		

		Console.WriteLine(obj);
		Console.WriteLine(newObj);
	}	
}