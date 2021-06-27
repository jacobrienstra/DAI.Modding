using System;
using System.Collections.Immutable;
using System.Composition;
using System.Reflection;
using DAI.Mod;

using RoslynPad.UI;

namespace RoslynPad {
    [Export(typeof(MainViewModelBase)), Shared]
    public class MainViewModel : MainViewModelBase {
        [ImportingConstructor]
        public MainViewModel(IServiceProvider serviceProvider, ITelemetryProvider telemetryProvider, ICommandProvider commands, IAppDispatcher appDispatcher, IApplicationSettings settings, NuGetViewModel nugetViewModel) : base(serviceProvider, telemetryProvider, commands, appDispatcher, settings, nugetViewModel) {
        }

        protected override ImmutableArray<Assembly> CompositionAssemblies => base.CompositionAssemblies
            .Add(Assembly.Load(new AssemblyName("RoslynPad.Roslyn.Windows")))
            .Add(Assembly.Load(new AssemblyName("RoslynPad.Editor.Windows")));

        protected override ImmutableArray<Type> TypeReferences => base.TypeReferences
            .Add(typeof(ModScript))
            .Add(typeof(ModConfigElement))
            .Add(typeof(ModConfigElementsList))
            .Add(typeof(Scripting));
    }
}