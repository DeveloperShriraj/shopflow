using System;
using System.Collections.Generic;
using System.Text;

namespace ShopFlow.SharedKernel
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull
    {
        protected Entity(TId id)
        {
            Id = id;
        }
        public TId Id { get; }

        public bool Equals(Entity<TId>? other) =>
            other is not null && GetType() == other.GetType()
            && EqualityComparer<TId>.Default.Equals(Id, other.Id);

        public override bool Equals(object? obj) => Equals(obj as Entity<TId>);
        public override int GetHashCode() => HashCode.Combine(GetType(), Id);

    }
}
