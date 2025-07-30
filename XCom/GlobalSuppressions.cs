using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
	"Interoperability",
	"CA1416:Validate platform compatibility",
	Justification = "This is a Windows-only application using Windows Forms"
)]
[assembly: SuppressMessage(
	"Style",
	"IDE1006:Naming Styles",
	Justification = "<Pending>",
	Scope = "type",
	Target = "~T:XCom.Battlescape.Tiles.BaseSprite"
)]
