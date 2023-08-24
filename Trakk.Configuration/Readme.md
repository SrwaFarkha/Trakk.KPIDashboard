# Trakk.Configuration 

## Introduction 

The goal with this project is to make configuration a bit cleaner and organized.
Important configuration files should be placed in a hierarchy in the folder 'Configs' 
in this project.

> #### The configuration hierarchy works like this:
>* **appsettings.json** -> *all projects all configurations.*
>* **appsettings.[configuration].json** -> *all projects when built in specified configuration.*
>* **appsettings.[configuration].[project].json** -> *only for specified project & build*

ConfigManager creates a global configuration with easy access for your project.
This allows non-dependency injected objects to access the same configuration 
that would be injected into a dependency.



### Setup

To include a new appsettings.json in a project you have to edit the .csproj of that project.  
Add a modified copy of the example down below, add to existing item group if one already exists.

    <ContentWithTargetPath Include="..\Trakk.Configuration\Configs\appsettings.$(Configuration).Api.json">
        <DependentUpon>appsettings.$(Configuration).json</DependentUpon>
        <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        <TargetPath>Configs\%(Filename)%(Extension)</TargetPath>
    </ContentWithTargetPath>

After you should see a folder named 'Configs' with your config file inside.

>### warning
> files are shared with all projects and editing
> in one project will edit the same file in all shared projects.

### Usage

Start by calling 'ConfigManager.Setup([config])' in your project, do this first. There are a few predefined options
you could use [Api, Manager, Server, Services], choosing one of these will load the config
files for the project if they're included in csproj.

>to setup with a custom configuration you call Setup(builder => builder.[your config]).

>if you're using dependency injection you should clear the default sources
and then add ConfigManager.Configuration as a source.

To access the configuration you can call ConfigManager.Instance.Configuration anywhere.

You can dump the current configuration with ConfigManager.Instance.Dump()
to confirm loaded settings.

### Overrides after build

To override settings you have two options.  
* Create a folder inside 'Configs' named 'Overrides' and place a new json file with the new settings
you want to override. 
* Use environment variables. Environment variables should start with 'TRAKK_' 
followed by the setting path you want to override. *ex: TRAKK_ConnectionStrings__TNTDB5Context*

> *Note* 'Configs/Overrides/[name].json' overrides environment variables.

