using System.Collections.Generic;
using XCom.Battlescape.Tiles;
using XCom.Graphics;

namespace XCom.Data
{
	public class FacilityMetadata
	{
		public string Name { get; set; }
		public FacilityShape Shape { get; set; }
		public int DaysToConstruct { get; set; }
		public int Cost { get; set; }
		public int Maintenance { get; set; }
		public int DefenseValue { get; set; }
		public int HitRatio { get; set; }
		public Image Image { get; set; }
		public int RowOffset { get; set; }
		public int ColumnOffset { get; set; }
		public ResearchType? RequiredResearch { get; set; }
		public string[] DescriptionLines { get; set; }
		public Tileset[] Tilesets { get; set; }

		public bool IsRequiredResearchCompleted(List<ResearchType> completedResearch)
		{
			return RequiredResearch == null || completedResearch.Contains(RequiredResearch.Value);
		}
	}
}
