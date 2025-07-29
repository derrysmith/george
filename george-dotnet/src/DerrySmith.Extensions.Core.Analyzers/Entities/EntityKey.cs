namespace DerrySmith.Extensions.Core.Entities;

internal record EntityKey
{
	public string Filename { get; }

	public string Prefix { get; }
	public string Suffix { get; }

	public string TypeName      { get; }
	public string TypeNamespace { get; }

	public EntityKey(string filename, string prefix, string suffix, string typeName, string typeNamespace)
	{
		this.Filename = filename;

		this.Prefix = prefix;
		this.Suffix = suffix;

		this.TypeName      = typeName;
		this.TypeNamespace = typeNamespace;
	}
}