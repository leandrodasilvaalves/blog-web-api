using Ductus.FluentDocker.Services;

namespace Blog.Specs.Docker
{
    public class DockerCompose
    {
        private static ICompositeService Containers { get; set; }
        private static readonly string[] Extensions = [".yaml", ".yml"];

        public static void Up()
        {
            Containers = new Ductus.FluentDocker.Builders.Builder()
                            .UseContainer()
                            .UseCompose()
                            .FromFile(GetFiles())
                            .ForceBuild()
                            .ForceRecreate()
                            .RemoveOrphans()
                            .WaitForHttp("api", "http://localhost:5326/swagger")
                            .Build()
                            .Start();
        }

        public static void Down() => Containers.Dispose();

        private static string[] GetFiles(DirectoryInfo directoryInfo = null)
        {
            directoryInfo ??= new DirectoryInfo(Environment.CurrentDirectory);

            var dockerComposeFiles = directoryInfo
                .GetFiles()
                .Where(f => Extensions.Contains(f.Extension.ToLower()));

            if (HasSolutionFile(directoryInfo) && dockerComposeFiles?.Count() == 0)
                throw new FileNotFoundException("No one docker compose file was found");

            return dockerComposeFiles?.Count() == 0 ?
                GetFiles(directoryInfo.Parent) :
                dockerComposeFiles.Select(f => f.FullName).ToArray();
        }

        private static bool HasSolutionFile(DirectoryInfo directoryInfo)
        {
            return directoryInfo
                .GetFiles()
                .Where(f => f.Extension?.ToLower() == ".sln")
                .FirstOrDefault() is not null;
        }
    }
}