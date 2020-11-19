using System.Threading.Tasks;

namespace Sharpen
{
    internal class AboutDialogViewModel
    {
        public GeneralInfoViewModel GeneralInfo { get; } = new GeneralInfoViewModel();
        public GitHubInfoViewModel GitHubInfo { get; } = new GitHubInfoViewModel();
        public VisualStudioMarketplaceViewModel VisualStudioMarketplaceInfo { get; } = new VisualStudioMarketplaceViewModel();
        public ChangelogViewModel Changelog { get; } = new ChangelogViewModel();

        public async Task LoadAsync()
        {
            await Task.WhenAll(GeneralInfo.SetGeneralInfoAsync(), GitHubInfo.SetGitHubInfoAsync(), VisualStudioMarketplaceInfo.SetVisualStudioMarketplaceInfoAsync(), Changelog.SetChangelogAsync());
        }
    }
}
