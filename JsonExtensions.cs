﻿using Newtonsoft.Json.Linq;

namespace ConvertJson
{
	public static class JsonExtensions
	{
		public static JObject ReplacePath<T>(this JToken root, string path, T newValue)
		{
			if (root == null || path == null)
			{
				throw new ArgumentNullException();
			}

			foreach (var value in root.SelectTokens(path).ToList())
			{
				if (value == root)
				{
					root = JToken.FromObject(newValue);
				}
				else
				{
					value.Replace(JToken.FromObject(newValue));
				}
			}

			return (JObject)root;
		}
	}
}
