using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace DerrySmith.Extensions.Core.Entities;

[Generator]
internal class EntityKeyGenerator : IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		// using marker attributes, get collection of defined entity keys to generate
		var entityKeys = context.SyntaxProvider.ForAttributeWithMetadataName(
			typeof(EntityKeyAttribute).FullName!,
			predicate: static (_, _) => true,
			transform: TransformEntityKey);

		// register output for entity keys
		context.RegisterSourceOutput(entityKeys, GenerateEntityKeyCode);
	}

	private static EntityKey? TransformEntityKey(GeneratorAttributeSyntaxContext ctx, CancellationToken ct)
	{
		return GetEntityKey(ctx.SemanticModel, ctx.TargetNode, ctx.Attributes);
	}

	private static EntityKey? GetEntityKey(
		SemanticModel model, SyntaxNode node, ImmutableArray<AttributeData> attributes)
	{
		// exit method early if we can't get the symbol
		if (model.GetDeclaredSymbol(node) is not INamedTypeSymbol symbol) return null;

		var filename      = symbol.ToString();
		var typeName      = symbol.Name;
		var typeNamespace = symbol.ContainingNamespace.ToString();
		
		// get prefix and suffix from attribute
		var entityKeyAttribute = attributes.First(data => data.AttributeClass?.Name == nameof(EntityKeyAttribute));
		
		var prefix = entityKeyAttribute.NamedArguments.FirstOrDefault(kvp =>
			kvp.Key == nameof(EntityKeyAttribute.Prefix)).Value.Value?.ToString() ?? string.Empty;
		var suffix = entityKeyAttribute.NamedArguments.FirstOrDefault(kvp =>
			kvp.Key == nameof(EntityKeyAttribute.Suffix)).Value.Value?.ToString() ?? string.Empty;
		
		return new EntityKey(filename, prefix, suffix, typeName, typeNamespace);
	}

	private static void GenerateEntityKeyCode(SourceProductionContext spc, EntityKey? model)
	{
		// don't generate any source code if the entity key model is null/empty
		if (model is null) return;

		var result = $@"
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace {model.TypeNamespace}
{{
	[JsonConverter(typeof({model.TypeName}JsonConverter))]
	public readonly partial record struct {model.TypeName} : {typeof(IEntityKey).FullName}
	{{
		private const string Prefix = ""{model.Prefix}"";
		private const string Suffix = ""{model.Suffix}"";

		private readonly Ulid _value;

		private {model.TypeName}(Ulid value)
		{{
			_value = value;
		}}

		public static {model.TypeName} New()
		{{
			return new {model.TypeName}(Ulid.NewUlid());
		}}

		public static {model.TypeName} Parse(string value)
		{{
			if (TryParse(value, out var entityKey))
				return entityKey;

			throw new ArgumentException($""Cannot parse '{{value}}' into type {model.TypeName}."");
		}}

		public static {model.TypeName} Parse(Guid value)
		{{
			if (TryParse(value, out var entityKey))
				return entityKey;

			throw new ArgumentException($""Cannot parse '{{value}}' into type {model.TypeName}."");
		}}

		public static bool TryParse(string value, out {model.TypeName} entityKey)
		{{
			// extract ulid value from string
			var entityKeyRawValue = {typeof(EntityKeyExtensions).FullName}.ExtractEntityKeyRawValue(value, Prefix, Suffix);

			if (Ulid.TryParse(entityKeyRawValue, out var ulid))
			{{
				entityKey = new {model.TypeName}(ulid);
				return true;
			}}

			if (Guid.TryParse(entityKeyRawValue, out var guid))
			{{
				entityKey = new {model.TypeName}(new Ulid(guid));
				return true;
			}}

			entityKey = default;
			return false;
		}}

		public static bool TryParse(Guid value, out {model.TypeName} entityKey)
		{{
			entityKey = new {model.TypeName}(new Ulid(value));
			return true;
		}}

		public override string ToString()
		{{
			return $""{{Prefix}}{{_value}}{{Suffix}}"";
		}}
	}}

	public class {model.TypeName}JsonConverter : JsonConverter<{model.TypeName}>
	{{
		public override {model.TypeName} Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			=> {model.TypeName}.Parse(reader.GetString());

		public override void Write(Utf8JsonWriter writer, {model.TypeName} value, JsonSerializerOptions options)
			=> writer.WriteStringValue(value.ToString());
	}}
}}";

		spc.AddSource($"{model.Filename}.g.cs", SourceText.From(result, Encoding.UTF8));
	}
}