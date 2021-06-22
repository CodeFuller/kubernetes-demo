﻿using System.Runtime.Serialization;

namespace PublicService.Models
{
	[DataContract]
	public class EnvironmentVariable
	{
		[DataMember(Name = "name")]
		public string Name { get; init; }

		[DataMember(Name = "value")]
		public string Value { get; init; }
	}
}
