using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaLibrary
{
	public enum ParseErrors : int
	{
		ValueError,
		SeparationError,
		FileError,
		UndefinedError,
		Success
	}
}
