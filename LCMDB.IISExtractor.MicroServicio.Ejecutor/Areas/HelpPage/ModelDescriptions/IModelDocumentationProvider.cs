using System;
using System.Reflection;

namespace LCMDB.IISExtractor.MicroServicio.Ejecutor.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}