# WPF Module Permissions

## Prism Module Overview

Remember, Prism Modules should be universal and not know about the project referencing them. Modules can be reusable across multple projects.

For example, Loging pages.  

## Module Catalogs

When using a Module Catalog, you must register your modules in an `App.config` and then use Post-Build events to copy the `.dll` file(s) to the bin folder.

```sh
xcopy "$(TargetDir)Modules.Admin.dll" "$(SouldionDir)PrismRoles\Bin\$(ConfigurationName)\" /Y
```
