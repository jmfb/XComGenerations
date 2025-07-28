// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

// Suppress Windows-specific API warnings since this is a Windows-only application
[assembly: SuppressMessage(
	"Interoperability",
	"CA1416:Validate platform compatibility",
	Justification = "This is a Windows-only application using Windows Forms"
)]
