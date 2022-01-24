#pragma warning disable SA1649 // File name should match first type name

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TripleSix.Core.Dto;
using TripleSix.Core.Entities;

namespace TripleSix.Static.Middle.Mappers
{
    public class GlobalMapper : TripleSix.Core.Mappers.GlobalMapper
    {
        private readonly Assembly _commonAssembly = AppDomain.CurrentDomain.GetAssemblies().First(x => x.ManifestModule.ScopeName == "TripleSix.Static.Common.dll");
        private readonly Assembly _dataAssembly = AppDomain.CurrentDomain.GetAssemblies().First(x => x.ManifestModule.ScopeName == "TripleSix.Static.Data.dll");

        protected override IEnumerable<Type> SelectEntity()
        {
            return _dataAssembly.GetTypes()
                .Where(t => t.IsPublic)
                .Where(t => typeof(IEntity).IsAssignableFrom(t))
                .Where(t => t.Name.EndsWith("Entity"));
        }

        protected override IEnumerable<Type> SelectDto(string objectName)
        {
            var result = _commonAssembly.GetTypes()
                .Where(t => t.IsPublic)
                .Where(t => typeof(IDataDto).IsAssignableFrom(t))
                .Where(t =>
                {
                    return new[]
                    {
                        objectName + "Dto",
                        objectName + "ItemDto",
                        objectName + "DataDto",
                        objectName + "CreateDto",
                        objectName + "UpdateDto",
                    }.Contains(t.Name);
                });

            return result;
        }
    }
}
