﻿using System;
using System.Collections.Generic;
using System.Reflection;

using Dapper;

namespace DatabasesApp.Application.Mapping
{
    public class FallBackTypeMapper : SqlMapper.ITypeMap
    {
        private readonly IEnumerable<SqlMapper.ITypeMap> _mappers;

        public FallBackTypeMapper(IEnumerable<SqlMapper.ITypeMap> mappers)
        {
            _mappers = mappers;
        }

        public ConstructorInfo FindConstructor(string[] names, Type[] types)
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var result = mapper.FindConstructor(names, types);

                    if (result != null)
                    {
                        return result;
                    }
                }
                catch (NotImplementedException)
                {
                    // the CustomPropertyTypeMap only supports a no-args
                    // constructor and throws a not implemented exception.
                    // to work around that, catch and ignore.
                }
            }
            return null;
        }

        public ConstructorInfo FindExplicitConstructor()
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var result = mapper.FindExplicitConstructor();

                    if (result != null)
                    {
                        return result;
                    }
                }
                catch (NotImplementedException)
                {
                    // the CustomPropertyTypeMap only supports a no-args
                    // constructor and throws a not implemented exception.
                    // to work around that, catch and ignore.
                }
            }

            return null;
        }

        public SqlMapper.IMemberMap GetConstructorParameter(ConstructorInfo constructor, string columnName)
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var result = mapper.GetConstructorParameter(constructor, columnName);

                    if (result != null)
                    {
                        return result;
                    }
                }
                catch (NotImplementedException)
                {
                    // the CustomPropertyTypeMap only supports a no-args
                    // constructor and throws a not implemented exception.
                    // to work around that, catch and ignore.
                }
            }
            return null;
        }

        public SqlMapper.IMemberMap GetMember(string columnName)
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var result = mapper.GetMember(columnName);

                    if (result != null)
                    {
                        return result;
                    }
                }
                catch (NotImplementedException)
                {
                    // the CustomPropertyTypeMap only supports a no-args
                    // constructor and throws a not implemented exception.
                    // to work around that, catch and ignore.
                }
            }
            return null;
        }
    }
}
