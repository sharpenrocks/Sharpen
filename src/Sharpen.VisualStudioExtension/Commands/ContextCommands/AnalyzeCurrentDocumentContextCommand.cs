﻿using System;
using Sharpen.Engine.Analysis;
using Sharpen.Engine.Extensions.CodeDetection;

namespace Sharpen.VisualStudioExtension.Commands.ContextCommands
{
    internal sealed class AnalyzeCurrentDocumentContextCommand : BaseAnalyzeCommand<AnalyzeCurrentDocumentContextCommand>
    {
        public const int CommandId = 0x200;
        public static readonly Guid CommandSet = new Guid("F343DB77-7F1C-4BAD-89FB-39E74DD7BD20");

        private AnalyzeCurrentDocumentContextCommand(ICommandServicesContainer commandServicesContainer)
            : base(commandServicesContainer, CommandId, CommandSet, true) { }

        public static void Initialize(ICommandServicesContainer commandServicesContainer)
        {
            Instance = new AnalyzeCurrentDocumentContextCommand(commandServicesContainer);
        }

        protected override void IsCommandVisibleAndEnabled(out bool isVisible, out bool isEnabled)
        {
            // We do a quick check here if the current file can be analyzed,
            // based only on the file name and extension.
            // In the very unlikely case, we will come to the conclusion that the file
            // can be analyzed, and the detailed check in the scope analyzer will
            // reject it with the appropriate message. This is fine.
            // At this point, we want to get a quick and cheap Yes or No that will
            // work in 95% of the cases.
            var isVisibleAndEnabled = VisualStudioIde.ActiveDocument.IsCSharpDocument() &&
                                      !GeneratedCodeDetection.IsGeneratedFile(VisualStudioIde.ActiveDocument.FullName);

            isVisible = isEnabled = isVisibleAndEnabled;
        }

        protected override IScopeAnalyzer GetScopeAnalyzer()
        {            
            var document = Workspace.GetRoslynDocumentFromVisualStudioDocument(VisualStudioIde.ActiveDocument);

            return document == null // Should actually not happen, but who knows what kind of file one can have in VS.
                ? new MultipleDocumentsScopeAnalyzer()
                : new MultipleDocumentsScopeAnalyzer(document);
        }
    }
}