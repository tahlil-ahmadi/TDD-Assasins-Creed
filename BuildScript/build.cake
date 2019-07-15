var unitTestProjects = GetFiles("../**/*Tests.csproj");
var solutionPath = @"..\FlightSchedule.sln";

Task("Clean")
    .Does(()=>{
        DotNetCoreClean(solutionPath);
    //   foreach(var project in allProjects) {
    //       DotNetCoreClean(project.FullPath);
    //   }
});

Task("Restore-NuGet-Packages")
    .Does(() =>
{
    var settings = new DotNetCoreRestoreSettings
    {
         DisableParallel = true,
    };
    DotNetCoreRestore(solutionPath, settings);
});

Task("Build")
    .Does(()=>
    {
        DotNetCoreBuild(solutionPath);
    });

Task("Run-Unit-Tests")
    .Does(()=>
    {
       foreach(var project in unitTestProjects){
           DotNetCoreTest(project.FullPath);
       }
    });  

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore-NuGet-Packages")
    .IsDependentOn("Build")
    .IsDependentOn("Run-Unit-Tests")
    ;

RunTarget("Default");