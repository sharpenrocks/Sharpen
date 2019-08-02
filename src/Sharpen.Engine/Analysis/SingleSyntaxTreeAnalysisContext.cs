using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;

namespace Sharpen.Engine.Analysis
{
    /// <summary>
    /// Contains the information about the context within which the syntax tree was analyzed.
    /// The syntax tree belongs to a document, which is contained within a project.
    /// </summary>
    public class SingleSyntaxTreeAnalysisContext
    {
        /// <summary>
        /// Name of the project to which the analyzed syntax tree's document belongs.
        /// </summary>
        public string ProjectName { get; }

        /// <summary>
        /// The logical path to the document to which the analyzed syntax tree belongs.
        /// This path can differ from the path of the file on the disk.
        /// </summary>
        public string LogicalFolderPath { get; }

        public LanguageVersion LanguageVersion { get; }

       
        // To be used in unit tests only.
        internal SingleSyntaxTreeAnalysisContext(string projectName, string logicalFolderPath)
        {
            ProjectName = projectName;
            LogicalFolderPath = logicalFolderPath;
        }

        public SingleSyntaxTreeAnalysisContext(Document document)
        {

            ProjectName = document.Project.Name;
            LanguageVersion =  ((CSharpParseOptions)document.Project.ParseOptions).LanguageVersion;
            // TODO-PERF: Create a logical folder path string only once.
            //            There are usually several or even many documents that share the same logical folder.
            //            Right now, a new string with the same content will be create for each of such documents.
            //            Reuse the strings if they are already created instead of creating new ones.
            LogicalFolderPath = string.Join("\\", document.Folders);
        }
    }
}