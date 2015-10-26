using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XCom.Battlescape.Tiles
{
	public class TilePropertyPageJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var tile = (TilePropertyPage)value;
			writer.WriteStartObject();
			writer.WritePropertyName("Tile");
			serializer.Serialize(writer, Convert.ToBase64String(tile.GetBytes()));
			writer.WriteEndObject();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var value = JObject.Load(reader).Properties().Single().Value;
			return Convert.FromBase64String((string)value).ReadStruct<TilePropertyPage>(0);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(TilePropertyPage).IsAssignableFrom(objectType);
		}
	}
}
