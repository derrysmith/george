using DerrySmith.Extensions.Core.Entities;

namespace DerrySmith.Extensions.Core.Tests.Entities;

[EntityKey(Prefix = "key_", Suffix = "_id")]
readonly partial record struct EntityKeyId;