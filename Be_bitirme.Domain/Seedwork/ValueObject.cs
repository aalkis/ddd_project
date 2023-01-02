﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Domain.Seedwork
{
    public abstract class ValueObject
    {
        protected static bool EqualOpertator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }
        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOpertator(left, right);
        }
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            var other = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);

        }
        public ValueObject GetCopy()
        {
            return MemberwiseClone() as ValueObject;
        }
    }
}
