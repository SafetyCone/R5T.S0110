using System;
using System.Threading.Tasks;


namespace R5T.S0110
{
    class Program
    {
        static async Task Main()
        {
            await Scripts.Instance
                //.Get_GitHubClient()
                //await Scripts.Instance.Query_GitHubRepository();
                //await Scripts.Instance.Delete_RemoteRepositoryOnly();
                //await Scripts.Instance.Create_RemoteRepositoryOnly();
                //await Scripts.Instance.In_CreatedRemoteRepositoryContext();
                //await Scripts.Instance.Generate_Repository();

            //await Scripts.Instance.Regenerate_ConsoleRepository();
            //await Scripts.Instance.Regenerate_ClassLibraryRepository();
            //await Scripts.Instance.Regenerate_LibraryWithConstructionRepository();
            //await Scripts.Instance.Regenerate_StaticHtmlWebApplicationRepository();
            //.Regenerate_BlogStaticHtmlWebApplicationRepository()
            //await Scripts.Instance.Regenerate_NonWebAssemblyRazorComponentsRazorClassLibraryRepository();
            //await Scripts.Instance.Regenerate_NonWebAssemblyRazorComponentsRazorClassLibrary_WithConstructionStaticHtmlWebApplicationRepository();
            //await Scripts.Instance.Regenerate_NonWebAssemblyRazorComponentsRazorClassLibrary_WithConstructionStaticHtmlWebApplicationRepository_WithTailwindCss();
            //await Scripts.Instance.Regenerate_WindowsFormsLibraryRepository();
            //await Scripts.Instance.Regenerate_WindowsFormsApplicationRepository();
            //await Scripts.Instance.Regenerate_WindowsFormsApplication_WithWindowsFormsLibraryRepository();
                .Regenerate_BlazorComponentsWebAssemblyClientAndServerRepository()
            // Need a without-TailwindCSS.
            //await Scripts.Instance.Regenerate_BlazorComponentsLibrary_WithConstructionWebAssemblyClientAndServerRepository_WithTailwindCss();
            ;
        }
    }
}