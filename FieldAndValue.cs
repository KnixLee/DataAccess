using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
	public class FieldAndValue
	{
		public string Field = "";
		public object Value = "";
		public FieldAndValue()
		{ }
		public FieldAndValue(string field, object value)
		{
			Field = field;
			Value = value;
		}
	}
}
