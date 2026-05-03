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
                //.Query_GitHubRepository()
                //.Delete_RemoteRepositoryOnly()
                //.Create_RemoteRepositoryOnly()
                //.In_CreatedRemoteRepositoryContext()
                //.Generate_Repository()

                //.Regenerate_ConsoleRepository()
                .Regenerate_ClassLibraryRepository()
                //.Regenerate_LibraryWithConstructionRepository()
                //.Regenerate_StaticHtmlWebApplicationRepository()
                //.Regenerate_BlogStaticHtmlWebApplicationRepository()
                //.Regenerate_NonWebAssemblyRazorComponentsRazorClassLibraryRepository()
                //.Regenerate_NonWebAssemblyRazorComponentsRazorClassLibrary_WithConstructionStaticHtmlWebApplicationRepository()
                //.Regenerate_NonWebAssemblyRazorComponentsRazorClassLibrary_WithConstructionStaticHtmlWebApplicationRepository_WithTailwindCss()
                //.Regenerate_WindowsFormsLibraryRepository()
                //.Regenerate_WindowsFormsApplicationRepository()
                //.Regenerate_WindowsFormsApplication_WithWindowsFormsLibraryRepository()
                //.Regenerate_BlazorComponentsWebAssemblyClientAndServerRepository()
                // Need a without-TailwindCSS.
                //.Regenerate_BlazorComponentsLibrary_WithConstructionWebAssemblyClientAndServerRepository_WithTailwindCss()
                ;
        }
    }
}