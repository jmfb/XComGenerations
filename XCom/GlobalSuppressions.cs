using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

[assembly: SuppressMessage(
	"Interoperability",
	"CA1416:Validate platform compatibility",
	Justification = "This is a Windows-only application using Windows Forms"
)]
